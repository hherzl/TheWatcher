using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common
{
    public class DatabaseWatcher : IWatcher
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

                    response.Success = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.StackTrace = ex.ToString();
                }
            }

            return response;
        }
    }
}
