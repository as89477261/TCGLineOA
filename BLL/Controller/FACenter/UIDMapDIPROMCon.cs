using DAL.Repos.FACenter;
using DataModel.Models.FACenter;
using DataModels.FACenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.FACenter
{
    public class UIDMapDIPROMCon
    {

        public static UIDMapDIPROMCon Instance { get; } = new UIDMapDIPROMCon();


        public BaseModel<DataSet> InsertUIDMapDIPROM(UIDMapDIPROMModel obj)
        {

            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                var bufferResult = buffer.InsertUIDMapDIPROM(obj); 
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

        public BaseModel<string> UpdateUIDMapDIPROM(Request_UIDMapDIPROMModel obj)
        {

            var result = new BaseModel<string>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                var bufferResult = buffer.UpdateUIDMapDIPROM(obj);
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

        public BaseModel<DataSet> UpdateReturnDataSetUIDMapDIPROM(Request_UIDMapDIPROMModel obj)
        {

            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                var bufferResult = buffer.UpdateReturnDataSetUIDMapDIPROM(obj);
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

        public BaseModel<List<UIDMapDIPROMModel>> GetUIDMapDIPROMEvent(string uid, string eventCode, string identityId)
        {
            var result = new BaseModel<List<UIDMapDIPROMModel>>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                //var bufferResult = buffer.GetUIDMapDIPROM(uid, eventCode , identityID).ToListof<UIDMapDIPROMModel>();
                var bufferResult = buffer.GetUIDMapDIPROM(uid,eventCode, identityId).ToListof<UIDMapDIPROMModel>();

                //var ss = buffer.GetImport(identityId).ToListof<UIDMapDIPROMModel>();

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

        public BaseModel<List<UidDataProfile>> GetProfileDiprom (string uid)
        {
            var result = new BaseModel<List<UidDataProfile>>();
            try
            {
                var buffer = new UidMapDIPROMRepo();

                var bufferResult = buffer.GetProfileDiprom(uid).ToListof<UidDataProfile>();

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

        public BaseModel<List<UIDMapDIPROMModel>> GetCheckUIDMapDIPROM(string identityId)
        {
            var result = new BaseModel<List<UIDMapDIPROMModel>>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                //var bufferResult = buffer.GetUIDMapDIPROM(uid, eventCode , identityID).ToListof<UIDMapDIPROMModel>();
                var bufferResult = buffer.GetCheckUIDMapDIPROM(identityId).ToListof<UIDMapDIPROMModel>();
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

        public BaseModel<List<Request_ImportRequest>> UpdateReturnDataSetLineScreeningImportRequest(int ID)
        {
            var result = new BaseModel<List<Request_ImportRequest>>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                var bufferResult = buffer.UpdateReturnDataSetLineScreeningImportRequest(ID).ToListof<Request_ImportRequest>();
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

        public BaseModel<string> InsertFromRegisterDiprom (FormRegisterFAInfo obj)
        {
            var result = new BaseModel<string>();
            try
            {
                obj.RequestTitle_Id = 9;
                obj.RequestTitle_Another = "โครงการ DIRPOM ลงทะเบียนรับคำปรึกษา FA Center เนื่องจากไม่ผ่านเงื่อนไข";
                var bufferRepo = new UidMapDIPROMRepo();
                var FATransID = bufferRepo.InsertDipromTransaction(obj, 0);
                if (!string.IsNullOrEmpty(FATransID))
                {
                    obj.FA_TransectionsId = int.Parse(FATransID);
                    obj.IsLoanMoney = true;
                    obj.LoanMoney = obj.LoanMoney;
                    obj.ObjectiveId = 3;
                    obj.Objective_Remark = "โครงการ Diprom ระบุชื่อวัตถุประสงค์เพื่อนำไปใช้ของการขอสินเชื่อ";
                    obj.RequestRemark = "มาจาก โครงการ DIRPOM ลงทะเบียนรับคำปรึกษา FA Center เนื่องจากไม่ผ่านเงื่อนไขการเข้าร่วม ";
                    //obj.InterestLoanOfBank = "02"; //Bank Code 

                    var FormRegisterID = bufferRepo.InsertDipromFormRegister(obj);

                    if(!string.IsNullOrEmpty(FormRegisterID))
                    {
                        result.RESULT_OBJ = FATransID;
                        result.SetSuccess();
                    }

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


        public BaseModel<DataSet> UpdateTransConsultFA(UpdateTransConsultFA obj)
        {

            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new UidMapDIPROMRepo();
                var bufferResult = buffer.UpdateTransConsultFA(obj);
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
        public BaseModel<List<DipromImportRequest>> GetImport(string uid, string identityId)
        {
            var result = new BaseModel<List<DipromImportRequest>>();
            try
            {
                var buffer = new UidMapDIPROMRepo();

                var bufferResult = buffer.GetImport(uid, identityId).ToListof<DipromImportRequest>();

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
