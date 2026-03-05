using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.SetThailand
{
    public class SetThailandAPIAuthUserProfileModel
    {
        public SetThailandUserProfile user_profile {  get; set; }
    }
    public class SetThailandUserProfile
    {
        public string id { get; set; }

        public string email { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string gender { get; set; }

        public string phone_number { get; set; }

        public string company_name { get; set; }

        public string corporate_number { get; set; }

    }
}
