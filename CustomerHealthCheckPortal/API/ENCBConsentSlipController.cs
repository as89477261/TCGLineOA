using BLL.Controller.HealthCheck;
using DataModel.Models.NCB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.API
{
    [EnableCors("*", "*", "*")]
    public class ENCBConsentSlipController : BaseApi
    {

        [HttpPost]
        [Route("api/encbconsentslip/step1")]
        public IHttpActionResult Step1InsertENCBConsentSlipInfo([FromBody] NCBConsumerConsentSlipModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");

                var result = ENCBConsentSlipCon.Instance.Step1InsertENCBConsentSlipInfo(obj);

                if (result.RESULT_STATUS == "OK")
                    return Ok("OK");
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        // POST: api/CustomerProfile    
        [HttpPost]
        [Route("api/encbconsentslip/{transid}")]
        public IHttpActionResult GetNCBConsentSlipInfo(string transid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(transid)) return BadRequest("Error");

                var result = ENCBConsentSlipCon.Instance.GetNCBConsentSlipInfo(transid);


                if (result.RESULT_STATUS == "OK")
                {

                    DirectoryInfo dir = new DirectoryInfo(result.RESULT_OBJ.filePath + "/" + result.RESULT_OBJ.fileName);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        // ddlCompany.Items.Add(file);
                    }

                    //byte[] content = File.ReadAllBytes(result.RESULT_OBJ.filePath + "\\" + result.RESULT_OBJ.fileName);
                    //HttpContext.Current.Response.Clear();
                    //HttpContext.Current.Response.ContentType = "application/pdf";
                    //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + bufferResult.data.fileName + ".pdf");
                    //HttpContext.Current.Response.Buffer = true;
                    //HttpContext.Current.Response.BinaryWrite(content);
                    //HttpContext.Current.Response.End();

                }





                if (result.RESULT_STATUS == "OK")
                    return Ok("OK");
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/encbconsentslip/data/{transid}")]
        public HttpResponseMessage Post(string transid)
        {
            HttpResponseMessage r = new HttpResponseMessage(HttpStatusCode.OK);
            var resultData = ENCBConsentSlipCon.Instance.GetNCBConsentSlipInfo(transid);
            if (resultData.RESULT_STATUS == "OK" && resultData.RESULT_OBJ != null)
            {
                var path = resultData.RESULT_OBJ.filePath + "\\" + resultData.RESULT_OBJ.fileName;

                var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                r.Content = new StreamContent(stream);
                r.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                r.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "FileData", FileName = resultData.RESULT_OBJ.fileName };



            }
            return r;
        }

        [HttpGet]
        [Route("api/ncb/{idcard}/active")]
        public IHttpActionResult GetNCBDActiveData(string idcard)
        {
            try
            {
                ValidateHeader();
                if (idcard == null) return BadRequest("Error");

                var result = ENCBConsentSlipCon.Instance.GETCheckNCBHistory(idcard);

                if (result.RESULT_STATUS == "OK")
                    return Ok("OK");
                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

    }
}
