using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Photography.Infrastructure.Types.Category.Data;
using System;

namespace Photography.Infrastructure.DbContext
{
    using DbContext = Microsoft.EntityFrameworkCore.DbContext;

    public partial class PhotographyDbContext : DbContext
    {
        public virtual DbSet<CategoryEntity> CategoryEntities { get; set; }

        public PhotographyDbContext()
        {

        }
        public PhotographyDbContext(DbContextOptions<PhotographyDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()

                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PhotographyDbContext"));
        }
    }
}
