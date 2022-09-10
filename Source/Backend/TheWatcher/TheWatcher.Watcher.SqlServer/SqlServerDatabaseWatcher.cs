using Microsoft.Data.SqlClient;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watcher.SqlServer
{
    public class SqlServerDatabaseWatcher : IWatcher
    {
        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatchResponse> WatchAsync(WatcherParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var response = new WatchResponse();

            using (var connection = new SqlConnection(parameter.Values[WatcherParameter.ConnectionString]))
            {
                try
                {
                    await connection.OpenAsync();

                    response.Successful = true;
                }
                catch (Exception ex)
                {
                    response.ShortMessage = ex.Message;
                    response.FullMessage = ex.ToString();
                }
            }

            return response;
        }
    }
}
