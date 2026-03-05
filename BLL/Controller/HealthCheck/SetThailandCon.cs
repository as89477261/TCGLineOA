using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.SetThailand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.HealthCheck
{
    public class SetThailandCon
    {
        private SetThailandCon() 
        { 
        }

        public static SetThailandCon Instance { get; } = new SetThailandCon();


        public BaseModel<string> InsertSetThailandLog(SetThailandLogModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new SetThaiLandRepo();
                var bufferResult = buffer.InsertUIDMapSetThailandLog(obj); 
                if (bufferResult != "")
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex) 
            {
                result.SetException(ex);
                return result;
            }
        }
    }

   
}
