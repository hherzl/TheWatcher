using TheWatcher.API.Common.Models.Contracts;

namespace TheWatcher.API.Common.Models
{
    public class SingleResponse<TModel> : Response, ISingleResponse<TModel>
    {
        public TModel Model { get; set; }
    }
}
