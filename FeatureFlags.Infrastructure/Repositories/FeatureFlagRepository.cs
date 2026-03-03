using FeatureFlags.Application.Services;
using FeatureFlags.Domain.Entities;
using FeatureFlags.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Infrastructure.Repositories
{
    public class FeatureFlagRepository : IFeatureFlagRepository
    {
        private readonly FeatureFlagDbContext _context;

        public FeatureFlagRepository(FeatureFlagDbContext context)
        {
            _context = context;
        }

        public async Task<FeatureFlag?> GetByNameAsync(string name) =>
            await _context.FeatureFlags.FirstOrDefaultAsync(f => f.Name == name);

        public async Task<List<FeatureFlag>> GetAllAsync() =>
            await _context.FeatureFlags.ToListAsync();

        public async Task AddAsync(FeatureFlag flag)
        {
            _context.FeatureFlags.Add(flag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeatureFlag flag)
        {
            _context.FeatureFlags.Update(flag);
            await _context.SaveChangesAsync();
        }
    }
}
