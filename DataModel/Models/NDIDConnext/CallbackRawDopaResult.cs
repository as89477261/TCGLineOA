using System.Xml.Serialization;

namespace TCG_CORE_MODEL.Model.NDIDConnext
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Envelope)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "CheckCardByLaserResult")]
    public class CheckCardByLaserResult
    {
        [XmlElement(ElementName = "IsError")] public bool IsError { get; set; }

        [XmlElement(ElementName = "ErrorMessage")]
        public object ErrorMessage { get; set; }

        [XmlElement(ElementName = "Code")] public int Code { get; set; }

        [XmlElement(ElementName = "Desc")] public string Desc { get; set; }
    }

    [XmlRoot(ElementName = "CheckCardByLaserResponse")]
    public class CheckCardByLaserResponse
    {
        [XmlElement(ElementName = "CheckCardByLaserResult")]
        public CheckCardByLaserResult CheckCardByLaserResult { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText] public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "CheckCardByLaserResponse")]
        public CheckCardByLaserResponse CheckCardByLaserResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body")] public Body Body { get; set; }

        [XmlAttribute(AttributeName = "soap")] public string Soap { get; set; }

        [XmlAttribute(AttributeName = "xsi")] public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd")] public string Xsd { get; set; }

        [XmlText] public string Text { get; set; }
    }
}