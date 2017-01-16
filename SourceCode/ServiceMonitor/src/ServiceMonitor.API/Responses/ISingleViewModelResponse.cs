namespace ServiceMonitor.Responses
{
    public interface ISingleViewModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
