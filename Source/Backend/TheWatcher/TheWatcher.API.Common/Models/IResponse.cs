namespace TheWatcher.API.Common.Models
{
    public interface IResponse
    {
        string? Message { get; set; }

        bool? Failed { get; set; }
    }
}
