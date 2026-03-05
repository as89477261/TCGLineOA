using DataModel.Models;
using LineOASafeGuard.Internal_BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient; // NuGet: System.Data.SqlClient
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LineOASafeGuard
{
    // คลาสสำหรับเก็บข้อมูลลูกค้าที่ดึงมาจากฐานข้อมูล
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ServiceName { get; set; }
        public DateTime DueDate { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("เริ่มต้นโปรแกรมส่งอีเมล...");

            try
            {
                // 2.1 สร้างเนื้อหาอีเมล (ฟอร์ม)
                string emailSubject = $"แจ้งเตือน: บริการของคุณกำลังจะหมดอายุ";
                string emailBody = EmailTemplateController.Instance.CretaeEmailTemplate();
                string emailList = ConfigurationManager.AppSettings["EmailList"];

                // 2.2 ส่งอีเมล
                //SendEmail(customer.Email, emailSubject, emailBody);
                var emailInfo = new EmailInfo
                {
                    Body = emailBody,
                    Sender = "noreply@tcg.or.th",
                    CCEmail = "",
                    Email = emailList,
                    Subject = "รายงาน Line OA TCGFirst ประจำวันที่ " + DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("th-TH"))
                };

                var bufferToken = ApiAuthInterface.Instance.GetAuthToken();
                var Result = EmailInterface.Instance.SendMail(emailInfo, bufferToken);

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"เกิดข้อผิดพลาดที่ไม่คาดคิด: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nโปรแกรมทำงานเสร็จสิ้น กดปุ่มใดๆ เพื่อปิด");
            Console.ReadKey();
        }

    }
}
