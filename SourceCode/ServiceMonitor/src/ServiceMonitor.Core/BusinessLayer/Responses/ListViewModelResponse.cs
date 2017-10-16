using System;
using System.Collections.Generic;

namespace ServiceMonitor.Core.BusinessLayer.Responses
{
    public class ListResponse<TModel> : IListResponse<TModel> where TModel : class
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
