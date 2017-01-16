using System;
using System.Collections.Generic;

namespace ServiceMonitor.Responses
{
    public class ListViewModelResponse<TModel> : IListViewModelResponse<TModel> where TModel : class
    {
        public ListViewModelResponse()
        {
        }

        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
