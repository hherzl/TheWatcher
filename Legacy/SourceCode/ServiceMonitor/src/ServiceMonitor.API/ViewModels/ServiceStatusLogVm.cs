using System;

namespace ServiceMonitor.API.ViewModels
{
    public class ServiceEnvironmentStatusLogVm
    {
        public Int32? ServiceEnvironmentStatusLogID { get; set; }

        public Int32? ServiceEnvironmentStatusID { get; set; }

        public Int32? ServiceEnvironmentID { get; set; }

        public String Target { get; set; }

        public String ActionName { get; set; }

        public Boolean? Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
