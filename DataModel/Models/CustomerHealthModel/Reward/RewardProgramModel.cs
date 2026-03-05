using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.CustomerHealthModel.Reward
{
    public class RewardProgramModel
    {
        public int ID { get; set; }
        public string RewardOwner { get; set; }
        public string TitleProgram { get; set; }
        public string DescriptionProgram { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string LogoProgramPath { get; set; }
        public string DetailTitle { get; set; }
        public string DetailDescription { get; set; }
        public string DetailCondition { get; set; }
        public string DetailEndDate { get; set; }
        public string DetailUseCase { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string RewardOwnerCode { get; set; }
        public string RewardProgram { get; set; }
        public string RewardProgramCode { get; set; }




    }
}
