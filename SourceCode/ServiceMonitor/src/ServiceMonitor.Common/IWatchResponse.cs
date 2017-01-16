using System;

namespace ServiceMonitor.Common
{
    public interface IWatchResponse
    {
        Boolean Success { get; set; }

        String Message { get; set; }

        String StackTrace { get; set; }
    }
}
