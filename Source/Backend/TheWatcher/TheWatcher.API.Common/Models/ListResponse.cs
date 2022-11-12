namespace TheWatcher.API.Common.Models
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string? Message { get; set; }

        public bool? Failed { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
