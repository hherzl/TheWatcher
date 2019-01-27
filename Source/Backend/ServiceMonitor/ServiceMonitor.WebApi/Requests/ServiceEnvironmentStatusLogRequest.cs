using System;

namespace ServiceMonitor.WebAPI.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceEnvironmentStatusLogRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public int? ServiceEnvironmentStatusLogID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ServiceEnvironmentStatusID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ServiceEnvironmentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date { get; set; }
    }
}
