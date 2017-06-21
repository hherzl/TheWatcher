namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public interface ISingleViewModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
