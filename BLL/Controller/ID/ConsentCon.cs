using CoreUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Controller.ID
{
    public class ConsentCon : BasePage
    {
        private static ConsentCon instance;
        private ConsentCon() { }

        public static ConsentCon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsentCon();
                }
                return instance;
            }
        }




    }
}
