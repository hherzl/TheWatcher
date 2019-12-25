using System.Collections.Generic;

namespace ServiceMonitor.Core.Business.Responses.Contracts
{
    public interface IListResponse<TModel> : IResponse where TModel : class
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
