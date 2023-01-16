using TheWatcher.API.Common.Models.Contracts;

namespace TheWatcher.API.Common.Models
{
    public class ListResponse<TModel> : Response, IListResponse<TModel>
    {
        public IEnumerable<TModel> Model { get; set; }
    }
}
