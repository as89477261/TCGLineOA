using System;

namespace DataModel.Models.CustomerHealthModel.EventsModel
{
    public class FormEventRegisterOutputModel
    {
        public string EventCode { get; set; }
        public string UID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string RegisterID { get; set; }
        public string QuestionaireID { get; set; }
        public string BusinessType { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string Q5 { get; set; }
        public string Q6 { get; set; }
        public string Q7 { get; set; }
        public string Q8 { get; set; }
        public string Q9 { get; set; }
        public string Q10 { get; set; }
        public string Q11 { get; set; }
        public string Q12 { get; set; }
        public string Q13 { get; set; }
        public string Q14 { get; set; }
        public string Q15 { get; set; }
        public string Q16 { get; set; }
        public string Q17 { get; set; }
        public string Q18 { get; set; }
        public string Q19 { get; set; }
        public string Q20 { get; set; }
        public string EventName { get; set; }
        public string CallCenterStatus { get; set; } = "1";
    }
}