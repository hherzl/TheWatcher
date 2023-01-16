namespace TheWatcher.API.Panel.Models
{
    public record ResourceWatchItemModel
    {
        public short? ResourceId { get; set; }
        public string? Resource { get; set; }
        public short? EnvironmentId { get; set; }
        public string? Environment { get; set; }
        public bool? Successful { get; set; }
        public int? WatchCount { get; set; }
        public DateTime? LastWatch { get; set; }
        public int? Interval { get; set; }
    }
}
