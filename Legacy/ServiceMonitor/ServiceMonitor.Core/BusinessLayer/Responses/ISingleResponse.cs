namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public interface ISingleResponse<TModel> : IResponse where TModel : class
    {
        TModel Model { get; set; }
    }
}
