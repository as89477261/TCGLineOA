using System;

namespace OPEN_API_DL.Model
{
    public class LogRequestResponse
    {
        public string LogID { get; set; }

        public DateTime RequestTime { get; set; }
        public string Context { get; set; }
        public string RequestHost { get; set; }
        public string Request { get; set; }
        public string statusCode { get; set; }
        public string Response { get; set; }

        public DateTime ResponseTime { get; set; }
    }
}