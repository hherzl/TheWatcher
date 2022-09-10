namespace ServiceMonitor.Clients
{
    public static class ApiUrlExtensions
    {
        public static ApiUrl Controller(this ApiUrl apiUrl, string controller)
        {
            apiUrl.Controller = controller;

            return apiUrl;
        }

        public static ApiUrl Action(this ApiUrl apiUrl, string action)
        {
            apiUrl.Action = action;

            return apiUrl;
        }

        public static ApiUrl ID(this ApiUrl apiUrl, string id)
        {
            apiUrl.Id = id;

            return apiUrl;
        }

        public static ApiUrl ID(this ApiUrl apiUrl, int id)
        {
            apiUrl.Id = id.ToString();

            return apiUrl;
        }
    }
}
