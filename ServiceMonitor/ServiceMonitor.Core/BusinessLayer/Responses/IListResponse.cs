using System.Collections.Generic;

namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public interface IListResponse<TModel> : IResponse where TModel : class
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
