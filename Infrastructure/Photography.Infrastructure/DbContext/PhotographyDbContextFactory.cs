using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.DbContext
{
    public class PhotographyDbContextFactory : IDesignTimeDbContextFactory<PhotographyDbContext>
    {
        public PhotographyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhotographyDbContext>();

            return new PhotographyDbContext(optionsBuilder.Options);
        }
    }
}
