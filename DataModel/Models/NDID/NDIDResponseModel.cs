namespace DataModel.Models.NDID
{
    public class NDIDResponseModel
    {
        public string request_id { get; set; }

        public string initial_salt { get; set; }
        //public string transaction_id { get; set; }
        //public string request_data { get; set; } // ข้อมูลที่ได้รับจาก AS
        //public string request { get; set; } // ข้อมูล request detail จาก NDID platform
        //public string identity { get; set; } // เลข identifier
        //public string reference_id { get; set; } // reference_id ของ request นั้นๆ(ถูก generate โดย e-form)
        //public string pid { get; set; }// อันนี้อ้างอิงจากชุด code ที่ใช้กับระบบของ RP 
    }
}