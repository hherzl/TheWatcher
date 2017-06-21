using System;

namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public class SingleViewModelResponse<TModel> : ISingleViewModelResponse<TModel> where TModel : class
    {
        public SingleViewModelResponse()
        {
        }
        
        public String Message { get; set; }
        
        public Boolean DidError { get; set; }
        
        public String ErrorMessage { get; set; }
        
        public TModel Model { get; set; }
    }
}
