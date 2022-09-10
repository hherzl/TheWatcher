namespace ServiceMonitor.Core.Business.Responses.Contracts
{
    public interface IResponse
    {
        string Message { get; set; }

        bool DidError { get; set; }

        string ErrorMessage { get; set; }
    }
}
