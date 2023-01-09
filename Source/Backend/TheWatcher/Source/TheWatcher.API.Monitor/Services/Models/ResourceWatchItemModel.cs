using TheWatcher.Library.Core;

namespace TheWatcher.API.Monitor.Services.Models
{
    public class ResourceWatchItemModel
    {
        public ResourceWatchItemModel()
        {
            Param = new();
        }

        public short? Id { get; set; }
        public string? Resource { get; set; }
        public string? ResourceCategory { get; set; }
        public string? AssemblyQualifiedName { get; set; }
        public string? Environment { get; set; }
        public double? Interval { get; set; }

        public WatcherParam? Param { get; set; }
    }
}
