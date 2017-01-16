using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class UserMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.ToTable("User");

            entity.HasKey(p => p.UserID);

            entity.Property(p => p.UserID).UseSqlServerIdentityColumn();
        }
    }
}
