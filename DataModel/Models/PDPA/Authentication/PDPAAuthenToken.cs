using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.PDPA.Authentication
{
    public class PDPAAuthenToken
    {
        public string userNameOrEmailAddress { get; set; }
        public string password { get; set; }
    }
}
