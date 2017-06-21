using System;

namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public interface IResponse
    {
        String Message { get; set; }
        
        Boolean DidError { get; set; }
        
        String ErrorMessage { get; set; }
    }
}
