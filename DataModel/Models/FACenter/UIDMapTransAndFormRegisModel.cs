using System;

namespace DataModel.Models.FACenter
{
    public class UIDMapTransAndFormRegisModel
    {
        public string UID { get; set; }
        public int ApplicationId { get; set; }
        public int CustomerProfileId { get; set; }
        public int ChannelId { get; set; }
        public int ConsultantId { get; set; }
        public int CurrentStatusId { get; set; }
        public string Remark { get; set; }
        public int RequestTitle_Id { get; set; }
        public string RequestTitle_Another { get; set; }
        public int FA_TransectionsId { get; set; }
        public int Dept_Recon_ObjectId { get; set; }
        public string Dept_Recon_Money { get; set; }
        public bool IsDept_Recon { get; set; }
        public int FormID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CurrentStatusName { get; set; }
        public int GroupStatusID { get; set; }

        public bool EndLevel { get; set; }
    }
}