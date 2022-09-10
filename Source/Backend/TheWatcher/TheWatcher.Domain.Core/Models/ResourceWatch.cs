using TheWatcher.Domain.Common;

namespace TheWatcher.Domain.Core.Models
{
	public partial class ResourceWatch : IEntity
	{
		public ResourceWatch()
		{
		}

		public ResourceWatch(short? id)
		{
			Id = id;
		}

		public short? Id { get; set; }

		public short? ResourceId { get; set; }

		public short? EnvironmentId { get; set; }

		public int? Interval { get; set; }

		public string? Description { get; set; }

		public bool? Active { get; set; }

		public string? CreationUser { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public string? LastUpdateUser { get; set; }

		public DateTime? LastUpdateDateTime { get; set; }

		public byte[]? Version { get; set; }

		public virtual Resource ResourceFk { get; set; }

		public virtual Environment EnvironmentFk { get; set; }
	}
}
