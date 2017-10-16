using System;

namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : class
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
