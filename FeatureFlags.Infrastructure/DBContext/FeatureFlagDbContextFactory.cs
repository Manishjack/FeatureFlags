using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Infrastructure.DBContext
{
    public class FeatureFlagDbContextFactory : IDesignTimeDbContextFactory<FeatureFlagDbContext>
    {

        public FeatureFlagDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FeatureFlagDbContext>(); 
            optionsBuilder.UseSqlite("Data Source=featureflags.db"); // same connection string as Program.cs
            return new FeatureFlagDbContext(optionsBuilder.Options); 
        
        }
    }
}
