using System;
using System.Threading.Tasks;
using Npgsql;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common.Watchers
{
    public class PostgreSqlDatabaseWatcher : IWatcher
    {
        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatchResponse> WatchAsync(WatcherParameter parameter)
        {
            var response = new WatchResponse();

            using (var connection = new NpgsqlConnection(parameter.Values["ConnectionString"]))
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
