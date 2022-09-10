using System.Collections.ObjectModel;
using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
	public partial class Resource : IEntity
	{
		public Resource()
		{
		}

		public Resource(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }

		public string? Name { get; set; }

		public short? ResourceCategoryId { get; set; }

		public bool? Active { get; set; }

		public string? CreationUser { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public string? LastUpdateUser { get; set; }

		public DateTime? LastUpdateDateTime { get; set; }

		public byte[]? Version { get; set; }

		public virtual ResourceCategory ResourceCategoryFk { get; set; }

		public virtual Collection<ResourceWatch> ResourceWatchList { get; set; }

		public virtual Collection<ResourceWatcherParameter> ResourceWatcherParameterList { get; set; }

		public virtual Collection<ResourceWatcher> ResourceWatcherList { get; set; }
	}
}