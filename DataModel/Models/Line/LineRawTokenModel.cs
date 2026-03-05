namespace DataModel.Models.Line
{
    public class LineRawTokenModel
    {
        [AlphaFormatValidateField] public string iss { get; set; }

        [AlphaFormatValidateField] public string sub { get; set; }

        [AlphaFormatValidateField] public string aud { get; set; }

        [AlphaFormatValidateField] public string exp { get; set; }

        [AlphaFormatValidateField] public string iat { get; set; }

        [AlphaFormatValidateField] public string nonce { get; set; }

        [AlphaFormatValidateField] public string amr { get; set; }

        //[AlphaFormatValidateField] public string name { get; set; }
        public string name { get; set; }

        [AlphaFormatValidateField("htmlpath")] public string picture { get; set; }

        [AlphaFormatValidateField("email")] public string email { get; set; }

        [AlphaFormatValidateField] public bool IsExist { get; set; }
    }
}