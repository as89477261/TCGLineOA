using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.NDID.EForm;
using DataModel.Models.TCCProject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CustomerHealthCheck.API
{
    public class TCCProjectController : BaseApi
    {
        [HttpPost]
        [Route("api/tcc/insertUidMapTcc")]

        public IHttpActionResult InsertUidMapTCC(UIDMapTCCModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{
                var result = TCCProjectCon.Instance.InsertUIDMapTCC(obj);
                if (result.RESULT_STATUS == "OK")
                {
                    return GenResponse(result);
                }
                return BadRequest("Result Repo Error");
                //}
                //return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/tcc/getMemberStatusBYS/{identityId}")]

        public IHttpActionResult GetMemberStatusBYS(string identityId)
        {
            try
            {
                ValidateHeader();
                if (identityId == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{
                var result = TCCProjectInterface.GetMemberStatus(identityId);
                if (result.Success)
                {
                    return GenResponseTCC(result);
                }
                return BadRequest("Result Repo Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }

        }

        [HttpPost]
        [Route("api/tcc/insertInformationTCC")]

        public IHttpActionResult InsertInformationTCC(InformationTCCModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{
                var result = TCCProjectCon.Instance.InsertInformation(obj);
                if (result.RESULT_STATUS == "OK")
                {
                    return GenResponse(result);
                }
                return BadRequest("Result Repo Error");
                //}
                //return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }
        [HttpPost]
        [Route("api/tcc/updateInformationTCCPerson")]

        public IHttpActionResult UpdateInformationTCCPerson(InformationTCCModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{
                var result = TCCProjectCon.Instance.UpdateInformationTCCPerson(obj);
                if (result.RESULT_STATUS == "OK")
                {
                    return GenResponse(result);
                }
                return BadRequest("Result Repo Error");
                //}
                //return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/tcc/updateInformationTCCJurustic")]

        public IHttpActionResult UpdateInformationTCCJurustic(InformationTCCModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{
                var result = TCCProjectCon.Instance.UpdateInformationTCCJurustic(obj);
                if (result.RESULT_STATUS == "OK")
                {
                    return GenResponse(result);
                }
                return BadRequest("Result Repo Error");
                //}
                //return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/tcc/updateUIDMapTCC")]

        public IHttpActionResult UpdateUIDMapTCC(UIDMapTCCModel obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{
                var result = TCCProjectCon.Instance.UpdateUIDMapTCC(obj);
                if (result.RESULT_STATUS == "OK")
                {
                    return GenResponse(result);
                }
                return BadRequest("Result Repo Error");
                //}
                //return BadRequest("ErrorMessage : " + GetErrorMessage(ModelState));

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }


        [HttpPost]
        [Route("api/tcc/addMemberPeronalBYS")]

        public IHttpActionResult AddMemberPeronalBYS(RootAddPerson obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{

                var result = TCCProjectInterface.AddMemberPeronalBYS(obj);
                if (result.Success)
                {
                    return GenResponseTCCAddMember(result);
                }
                return BadRequest("Result Repo Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }

        }

        [HttpPost]
        [Route("api/tcc/addMemberCorperateBYS")]

        public IHttpActionResult AddMemberCorperateBYS(RootAddJurustic obj)
        {
            try
            {
                ValidateHeader();
                if (obj == null)
                {
                    return BadRequest("Object Null");
                }
                //if (ModelState.IsValid)
                //{

                var result = TCCProjectInterface.AddMemberCorperateBYS(obj);
                if (result.Success)
                {
                    return GenResponseTCCAddMember(result);
                }
                return BadRequest("Result Repo Error");
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }

        }


        [HttpGet]
        [Route("api/tcc/getUidDataTCC/{uid}")]
        public IHttpActionResult GetUidDataTCC(string uid)
        {
            try
            {
                ValidateHeader();
                if (string.IsNullOrEmpty(uid)) { return BadRequest("Error"); }

                var result = TCCProjectCon.Instance.GetUidDataTCC(uid);

                if (result.RESULT_STATUS == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/tcc/fileUpload")]
        public IHttpActionResult FileUpload([Microsoft.AspNetCore.Mvc.FromQuery] string uid)
        {
            try
            {
                ValidateHeader();
                var httpRequest = System.Web.HttpContext.Current.Request;

                // Check if there are any files
                if (httpRequest.Files.Count == 0 || string.IsNullOrEmpty(uid))
                {
                    return BadRequest("No files uploaded or UID missing");
                }
                var tccProjectFileUpload = ConfigurationManager.AppSettings["TCCProjectFileUpload"];
                var tccProjectDownloadURL = ConfigurationManager.AppSettings["TCCProjectDownloadURL"];
                var th_locale = new CultureInfo("th-TH");
                var year = DateTime.Now.ToString("yy", th_locale);
                var uploadsSubDirectory = Path.Combine(tccProjectFileUpload, year, uid);
                // Iterate through the uploaded files
                var result = new BaseModel<List<FileUploadResponse>>();
                var responseResult = new List<FileUploadResponse>();
                if (!Directory.Exists(uploadsSubDirectory))
                {
                    Directory.CreateDirectory(uploadsSubDirectory);
                }
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        // Save the file to the server or process it
                        //string filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles"), string.Concat(postedFile.FileName,".pdf"));
                        string filePath = Path.Combine(uploadsSubDirectory, postedFile.FileName);
                        postedFile.SaveAs(filePath);

                        var pathParts = tccProjectFileUpload.Split('\\');
                        var lastFolder = pathParts[pathParts.Length - 1];
                        var splitFileName = postedFile.FileName.Split('_');
                        var fileType = splitFileName[0];
                        var response = new FileUploadResponse();
                        response.Uid = uid;
                        response.Url = string.Concat(tccProjectDownloadURL, "/", lastFolder, "/", year, "/", uid, "/", postedFile.FileName);
                        response.FileType = fileType;
                        responseResult.Add(response);
                        // You can store file path or details in DB if needed
                    }
                }

                if (responseResult.Any())
                {
                    result.RESULT_STATUS = "OK";
                    result.RESULT_MESSAGE = "Success";
                    result.RESULT_OBJ = responseResult;
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Error Call API : " + ex.Message);
                return BadRequest("ErrorMessage : " + ex.Message);
            }
        }

    }

}

