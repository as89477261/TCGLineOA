namespace TCG_CORE_MODEL.Model.NDIDConnext
{
    public class RequestDopaModel
    {
        public RequestDopaParameter data { get; set; }

        [AlphaFormatValidateField] public string service { get; set; }

        [AlphaFormatValidateField] public string ref1 { get; set; }

        [AlphaFormatValidateField] public string ref2 { get; set; }
    }

    public class RequestDopaParameter
    {
        [AlphaFormatValidateField] public string citizen_id { get; set; }

        [AlphaFormatValidateField] public string firstname { get; set; }

        [AlphaFormatValidateField] public string lastname { get; set; }

        [AlphaFormatValidateField] public string birthday { get; set; }

        [AlphaFormatValidateField("laserid")] public string laser { get; set; }
    }
}