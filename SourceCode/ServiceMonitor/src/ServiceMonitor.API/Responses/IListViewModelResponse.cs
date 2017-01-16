using System.Collections.Generic;

namespace ServiceMonitor.Responses
{
    public interface IListViewModelResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
