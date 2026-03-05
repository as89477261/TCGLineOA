using DataModel.Models.CustomerHealthModel.EventsModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.CustomerHealthModel.Reward;
using System.Configuration;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace DAL.Repos.CustomerHealthCheck
{
    public class RewardRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);

        public DataTable GetReward()
        {
            DataTable dt = null;
            SqlParameter[] parameters = { };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetAllRewardStock", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetAllRewardStock Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetRewardByRewardID(string rewardid)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                new SqlParameter("@RewardGUID", SqlDbType.VarChar, 200) { Value = rewardid }

            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetRewardStock", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetRewardStock Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetRewardByOwner(string ownerCode, string programCode, bool isUse = false)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@RewardOwnerCode", SqlDbType.VarChar, 200) { Value = ownerCode },
                new SqlParameter("@RewardProgramCode", SqlDbType.VarChar, 200) { Value = programCode },
                new SqlParameter("@IsUse", SqlDbType.VarChar, 1) { Value = isUse == false ? "0" : "1" }

            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetRewardStock", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetRewardStock Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetUIDMapReward(string UID, string rewardOwnerCode, string rewardProgramCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@RewardOwnerCode", SqlDbType.VarChar, 100) { Value = rewardOwnerCode },
                new SqlParameter("@RewardProgramCode", SqlDbType.VarChar, 100) { Value = rewardProgramCode }
            };
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapReward", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetUIDMapRewardByRange(string UID, string rewardOwnerCode, string rewardProgramCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@RewardOwnerCode", SqlDbType.VarChar, 100) { Value = rewardOwnerCode },
                new SqlParameter("@RewardProgramCode", SqlDbType.VarChar, 100) { Value = rewardProgramCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRewardByRange", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapRewardByRange Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetUIDMapRewardDuplicate(string UID, string rewardOwnerCode, string rewardProgramCode, string phoneNumber,
            string Token, string Mac, string IP)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@RewardOwnerCode", SqlDbType.VarChar, 100) { Value = rewardOwnerCode },
                new SqlParameter("@RewardProgramCode", SqlDbType.VarChar, 100) { Value = rewardProgramCode },
                new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 100) { Value = phoneNumber },
                //new SqlParameter("@OTP", SqlDbType.VarChar, 100) { Value = OTP },
                new SqlParameter("@Token", SqlDbType.VarChar, 100) { Value = Token },
                new SqlParameter("@Mac", SqlDbType.VarChar, 100) { Value = Mac },
                new SqlParameter("@IP", SqlDbType.VarChar, 100) { Value = IP }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRewardDuplicate", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapRewardDuplicate Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetUIDMapRewardDummy(string UID, string OTP, string rewardOwnerCode, string rewardProgramCode,
            string phoneNumber, string Token, string Mac, string IP, string OTPRef)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@RewardProgramCode", SqlDbType.VarChar, 100) { Value = rewardProgramCode },
                new SqlParameter("@RewardOwnerCode", SqlDbType.VarChar, 100) { Value = rewardOwnerCode },
                new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 100) { Value = phoneNumber },
                new SqlParameter("@Token", SqlDbType.VarChar, 100) { Value = Token },
                new SqlParameter("@Mac", SqlDbType.VarChar, 100) { Value = Mac },
                new SqlParameter("@IP", SqlDbType.VarChar, 100) { Value = IP },
                new SqlParameter("@OTP", SqlDbType.VarChar, 100) { Value = OTP },
                new SqlParameter("@OTPREF", SqlDbType.VarChar, 100) { Value = OTPRef },
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRewardDummy", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapRewardDummy Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetUIDPassRewardCondition(string UID, string subInfoType)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@subInfoType", SqlDbType.VarChar, 100) { Value = subInfoType }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDPassRewardCondition", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetUIDPassRewardConditionConfig(string UID, string ownerCode,string programCode,string campaingCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@OwnerCode", SqlDbType.VarChar, 100) { Value = ownerCode },
                new SqlParameter("@ProgramCode", SqlDbType.VarChar, 100) { Value = programCode },
                new SqlParameter("@CampaignCode", SqlDbType.VarChar, 100) { Value = campaingCode },
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDPassRewardConditionConfig", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertUIDMapReward(RewardMapUIDModel reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", reg.UID));
                list.Add(new SqlParameter("@MatchCondition", reg.MatchCondition));
                list.Add(new SqlParameter("@RewardGUID", reg.RewardGUID));
                list.Add(new SqlParameter("@StartDate", reg.StartDate));
                list.Add(new SqlParameter("@EndDate", reg.EndDate));
                list.Add(new SqlParameter("@PhoneNumber", reg.PhoneNumber));
                list.Add(new SqlParameter("@OTP", reg.OTP));
                list.Add(new SqlParameter("@RewardProgramCode", reg.RewardProgramCode));
                list.Add(new SqlParameter("@RewardOwnerCode", reg.RewardOwnerCode));
                list.Add(new SqlParameter("@Token", reg.Token));
                list.Add(new SqlParameter("@Mac", reg.Mac));
                list.Add(new SqlParameter("@IP", reg.IP));
                list.Add(new SqlParameter("@OTPRef", reg.OTPRef));

                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertUIDMapReward", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertUIDMapReward Error : " + ex, ref log4);
            }

            return result;
        }
        public string InsertFormEventRegisterDynamic(FormEventRegisterDynamicInputModel reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", reg.UID));
                list.Add(new SqlParameter("@BusinessType", reg.BusinessType));
                list.Add(new SqlParameter("@CompanyName", reg.BusinessName));

                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertFormRegisterEvent", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertFormRegisterEvent Error : " + ex, ref log4);
            }

            return result;
        }
        public string InsertRewardList(DataRow dr)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@RewardCode", dr["RewardCode"].ToString()));
                list.Add(new SqlParameter("@RewardType", dr["RewardType"].ToString()));
                list.Add(new SqlParameter("@RewardOwner", dr["RewardOwner"].ToString()));
                list.Add(new SqlParameter("@RewardDesc", dr["RewardDesc"].ToString()));
                list.Add(new SqlParameter("@RewardCriteria", dr["RewardCriteria"].ToString()));
                list.Add(new SqlParameter("@StartDate", DateTime.Parse(dr["StartDate"].ToString(), new CultureInfo("th-TH"))));
                list.Add(new SqlParameter("@EndDate", DateTime.Parse(dr["EndDate"].ToString(), new CultureInfo("th-TH"))));
                list.Add(new SqlParameter("@RewardBranchOwner", dr["RewardBranchOwner"].ToString()));
                list.Add(new SqlParameter("@EventCode", dr["EventCode"].ToString()));
                list.Add(new SqlParameter("@RewardLogoPath", dr["RewardLogoPath"].ToString()));
                list.Add(new SqlParameter("@RewardQRPath", dr["RewardQRPath"].ToString()));
                list.Add(new SqlParameter("@RewardTitle", dr["RewardTitle"].ToString()));
                list.Add(new SqlParameter("@RewardRemark", dr["RewardRemark"].ToString()));
                list.Add(new SqlParameter("@RewardValue", dr["RewardValue"].ToString()));

                list.Add(new SqlParameter("@RewardProgram", dr["RewardProgram"].ToString()));


                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertRewardStock", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertRewardStock Error : " + ex, ref log4);
            }

            return result;
        }
        public string InsertBulkRewardList(DataTable dt)
        {
            var result = string.Empty;
            try
            {
                string consString = ConfigurationManager.AppSettings["DB_CustomerHealthCheck"];
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.TPT_RewardStock";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                        sqlBulkCopy.ColumnMappings.Add("RewardCode", "RewardCode");
                        sqlBulkCopy.ColumnMappings.Add("RewardType", "RewardType");
                        sqlBulkCopy.ColumnMappings.Add("RewardOwner", "RewardOwner");
                        sqlBulkCopy.ColumnMappings.Add("RewardDesc", "RewardDesc");
                        sqlBulkCopy.ColumnMappings.Add("RewardCriteria", "RewardCriteria");
                        sqlBulkCopy.ColumnMappings.Add("StartDate", "StartDate");
                        sqlBulkCopy.ColumnMappings.Add("EndDate", "EndDate");
                        sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                        sqlBulkCopy.ColumnMappings.Add("IsUse", "IsUse");
                        sqlBulkCopy.ColumnMappings.Add("RewardBranchOwner", "RewardBranchOwner");
                        sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
                        sqlBulkCopy.ColumnMappings.Add("CreateBy", "CreateBy");
                        sqlBulkCopy.ColumnMappings.Add("UpdateDate", "UpdateDate");
                        sqlBulkCopy.ColumnMappings.Add("UpdateBy", "UpdateBy");
                        sqlBulkCopy.ColumnMappings.Add("EventCode", "EventCode");
                        sqlBulkCopy.ColumnMappings.Add("RewardLogoPath", "RewardLogoPath");
                        sqlBulkCopy.ColumnMappings.Add("RewardQRPath", "RewardQRPath");
                        //sqlBulkCopy.ColumnMappings.Add("RewardSeq", "RewardSeq");
                        sqlBulkCopy.ColumnMappings.Add("RewardTitle", "RewardTitle");
                        sqlBulkCopy.ColumnMappings.Add("RewardRemark", "RewardRemark");
                        sqlBulkCopy.ColumnMappings.Add("RewardValue", "RewardValue");
                        //sqlBulkCopy.ColumnMappings.Add("RewardGUID", "RewardGUID");
                        sqlBulkCopy.ColumnMappings.Add("RewardProgram", "RewardProgram");


                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertFormRegisterEvent Error : " + ex, ref log4);
            }

            return result;
        }

        public string UpdateUIDMapReward(RewardMapUIDModel reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", reg.UID));                
                list.Add(new SqlParameter("@RewardGUID", reg.RewardGUID));               
                list.Add(new SqlParameter("@PhoneNumber", reg.PhoneNumber));
                list.Add(new SqlParameter("@OTP", reg.OTP));
                list.Add(new SqlParameter("@RewardProgramCode", reg.RewardProgramCode));
                list.Add(new SqlParameter("@RewardOwnerCode", reg.RewardOwnerCode));  
                list.Add(new SqlParameter("@OTPRef", reg.OTPRef));

                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("UpdateUIDMapReward", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateUIDMapReward Error : " + ex, ref log4);
            }

            return result;
        }

        // Dashboard
        public DataTable GetRewardDashboard()
        {
            DataTable dt = null;
            SqlParameter[] parameters = { };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetRewardDashboard", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetAllRewardStock Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}
