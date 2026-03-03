using FeatureFlags.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.UnitTests.FeatureFlags.UnitTests
{
    public class FeatureFlagTests 
    {
        [Fact] 
        public void Evaluate_ReturnsUserOverride_WhenExists() 
        { 
            var flag = new FeatureFlag("TestFeature", false); 
            flag.SetUserOverride("user1", true); 
            var result = flag.Evaluate("user1"); 
            Assert.True(result); 
        }
    }
}
