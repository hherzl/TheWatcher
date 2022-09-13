using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
    public class ResourceWatchLog : IEntity
    {
        public ResourceWatchLog()
        {
        }

        public ResourceWatchLog(short? id)
        {
            Id = id;
        }

        public short? Id { get; set; }

        public short? ResourceWatchId { get; set; }

        public string? AssemblyQualifiedName { get; set; }

        public string? ActionName { get; set; }

        public bool? Successful { get; set; }

        public string? Message { get; set; }

        public string? ErrorMessage { get; set; }

        public bool? Active { get; set; }

        public string? CreationUser { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public string? LastUpdateUser { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        public byte[] Version { get; set; }

        public virtual ResourceWatch ResourceWatchFk { get; set; }
    }
}
