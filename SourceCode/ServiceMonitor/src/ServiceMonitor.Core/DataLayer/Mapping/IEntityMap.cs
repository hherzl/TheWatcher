using Microsoft.EntityFrameworkCore;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
