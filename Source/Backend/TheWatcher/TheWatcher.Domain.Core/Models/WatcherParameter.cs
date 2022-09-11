using System.Collections.ObjectModel;
using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
	public partial class WatcherParameter : IEntity
	{
		public WatcherParameter()
		{
		}

		public WatcherParameter(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }

		public short? WatcherId { get; set; }

		public string? Parameter { get; set; }

		public string? Value { get; set; }

		public bool? IsDefault { get; set; }

		public string? Description { get; set; }

		public bool? Active { get; set; }

		public string? CreationUser { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public string? LastUpdateUser { get; set; }

		public DateTime? LastUpdateDateTime { get; set; }

		public byte[] Version { get; set; }

		public virtual Watcher WatcherFk { get; set; }
	}
}
