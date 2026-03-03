using FeatureFlags.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Application.Services
{
    public interface IFeatureFlagRepository
    {
        Task<FeatureFlag?> GetByNameAsync(string name); 
        Task<List<FeatureFlag>> GetAllAsync(); 
        Task AddAsync(FeatureFlag flag); 
        Task UpdateAsync(FeatureFlag flag);
    }
}
