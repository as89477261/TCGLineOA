using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL.Controller.Middleware;
using DAL.FACenter;
using DAL.Repos.FACenter;
using DataModel.Models;
using DataModel.Models.FACenter;
using DataModels.FACenter;

namespace BLL.Controller.FACenter
{
    public class FormRegisterFACon : BasePage
    {
        private FormRegisterFACon()
        {
        }

        public static FormRegisterFACon Instance { get; } = new FormRegisterFACon();

        public BaseModel<string> InsertFATransections(FormRegisterFAInfo obj, int consultID = 0)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new FormRegisterFARepo();
                var bufferResult = buffer.InsertFATransections(obj, consultID);
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

        private string ReplaceNewlines(string blockOfText, string replaceWith)
        {
            return blockOfText.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        }

        public BaseModel<string> InsertFormRegister(FormRegisterFAInfo obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var bufferRepo = new FormRegisterFARepo();
                var FATransID = bufferRepo.InsertFATransections(obj, 0);
                if (!string.IsNullOrEmpty(FATransID))
                {
                    obj.FA_TransectionsId = int.Parse(FATransID);
                    var FormRegisterID = bufferRepo.InsertFormRegister(obj);
                    if (!string.IsNullOrEmpty(FormRegisterID))
                    {
                        var bufferUIDRepo = new UIDMapFATransactionRepo();
                        var objUID = new UIDMapTransactionModel { UID = obj.UID, TransactionID = FATransID };
                        var resultUID = bufferUIDRepo.InsertUIDMapTransaction(objUID);

                        if (resultUID != null)
                        {
                            /******************** วิ่งไปเช็คข้อมูลเจ้าหน้าที่ ที่รับผิดชอบติดตามลูกหนี้ในระบบ DCS ถ้าพบข้อมูลให้สร้าง สถานะงานเป็นส่งต่อ/ที่ปรึกษา และส่งเมล์แจ้ง *************/
                            /******************** ไม่ต้องรอผล ให้ทำงานต่อไปเลย ให้หลังบ้านทำงานต่อ ****************/
                            Task.Run(() =>
                            {
                                if (!string.IsNullOrEmpty(obj.FA_Ref))
                                {
                                    var row = EmployeeDCSCon.Instance.GetEmployeeWithDept_In_DCS(obj.FA_Ref);
                                    if (row != null)
                                        if (row.RESULT_CODE == "200" && row.RESULT_OBJ.Count > 0 &&
                                            row.RESULT_OBJ[0].ConsultantId > 0)
                                        {
                                            /*********** Update ที่ปรึกษากลับเข้าระบบ และ Create History *******/
                                            var updateFATransStatus =
                                                TransactionFACon.Instance.UpdateFA_Transections_Dept(
                                                    int.Parse(FATransID),
                                                    row.RESULT_OBJ[0].ConsultantId,
                                                    row.RESULT_OBJ[0].DebtorCode,
                                                    row.RESULT_OBJ[0].LGNumber,
                                                    81);

                                            /*********** Send Mail *********/
                                            PassDataToConsultByEmail(FATransID);
                                        }
                                }
                            });
                            result.RESULT_OBJ = resultUID != "0" ? "Success" : "Fail";
                            result.SetSuccess();
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

        public BaseModel<string> PassDataToConsultByEmail(string transID)
        {
            var result = new BaseModel<string>();

            var repo = new TransactionFARepo();
            var buffer = repo.GetFATransections(transID).ToListof<MainTransectionInfo>();
            if (buffer != null && buffer.Count > 0)
            {
                if (buffer[0].Consultant_Email != null)
                {
                    var mail = new EmailInfo();
#if DEBUG
                    mail.Email = "nuttaphon@tcg.or.th";
#else
                        mail.Email = buffer[0].Consultant_Email;
#endif
                    var random = new Random();
                    var keys = GetAppsetting("KeysEveryone").Split(';');
                    var strKey = keys[random.Next(1, 5) - 1];

                    mail.Subject = string.Format(GetAppsetting("MailToConsult_Title"), buffer[0].CustomerName,
                        buffer[0].Mobile);
                    var body = File.ReadAllText(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MailToConsult.txt"), Encoding.UTF8);
                    mail.Body = string.Format(ReplaceNewlines(body, "<br />"),
                        buffer[0].ConsultantName, buffer[0].CustomerName, buffer[0].Mobile, buffer[0].Id,
                        buffer[0].ConsultantId, buffer[0].ApplicationId, strKey);

                    var bufferToken = APIAuthenCon.Instance.GetAuthenToken();
                    var resultEmail = EmailCon.Instance.SendMailToConsult(int.Parse(transID), mail, bufferToken);
                    resultEmail.Wait();

                    result.SetSuccess();
                }
                else
                {
                    result.RESULT_MESSAGE = "ไม่พบอีเมล์ของที่ปรึกษาในระบบ";
                    result.SetNotfound();
                }
            }

            return result;
        }

        public BaseModel<string> InsertFormRegisterCompromise(FormRegisterFAInfo obj, string Id, string DummyID)
        {
            var result = new BaseModel<string>();
            try
            {
                obj.RequestTitle_Id = 9;
                obj.RequestTitle_Another = "ลงทะเบียนเข้ารวมมาตรการรัฐ พักชำระหนี้กับบสย.";
                var bufferRepo = new DebtCompromiseRegisterFARepo();
                var FATransID = bufferRepo.InsertDebtTransections(obj, 0);
                if (!string.IsNullOrEmpty(FATransID))
                {
                    obj.FA_TransectionsId = int.Parse(FATransID);
                    obj.RequestRemark = "ลงทะเบียนเข้าร่วมมาตรการรัฐ พักชำระหนี้กับบสย. สำหรับ บน";
                    var FormRegisterID = bufferRepo.InsertDebtFormRegister(obj);
                    if (!string.IsNullOrEmpty(FormRegisterID))
                    {
                        obj.ApplicationId = 1;
                        obj.CurrentStatusId = 1;
                        obj.ChannelId = 3;
                        var FaTransConsultID = bufferRepo.InsertFATransections(obj, 0);
                        if (!string.IsNullOrEmpty(FaTransConsultID))
                        {
                            obj.FA_TransectionsId = int.Parse(FaTransConsultID); 
                            obj.RequestRemark = "ลงทะเบียนเข้าร่วมมาตรการรัฐ พักชำระหนี้กับบสย. สำหรับ FACenter";
                            var FormRegisterConsultID = bufferRepo.InsertFormRegister(obj);
                            if (!string.IsNullOrEmpty(FormRegisterConsultID))
                            {
                                var bufferUIDRepo = new UidMapFADeptRepo();
                                var objUID = new UIDMapDeptModel { Id = Guid.Parse(Id), Uid = obj.UID, DummyID = DummyID, TransIDCompromise = FATransID , TransIDConsult = FaTransConsultID};
                                var resultUID = bufferUIDRepo.UpdateUidMapDebtTrans(objUID);


                                if (resultUID != null)
                                {
                                    Task.Run(() =>
                                    {
                                        if (!string.IsNullOrEmpty(obj.FA_Ref))
                                        {
                                            var row = EmployeeDCSCon.Instance.GetEmployeeWithDept_In_DCS(obj.FA_Ref);
                                            if (row != null)
                                                if (row.RESULT_CODE == "200" && row.RESULT_OBJ.Count > 0 &&
                                                    row.RESULT_OBJ[0].ConsultantId > 0)
                                                {
                                                    /*********** Update ที่ปรึกษากลับเข้าระบบ และ Create History *******/
                                                    var updateFATransStatus =
                                                        TransactionFACon.Instance.UpdateFA_Transections_Dept(
                                                            int.Parse(FATransID),
                                                            row.RESULT_OBJ[0].ConsultantId,
                                                            row.RESULT_OBJ[0].DebtorCode,
                                                            row.RESULT_OBJ[0].LGNumber,
                                                            81);

                                                    /*********** Send Mail *********/
                                                    PassDataToConsultByEmail(FaTransConsultID);
                                                }
                                        }
                                    });
                                    result.RESULT_OBJ = resultUID != "0" ? FATransID : "Fail";
                                    result.SetSuccess();
                                }
                                else
                                {
                                    result.SetNotfound();
                                }
                            }
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