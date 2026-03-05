using System;

namespace DataModel.Models.CustomerHealthModel.EventsModel
{
    public class EventModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public int MaxJoin { get; set; }
        public string OwnerDept { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public string Place { get; set; }
        public string PlaceDeatil { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string EventCode { get; set; }
        public string OnlineLink { get; set; }
        public string OnlineLinkBackUp { get; set; }
        public string SubTitle { get; set; }
        public bool IsShowRegisterButton { get; set; }
        public DateTime StartShowRegisterButton { get; set; }
        public DateTime EndShowRegisterButton { get; set; }
        public string TitleIcon { get; set; }
        public string TitleIconColor { get; set; }
        public bool IsBodyPicture { get; set; }
        public string BodyPicturePath { get; set; }
        public string Condition { get; set; }
        public string RegisterForm { get; set; }
        public bool IsCheckDuplicateRegister { get; set; }
    }
}