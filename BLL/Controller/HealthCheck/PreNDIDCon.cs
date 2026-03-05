using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repos;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel.PreRequest;

namespace BLL.Controller.HealthCheck
{
    public class PreNDIDCon
    {
        private PreNDIDCon()
        {
        }

        public static PreNDIDCon Instance { get; } = new PreNDIDCon();

        public BaseModel<List<UIDMapNDIDPreRequest>> GetUIDMapNDIDPreRequest(string uid)
        {
            var result = new BaseModel<List<UIDMapNDIDPreRequest>>();
            try
            {
                var buffer = new PreNDIDRepo();
                var bufferResult = buffer.GetUIDMapNDIDPreRequest(uid).ToListof<UIDMapNDIDPreRequest>();
                if (bufferResult != null)
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

        public BaseModel<string> InsertUIDMapNDIDPreRequest(List<UIDMapNDIDPreRequest> lstObj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new PreNDIDRepo();
                var isSuccess = true;
                for (var i = 0; i < lstObj.Count; i++)
                {
                    //LocalLogManager.Logger(JsonConvert.SerializeObject(lstObj[i]));


                    var bufferResult = buffer.InsertUIDMapNDIDPreRequest(lstObj[i]);
                    if (bufferResult == "") isSuccess = false;
                }

                if (isSuccess)
                {
                    result.RESULT_OBJ = "SUCCESS";
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

        public BaseModel<string> InsertUIDMapNDIDPreRequestHistory(UIDMapNDIDPreRequestHistory obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new PreNDIDRepo();
                var bufferResult = buffer.InsertUIDMapNDIDPreRequestHistory(obj);
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

        public BaseModel<string> InsertPreNDIDStatusAndUpdateNCBScoreToCyber(UIDMapPreRequestAndUpdateCyber obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var lstOnlineID = obj.T01OnlineID.Split('/');
                for (int i = 0; i < lstOnlineID.Count(); i++)
                {
                    if (lstOnlineID[i] != "")
                    {
                        obj.T01OnlineID = lstOnlineID[i];
                        var bufferCyber = new CyberRequestRepo();
                        var bufferCyberResult = bufferCyber.UpdateNCBScoreToRequest(obj);
                        if (bufferCyberResult != null)
                        {
                            var bufferPreRequest = new PreNDIDRepo();
                            var bufferPreRequestResult = bufferPreRequest.InsertUIDMapNDIDPreRequestOldNCB(obj);
                            if (bufferPreRequestResult != null)
                            {
                                result.RESULT_OBJ = "OK";
                                result.SetSuccess();
                            }
                            else
                            {
                                result.SetNotfound();
                            }
                        }
                        else
                        {
                            result.SetNotfound();
                        }
                    }
                   

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