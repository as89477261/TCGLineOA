using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.HealthCheck
{
    public class CheckRegisterCon
    {
        private CheckRegisterCon()
        {
        }

        public static CheckRegisterCon Instance { get; } = new CheckRegisterCon();
    }
}
