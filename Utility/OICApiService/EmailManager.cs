using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailManager
{
    public static void SendMail(string mailFrom, string mailTo, string subject, string body,
        string Host = "mail.oic.or.th", int port = 587, string username = "", string pass = "")
    {
        var client = new SmtpClient(Host, port)
        {
            Credentials = new NetworkCredential(
                username,
                pass),
            EnableSsl = false
        };

        client.Send(mailFrom, mailTo, subject, body);
    }

    public static void SendAAMail(string mailFrom, string mailTo, string subject, string body,
        string Host = "mail.oic.or.th", int port = 587, string username = "", string pass = "")
    {
        var client = new SmtpClient(Host, port)
        {
            Credentials = new NetworkCredential(
                username,
                pass),
            EnableSsl = false
        };
        client.SendMailAsync(mailFrom, mailTo, subject, body);
    }

    public void SendMail(MailMessage mail, string Host = "mail.oic.or.th", int port = 25, string username = "",
        string pass = "")
    {
        var client = new SmtpClient(Host, port)
        {
            Credentials = new NetworkCredential(
                username,
                pass),
            EnableSsl = false
        };
        client.Send(mail);
    }

    public static async Task SendEmail(MailMessage mail, string host = "mail.oic.or.th", int port = 25,
        string username = "", string pass = "")
    {
        var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(
                username,
                pass),
            EnableSsl = false
        };
        await client.SendMailAsync(mail);
    }

    public static string EmailTemplate()
    {
        var temp = @"<![CDATA[
      <div>
        <div>
          <strong style='font-size: 16px;line-height: 30px;'>เรียน คุณ </strong>
          <strong style='font-size: 16px;line-height: 30px;'>{name}</strong>
        </div>
        <br/>
        <div>
          <span style='padding-left: 35px;'></span>
          <span style='font-size: 16px;line-height: 30px;'> สำนักงาน คปภ. ฝ่ายพัฒนาเทคโนโลยีประกันภัย (CIT) ขอเรียนแจ้งว่า ได้รับการยืนยันการลงทะเบียนอบรมในหลักสูตร หลักสูตร Panorama Insurance for Startup   </span>  <br/>
          <span style='font-size: 16px;line-height: 30px;'> ระหว่างวันที่ 20-21 มีนาคม 2562 ณ ห้องประชุมชั้น 2 สถาบันวิทยาการระดับสูง สำนักงาน คปภ. เป็นที่เรียบร้อยแล้ว   </span>  <br/>
 <span style='font-size: 16px;line-height: 30px;'> และ ขอแนบ QR CODE ที่ใช้สำหรับยืนยันตัวตนเข้าร่วมงาน ด้านล่างนี้   </span>  <br/>       
</div>
         <br/>
        
      
        <br/>
         <div style='text-align: left;'> {qrcode} </div>
          <br/>
        <br/>
<div>
          <span style='font-size: 16px;line-height: 30px;'>รายละเอียดหลักสูตรเพิ่มเติม URL : <a href='http://cit.oic.or.th/VIEW/CIT_SEMINAR.aspx'> http://cit.oic.or.th/VIEW/CIT_SEMINAR.aspx</a> </span>
        </div>
        <div>
          <span style='font-size: 16px;line-height: 30px;'>สอบถามข้อมูลเพิ่มเติม</span>
        </div>
        <div>
          <span style='font-size: 16px;line-height: 30px;'> นายศุภโชค มานิกพันธุ์, นางสาวณิชรวี ผลหว้า และ นายศิวาวุฒิ วงศ์ยะรา </span>
        </div>        
        <div>
          <span style='font-size: 16px;line-height: 30px;'>โทร. 02-5153995-9 ต่อ 7109 </span>
        </div>
       
       
      </div>";
        return temp;
    }

    public class OicEmail
    {
        public async Task SendEmail(string from, string subject, List<string> to, string body,
            Dictionary<string, FileDataItem> files, string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(from), "from");
                    content.Add(new StringContent(subject), "subject");
                    content.Add(new StringContent(string.Join(",", to)), "to");
                    content.Add(new StringContent(body), "body");

                    content.Add(new StringContent("html"), "bodytype");
                    foreach (var f in files)
                    {
                        var fileContent = new ByteArrayContent(f.Value.Content);
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "attachment",
                            FileName = f.Value.FileName
                        };
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        fileContent.Headers.ContentLength = f.Value.Content.Length;
                        content.Add(fileContent);
                    }

                    var response = await client.PostAsync(url, content);
                    //string returnString = response.Content.ReadAsAsync<string>().Result;
                }
            }
            catch (Exception ex)
            {
                //NLogger.Debug($"SendEmail Error : {ex.Message}");
            }
        }
    }

    public class FileDataItem
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}