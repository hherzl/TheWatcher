using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public interface IEntityMapper
    {
        IEnumerable<IEntityMap> Mappings { get; }

        void MapEntities(ModelBuilder modelBuilder);
    }
}
