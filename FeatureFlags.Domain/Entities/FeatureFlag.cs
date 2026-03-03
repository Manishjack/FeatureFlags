namespace FeatureFlags.Domain.Entities
{
    public class FeatureFlag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool DefaultState { get; private set; }
        public string? Description { get; private set; }
        private readonly Dictionary<string, bool> _userOverrides = new();
        private readonly Dictionary<string, bool> _groupOverrides = new();
        private readonly Dictionary<string, bool> _regionOverrides = new();
        public FeatureFlag(string name, bool defaultState, string? description = null)
        {
            Id = Guid.NewGuid(); Name = name; DefaultState = defaultState; Description = description;
        }
        public bool Evaluate(string? userId = null, string? groupId = null, string? region = null)
        {
            if (userId != null && _userOverrides.TryGetValue(userId, out var userState))
            {
                return userState;
            }
            if (groupId != null && _groupOverrides.TryGetValue(groupId, out var groupState))
            {
                return groupState;
            }
            if (region != null && _regionOverrides.TryGetValue(region, out var regionState))
            {
                return regionState;
            }
            return DefaultState;
        }
        public void SetUserOverride(string userId, bool state) => _userOverrides[userId] = state;
        public void SetGroupOverride(string groupId, bool state) => _groupOverrides[groupId] = state;
        public void SetRegionOverride(string region, bool state) => _regionOverrides[region] = state;
    }
}
