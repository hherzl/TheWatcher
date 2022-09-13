using System.Collections.ObjectModel;
using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
	public partial class ResourceCategory : IEntity
	{
		public ResourceCategory()
		{
		}

		public ResourceCategory(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }

		public string? Name { get; set; }

		public short? WatcherId { get; set; }	

		public bool? Active { get; set; }

		public string? CreationUser { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public string? LastUpdateUser { get; set; }

		public DateTime? LastUpdateDateTime { get; set; }

		public byte[] Version { get; set; }

		public virtual Watcher WatcherFk { get; set; }

		public virtual Collection<Resource> ResourceList { get; set; }
	}
}
