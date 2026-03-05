namespace DataModel.Models.Middleware
{
    public class ResultInfo
    {
        public ResultInfo()
        {
            Code = 100;
        }

        public ResultInfo(string message)
        {
            Code = 100;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }

    public class ResultAPIInfo
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}