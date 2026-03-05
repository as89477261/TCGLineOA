namespace DataModel.Models.Line
{
    public class LineOAuthTokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string id_token { get; set; }
        public LineRawTokenModel lineRawTokenObject { get; set; }


        public void DecodeToRawData()
        {
            var bufferRawTokenObj = JWTManager.GetTokenInfo(id_token);
            lineRawTokenObject = bufferRawTokenObj.ToObjectFromDictionary<LineRawTokenModel>();
        }

    }
}