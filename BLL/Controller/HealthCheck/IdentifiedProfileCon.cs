using System;
using System.Collections.Generic;
using DAL.Repos.SMEClinic;
using DataModel.Models.SMEClinic;

namespace BLL.Controller.HealthCheck
{
    public class IdentifiedProfileCon
    {
        private IdentifiedProfileCon()
        {
        }

        public static IdentifiedProfileCon Instance { get; } = new IdentifiedProfileCon();

        public BaseModel<List<IdentifiedProfileModel>> GetIdentifiedProfileAll()
        {
            var result = new BaseModel<List<IdentifiedProfileModel>>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.GetIdentifiedProfileAll().ToListof<IdentifiedProfileModel>();
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

        public BaseModel<List<IdentifiedProfileModel>> GetIdentifiedProfileByID(string ID)
        {
            var result = new BaseModel<List<IdentifiedProfileModel>>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.GetIdentifiedProfileByID(ID).ToListof<IdentifiedProfileModel>();
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

        public BaseModel<List<IdentifiedProfileModel>> GetIdentifiedProfileByUID(string UID)
        {
            var result = new BaseModel<List<IdentifiedProfileModel>>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.GetIdentifiedProfileByUID(UID).ToListof<IdentifiedProfileModel>();
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

        public BaseModel<string> InsertUIDMapApproch(IdentifiedProfileModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.InsertIdentifiedProfile(obj);
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

        public BaseModel<string> UpdateIdentifiedProfileStep1(IdentifiedProfileModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.UpdateIdentifiedProfileStep1(obj);
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

        public BaseModel<string> UpdateIdentifiedProfileStep2(IdentifiedProfileModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.UpdateIdentifiedProfileStep2(obj);
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

        public BaseModel<string> UpdateIdentifiedProfileStep3_SendOTP(IdentifiedProfileModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.UpdateIdentifiedProfileStep3_SendOTP(obj);
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

        public BaseModel<string> UpdateIdentifiedProfileStep3_ReceiveOTP(IdentifiedProfileModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new IdentifiedProfileRepo();
                var bufferResult = buffer.UpdateIdentifiedProfileStep3_ReceiveOTP(obj);
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
    }
}