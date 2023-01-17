namespace TheWatcher.API.Monitor.Hubs.Models
{
    public record ResourceWatchArg
    {
        public string? Resource { get; set; }
        public bool IsSuccess { get; set; }
    }
}
