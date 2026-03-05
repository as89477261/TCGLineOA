using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.CustomerHealthModel.Reward
{
    public class RewardConditionModel
    {
        public string UID { get; set; }
        public int isHC { get; set; }
        public int isSubTypeInfo{ get; set; }

        public string isCampaign { get; set; }
        public string isEnroll { get; set; }
        public string isFACenter { get; set; }
        public string is3Color { get; set; }

        public string isRemark { get; set; }       


    }
}
