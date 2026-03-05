using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel.PreRequest;
using Microsoft.SqlServer.Server;

namespace CustomerHealthCheck.Api
{
    [EnableCors("*", "*", "*")]
    public class
        RequestInfoController : BaseApi
    {
        [HttpPost]
        [Route("api/requestinfo/prendid")]
        public IHttpActionResult InsertUIDMapNDIDPreRequest([FromBody] List<UIDMapNDIDPreRequest> lstObj)
        {
            try
            {
                ValidateHeader();
                if (lstObj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = PreNDIDCon.Instance.InsertUIDMapNDIDPreRequest(lstObj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
                    return BadRequest("Error");
                }

                return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/requestinfo/prendid/history")]
        public IHttpActionResult InsertUIDMapNDIDPreRequestHistory([FromBody] UIDMapNDIDPreRequestHistory obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");
                if (ModelState.IsValid)
                {
                    var result = PreNDIDCon.Instance.InsertUIDMapNDIDPreRequestHistory(obj);
                    if (result.RESULT_STATUS == "OK")
                        return Ok("OK");
                    return BadRequest("Error");
                }

                return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/requestinfo/encbconsent/pdf")]
        public HttpResponseMessage GetENCBConsentSlip()
        {
            string path = HttpContext.Current.Server.MapPath("~/documents/E-ConsentSlip.pdf"); ;


            //converting Pdf file into bytes array
            var dataBytes = File.ReadAllBytes(path);
            //adding bytes to memory stream
            var dataStream = new MemoryStream(dataBytes);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "E-ConsentSlip.pdf";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

        [HttpPost]
        [Route("api/requestinfo/prendid/score/previous")]
        public IHttpActionResult InsertPreNDIDStatusAndUpdateNCBScoreToCyber([FromBody] UIDMapPreRequestAndUpdateCyber obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null) return BadRequest("Error");

                var result = PreNDIDCon.Instance.InsertPreNDIDStatusAndUpdateNCBScoreToCyber(obj);
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