using System.Collections.Generic;

namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public interface IListViewModelResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
