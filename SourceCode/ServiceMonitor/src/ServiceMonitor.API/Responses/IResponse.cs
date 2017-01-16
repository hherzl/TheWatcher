using System;

namespace ServiceMonitor.Responses
{
    public interface IResponse
    {
        String Message { get; set; }
        
        Boolean DidError { get; set; }
        
        String ErrorMessage { get; set; }
    }
}
