using Microsoft.Data.SqlClient;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watcher.SqlServer
{
    public class SqlServerDatabaseWatcher : IWatcher
    {
        private static readonly Guid ClassGuid = new("A1059C4E-1615-49EB-993D-274458DD212B");

        public Guid Guid
            => ClassGuid;

        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatcherResult> WatchAsync(WatcherParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var result = new WatcherResult();

            using var cnn = new SqlConnection(parameter.Values[WatcherParameter.ConnectionString]);

            try
            {
                await cnn.OpenAsync();

                result.Successful = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }
    }
}
