namespace TheWatcher.API.Panel.Models
{
    public record ResourceDetailsModel
    {
        public short? Id { get; set; }
        public string? Name { get; set; }
        public short? ResourceCategoryId { get; set; }
        public string? ResourceCategory { get; set; }
        public short? WatcherId { get; set; }
        public string? Watcher { get; set; }

        public List<ResourceWatchDetailsModel> Watches { get; set; }
    }

    public record ResourceWatchDetailsModel
    {
        public short? Id { get; set; }
        public short? EnvironmentId { get; set; }
        public string? Environment { get; set; }
        public bool? Successful { get; set; }
        public int? WatchCount { get; set; }
        public DateTime? LastWatch { get; set; }
        public int? Interval { get; set; }

        public List<ResourceWatchParameterDetailsModel> Parameters { get; set; }
    }

    public record ResourceWatchParameterDetailsModel
    {
        public string? Parameter { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
