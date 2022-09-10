using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
	public partial class ResourceWatcher : IEntity
	{
		public ResourceWatcher()
		{
		}

		public ResourceWatcher(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }

		public short? ResourceId { get; set; }

		public short? WatcherId { get; set; }

		public bool? Active { get; set; }

		public string? CreationUser { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public string? LastUpdateUser { get; set; }

		public DateTime? LastUpdateDateTime { get; set; }

		public byte[]? Version { get; set; }

		public virtual Resource ResourceFk { get; set; }

		public virtual Watcher WatcherFk { get; set; }
	}
}
