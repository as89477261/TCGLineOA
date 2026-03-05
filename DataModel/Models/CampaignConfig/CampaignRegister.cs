using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.CampaignConfig
{
    public class CampaignRegister
    {
        public DateTime registerDate { get; set; }
        public Customer customer { get; set; }
        public Campaign campaign { get; set; }
    }
}
