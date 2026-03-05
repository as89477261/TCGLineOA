namespace DataModel.Models.MasterData
{
    public class IndustryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BucketCorporate { get; set; }
        public int BucketPersonal { get; set; }
        public string IndustryGroup { get; set; }
    }
}