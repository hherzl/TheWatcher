namespace TheWatcher.API.Common.Models
{
    public class Response : IResponse
    {
        public string? Message { get; set; }

        public bool? Failed { get; set; }
    }
}
