using Microsoft.Data.SqlClient;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watcher.SqlServer
{
    public class SqlServerDatabaseWatcher : IWatcher
    {
        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatcherResult> WatchAsync(WatcherParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var result = new WatcherResult();

            using (var connection = new SqlConnection(parameter.Values[WatcherParameter.ConnectionString]))
            {
                try
                {
                    await connection.OpenAsync();

                    result.Successful = true;
                }
                catch (Exception ex)
                {
                    result.ShortMessage = ex.Message;
                    result.FullMessage = ex.ToString();
                }
            }

            return result;
        }
    }
}
