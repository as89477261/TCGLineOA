using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Controller.HealthCheck;
using BLL.Controller.Middleware;
using DataModel.Models;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller
{
    public class EmailTemplate : BasePage
    {
        private EmailTemplate()
        {
        }

        public static EmailTemplate Instance { get; } = new EmailTemplate();

        public string GetTemplateFromFile()
        {
            var pathFileMailTemplate = GetAppsetting("MailTemplatePath");
            var text = File.ReadAllText(pathFileMailTemplate);

            return text;
        }

        public List<ApprochMapBankModel> BindingEmail(string emailTemplate, List<ApprochMapBankModel> obj)
        {
            if (emailTemplate != null)
                for (var i = 0; i < obj.Count; i++)
                    if (obj[i].BankEmail != "")
                    {
                        emailTemplate = emailTemplate.Replace("@", "");
                        emailTemplate = emailTemplate.Replace("@", "");
                        emailTemplate = emailTemplate.Replace("@", "");
                        emailTemplate = emailTemplate.Replace("@", "");


                        obj[i].ApprochBody = emailTemplate;
                        SendMail(emailTemplate, obj[i].BankEmail);
                    }


            return obj;
        }

        public void BindingInternalEmail(string emailTemplate)
        {
            var rawEmail = GetAppsetting("InternalEmail");
            if (rawEmail != "")
            {
                var internalEmail = rawEmail.Split('|');

                if (emailTemplate != null && internalEmail != null)
                    for (var i = 0; i < internalEmail.Length; i++)
                    {
                        emailTemplate = emailTemplate.Replace("@", "");
                        emailTemplate = emailTemplate.Replace("@", "");
                        emailTemplate = emailTemplate.Replace("@", "");
                        emailTemplate = emailTemplate.Replace("@", "");

                        SendMail(emailTemplate, internalEmail[i]);
                    }
            }
        }

        public void BindingCustomerEmail(string emailTemplate, string customerEmail)
        {
            var internalEmail = GetAppsetting("InternalEmail").Split('|');

            if (emailTemplate != null && internalEmail != null)
                for (var i = 0; i < internalEmail.Length; i++)
                {
                    emailTemplate = emailTemplate.Replace("@", "");
                    emailTemplate = emailTemplate.Replace("@", "");
                    emailTemplate = emailTemplate.Replace("@", "");
                    emailTemplate = emailTemplate.Replace("@", "");

                    SendMail(emailTemplate, customerEmail);
                }
        }

        public string AppendBankChoosedList(string emailTemplate, List<ApprochMapBankModel> obj)
        {
            var listMail = "<h5 class=''>4.แบงค์ที่ลงทะเบียน</h5>";
            foreach (var item in obj)
            {
                var bufferBank = BankCon.Instance.GetBankProfile(item.BankCode);
                listMail += bufferBank.RESULT_OBJ.FirstOrDefault().BankName + "<br />";
            }

            return listMail;
        }

        public async Task SendMail(string EmailTemplate, string email)
        {
            try
            {
                // ขออนุญาตเพิ่ม Code ครับ              


                if (EmailTemplate != null && email != null)
                {
                    EmailTemplate = EmailTemplate.Replace("@URL", GetAppsetting("TCGContactURL"));
                    var emailInfo = new EmailInfo
                    {
                        Body = EmailTemplate,
                        Sender = "noreply@tcg.or.th",
                        CCEmail = "",
                        Email = email,
                        Subject = GetAppsetting("EmailTemplateHeader")
                    };

                    var bufferToken = APIAuthenCon.Instance.GetAuthenToken();

                    var result = await EmailCon.Instance.SendMail(emailInfo, bufferToken);
                }
            }
            catch (Exception ex)
            {
                // แก้เฉพาะกิต
            }
        }


    }
}