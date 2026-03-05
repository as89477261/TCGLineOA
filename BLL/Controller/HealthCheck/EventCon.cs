using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BLL.Controller.Middleware;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models;
using DataModel.Models.CustomerHealthModel.EventsModel;

namespace BLL.Controller.HealthCheck
{
    public class EventCon : BasePage
    {
        private EventCon()
        {
        }

        public static EventCon Instance { get; } = new EventCon();

        public BaseModel<List<EventBannerModel>> GetUIDRegisterPartner(string uid, string Status)
        {
            var result = new BaseModel<List<EventBannerModel>>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.GetUIDRegisterPartner(uid, Status).ToListof<EventBannerModel>();
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

        public BaseModel<List<EventModel>> GetEvents()
        {
            var result = new BaseModel<List<EventModel>>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.GetEvents().ToListof<EventModel>();
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

        public BaseModel<List<EventModel>> GetEventByEventCode(string code)
        {
            var result = new BaseModel<List<EventModel>>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.GetEventByID(code).ToListof<EventModel>();
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

        public BaseModel<List<EventModel>> GetEventByType(string typeCode)
        {
            var result = new BaseModel<List<EventModel>>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.GetEventByType(typeCode).ToListof<EventModel>();
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

        public BaseModel<string> InsertFormEventRegister(FormEventRegisterInputModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.InsertFormEventRegister(obj);
                if (bufferResult != null)
                {
                    Task.Run(() =>
                    {
                        var resultEmail = PassDataToCustomerByEmail(obj);
                    });

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

        public BaseModel<string> InsertFormEventRegisterDynamic(FormEventRegisterDynamicInputModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.InsertFormEventRegisterDynamic(obj);
                if (bufferResult != null)
                {
                    Task.Run(() =>
                    {
                        var resultEmail = PassDataToCustomerByDynamicEmail(obj);
                    });

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

        public BaseModel<string> InsertFormEventRegisterDynamicNotSendEmail(FormEventRegisterDynamicInputModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.InsertFormEventRegisterDynamic(obj);
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

        public BaseModel<string> PassDataToCustomerByEmail(FormEventRegisterInputModel obj)
        {
            var result = new BaseModel<string>();

            var mail = new EmailInfo();
#if DEBUG
            mail.Email = obj.Email;
#else
            mail.Email = obj.Email;
#endif
            var random = new Random();
            var keys = GetAppsetting("KeysEveryone").Split(';');
            var strKey = keys[random.Next(1, 5) - 1];

            mail.Subject = GetAppsetting("MailToEventRegister_Title");
            var body = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MailToRegisterEvent_001.txt"), Encoding.UTF8);
            body = body.Replace("@Name", obj.FirstName + " " + obj.LastName);
            body = body.Replace("@Phone", obj.Phone);
            body = body.Replace("@Purpose", GenPurpose(obj.Purpose));
            body = body.Replace("@Link", GetAppsetting("LinkMeeting"));
            mail.Body = body;

            var bufferToken = APIAuthenCon.Instance.GetAuthenToken();
            var resultEmail = EmailCon.Instance.SendMail(mail, bufferToken);
            resultEmail.Wait();

            result.SetSuccess();
            return result;
        }

        public BaseModel<string> PassDataToCustomerByDynamicEmail(FormEventRegisterDynamicInputModel obj)
        {
            var result = new BaseModel<string>();

            var mail = new EmailInfo();
#if DEBUG
            mail.Email = obj.Email;
#else
            mail.Email = obj.Email;
#endif
            var random = new Random();
            var keys = GetAppsetting("KeysEveryone").Split(';');
            var strKey = keys[random.Next(1, 5) - 1];

            mail.Subject = GetAppsetting("MailToEventRegister_Title");
            var body = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplate/" + obj.EventCode + ".txt"),
                Encoding.UTF8);
            body = body.Replace("@Name", obj.FirstName + " " + obj.LastName);
            body = body.Replace("@Phone", obj.Phone);
            body = body.Replace("@Link", GetAppsetting("LinkMeeting"));
            mail.Body = body;

            var bufferToken = APIAuthenCon.Instance.GetAuthenToken();
            var resultEmail = EmailCon.Instance.SendMail(mail, bufferToken);
            resultEmail.Wait();

            result.SetSuccess();
            return result;
        }

        private string GenPurpose(string code)
        {
            switch (code)
            {
                case "001":
                    return "หมุนเวียนในกิจการ";
                case "002":
                    return "ลงทุนในกิจการ";
                case "003":
                    return "Refinance";
                default:
                    return "";
            }
        }
    }
}