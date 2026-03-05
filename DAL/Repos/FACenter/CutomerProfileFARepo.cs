using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using DataModels.FACenter;
using log4net;

namespace DAL.FACenter
{
    public class CutomerProfileFARepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);


        public string InsertCustomerProfileFA(CustomerProfileFAInfo customer)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();

                list.Add(new SqlParameter("Id", customer.Id));
                list.Add(new SqlParameter("IsCustomerTCG", customer.IsCustomerTCG));
                list.Add(new SqlParameter("CustomerTCGCode", customer.CustomerTCGCode));
                list.Add(new SqlParameter("EN_Id", customer.EN_Id));
                list.Add(new SqlParameter("IDCard", customer.IdCard));
                list.Add(new SqlParameter("TitleName", customer.TitleName));
                list.Add(new SqlParameter("UserFirstName", customer.UserFirstName));
                list.Add(new SqlParameter("UserLastName", customer.UserLastName));
                list.Add(new SqlParameter("CompanyName", customer.CompanyName));

                list.Add(new SqlParameter("PositionInCompany", customer.PositionInCompany));
                list.Add(new SqlParameter("FormatService", customer.FormatService));
                list.Add(new SqlParameter("TypeCompany", customer.TypeCompany));


                //list.Add(new System.Data.SqlClient.SqlParameter("PositionInCompany", LogUtility.Common.ConvertToInt(customer.PositionInCompany)));
                //list.Add(new System.Data.SqlClient.SqlParameter("FormatService", LogUtility.Common.ConvertToInt(customer.FormatService)));
                //list.Add(new System.Data.SqlClient.SqlParameter("TypeCompany", LogUtility.Common.ConvertToInt(customer.TypeCompany)));
                list.Add(new SqlParameter("TypeProductOrService", customer.TypeProductOrService));
                list.Add(new SqlParameter("Status_CustomerTCG", customer.Status_CustomerTCG));
                list.Add(new SqlParameter("IsMember", customer.IsMember));
                list.Add(new SqlParameter("IsMember_Remark", customer.IsMember_Remark));
                list.Add(new SqlParameter("Business_CountAge", customer.Business_CountAge));
                list.Add(new SqlParameter("Business_CountEmployee", customer.Business_CountEmployee));
                list.Add(new SqlParameter("Business_Location", customer.Business_Location));
                list.Add(new SqlParameter("Business_Location_Remark", customer.Business_Location_Remark));
                list.Add(new SqlParameter("Province", customer.Province));
                list.Add(new SqlParameter("Amphur", customer.Amphur));
                list.Add(new SqlParameter("Tumbon", customer.Tumbon));
                list.Add(new SqlParameter("Address", customer.Address));
                list.Add(new SqlParameter("ZipCode", customer.ZipCode));
                list.Add(new SqlParameter("Tel", customer.Tel));
                list.Add(new SqlParameter("Mobile", customer.Mobile));
                list.Add(new SqlParameter("LineId", customer.LineId));
                list.Add(new SqlParameter("Line_UserId", customer.Line_UserId));
                list.Add(new SqlParameter("EmailAddress", customer.EmailAddress));
                list.Add(new SqlParameter("Fax", customer.Fax));
                list.Add(new SqlParameter("Remark", customer.Remark));
                list.Add(new SqlParameter("CreateBy", customer.CreateBy));

                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertCustomerProfile", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProductCondition Error : " + ex, ref log4);
            }

            return result;
        }
    }
}