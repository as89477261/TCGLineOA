using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TCGScoreCon
    {
        private static TCGScoreCon instance = new TCGScoreCon();
        private TCGScoreCon() { }
        public static TCGScoreCon Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
