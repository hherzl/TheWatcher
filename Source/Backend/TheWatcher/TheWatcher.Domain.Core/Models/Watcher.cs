using System.Collections.ObjectModel;
using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
	public partial class Watcher : IEntity
	{
		public Watcher()
		{
		}

		public Watcher(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }

		public string? AssemblyQualifiedName { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public bool? Active { get; set; }

		public string? CreationUser { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public string? LastUpdateUser { get; set; }

		public DateTime? LastUpdateDateTime { get; set; }

		public byte[] Version { get; set; }

		public virtual Collection<WatcherParameter> WatcherParameterList { get; set; }

		public virtual Collection<ResourceCategory> ResourceCategoryList { get; set; }
	}
}
