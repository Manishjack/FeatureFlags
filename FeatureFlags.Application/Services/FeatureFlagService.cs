using FeatureFlags.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Application.Services
{
    public class FeatureFlagService
    {
        private readonly IFeatureFlagRepository _repository;
        public FeatureFlagService(IFeatureFlagRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> EvaluateAsync(string featureName, string? userId = null, string? groupId = null, string? region = null)
        {
            var flag = await _repository.GetByNameAsync(featureName);
            if (flag == null)
            {
                throw new InvalidOperationException("Feature not found");
            }
            return flag.Evaluate(userId, groupId, region);

        }
        public async Task CreateAsync(string name, bool defaultState, string? description = null)
        {
            var existing = await _repository.GetByNameAsync(name);
            if (existing != null)
            {
                throw new InvalidOperationException("Duplicate feature key");
            }
            var flag = new FeatureFlag(name, defaultState, description);
            await _repository.AddAsync(flag);
        }
    }
}
