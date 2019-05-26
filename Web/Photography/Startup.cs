using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photography.Constraints;
using Photography.Infrastructure.DbContext;
using Photography.Infrastructure.Types.Category;
using Photography.Infrastructure.Types.Enquiry;
using Photography.Infrastructure.Types.Image;

namespace Photography
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.AppendTrailingSlash = false;
                options.LowercaseUrls = true;                  
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var controllerAssembly = Assembly.Load(new AssemblyName("Photography.Api"));
            services.AddMvc().AddApplicationPart(controllerAssembly).AddControllersAsServices();

            services.AddDbContext<PhotographyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PhotographyDbContext")));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEnquiryService, EnquiryService>();
            services.AddScoped<IImageService, ImageService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "HomePage",
                    template: "",
                    defaults: new { controller = "Page", action = "Home" }
                    );

                routes.MapRoute(
                    name: "About",
                    template: "about",
                    defaults: new { controller = "Page", action = "AboutUs" }
                    );

                routes.MapRoute(
                    name: "Contact",
                    template: "contact",
                    defaults: new { controller = "Page", action = "Contact" }
                    );


                routes.MapRoute(
                    name: "Category",
                    template: "{*slug}",
                    defaults: new { controller = "Category", action = "Listing" },
                    constraints: new { slug = new PageConstraint() }
                    );
            });
        }
    }
}
