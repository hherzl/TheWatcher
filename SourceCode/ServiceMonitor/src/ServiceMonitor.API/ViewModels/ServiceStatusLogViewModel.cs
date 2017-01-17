using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceStatusLogViewModel
    {
        public ServiceStatusLogViewModel()
        {
        }

        public Int32? ServiceStatusLogID { get; set; }

        public Int32? ServiceID { get; set; }

        public String Target { get; set; }

        public String ActionName { get; set; }

        public Boolean? Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
