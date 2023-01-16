namespace TheWatcher.API.Panel.Models
{
    public record WatcherItemModel
    {
        public short? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
