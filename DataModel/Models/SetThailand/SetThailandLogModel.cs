using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.SetThailand
{
    public class SetThailandLogModel
    {
        public string Uid { get; set; } 
        public string LogSetUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public bool StatusValid { get; set; }

    }
}
