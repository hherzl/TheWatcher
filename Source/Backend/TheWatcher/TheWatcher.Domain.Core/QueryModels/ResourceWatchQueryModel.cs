namespace TheWatcher.Domain.Core.QueryModels
{
    public class ResourceWatchQueryModel
    {
        public short? Id { get; set; }
        public string? Resource { get; set; }
        public string? ResourceCategory { get; set; }
        public string? AssemblyQualifiedName { get; set; }
        public string? Environment { get; set; }
        public double? Interval { get; set; }
    }
}
