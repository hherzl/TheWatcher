using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common.Watchers
{
    public class SqlServerDatabaseWatcher : IWatcher
    {
        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatchResponse> WatchAsync(WatcherParameter parameter)
        {
            var response = new WatchResponse();

            using (var connection = new SqlConnection(parameter.Values["ConnectionString"]))
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
