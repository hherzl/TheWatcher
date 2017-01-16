using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class DatabaseWatcher : IWatcher
    {
        public DatabaseWatcher()
        {
        }

        public String ActionName
        {
            get
            {
                return "OpenDatabaseConnection";
            }
        }

        public async Task<WatchResponse> Watch(WatcherParameter parameter)
        {
            var value = await Task.Run(() =>
            {
                var response = new WatchResponse();

                using (var connection = new SqlConnection(parameter.Values["ConnectionString"]))
                {
                    try
                    {
                        connection.Open();

                        response.Success = true;
                    }
                    catch (Exception ex)
                    {
                        response.Success = false;
                        response.Message = ex.Message;

                        response.StackTrace = ex.StackTrace;
                    }
                }

                return response;
            });

            return value;
        }
    }
}
