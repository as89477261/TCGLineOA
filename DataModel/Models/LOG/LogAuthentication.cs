namespace OPEN_API_MODELS.Model.LOG
{
    public class LogAuthentication
    {
        public LogAuthentication()
        {
            status = "FAIL";
        }

        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string sys_id { get; set; }
        public string ip { get; set; }
        public string user_id { get; set; }
        public string token { get; set; }
        public string status { get; set; }
    }
}