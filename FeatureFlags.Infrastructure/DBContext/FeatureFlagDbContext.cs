using FeatureFlags.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlags.Infrastructure.DBContext
{
    public class FeatureFlagDbContext : DbContext 
    {
        public FeatureFlagDbContext(DbContextOptions<FeatureFlagDbContext> options) : base(options) { }
        public DbSet<FeatureFlag> FeatureFlags { get; set; }
    }
}
