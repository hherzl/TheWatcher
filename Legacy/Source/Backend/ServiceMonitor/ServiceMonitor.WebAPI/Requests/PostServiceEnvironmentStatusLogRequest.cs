namespace ServiceMonitor.WebAPI.Requests
{
#pragma warning disable CS1591
    public class PostServiceEnvironmentStatusLogRequest
    {
        public int? ServiceEnvironmentStatusLogID { get; set; }

        public int? ServiceEnvironmentStatusID { get; set; }

        public short? ServiceEnvironmentID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Successful { get; set; }

        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }
    }
#pragma warning restore CS1591
}
