using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;
using log4net.Config;

public class RegisterDB
{
    private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
    private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

    public RegisterDB()
    {
        XmlConfigurator.Configure();
    }

    public DataTable GetProvince()
    {
        DataTable dt = null;

        try
        {
            dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetProvince").Tables[0];
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetProvince Error : " + ex, ref log4);
        }

        return dt;
    }

    public int GetBucketProvince(string ProvinceCode, PersonType type)
    {
        var bucket = 0;
        SqlParameter[] parameters =
        {
            new SqlParameter("@ProvinceCode", SqlDbType.VarChar, 2) { Value = ProvinceCode },
            new SqlParameter("@Type", SqlDbType.VarChar, 1) { Value = type == PersonType.Corporate ? "C" : "P" }
        };
        try
        {
            var result = DB_CustomerHealthCheck.executeStoredProcedureScalar("GetBucketProvince", parameters);

            if (result != null)
                bucket = Convert.ToInt32(result);
            else
                LogUtility.writeLog("GetBucketProvince() : There is no data from GetBucketProvince", ref log4);
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetBucketProvince Error : " + ex, ref log4);
        }

        return bucket;
    }

    public DataTable GetIndustry()
    {
        DataTable dt = null;

        try
        {
            dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetIndustry").Tables[0];
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetIndustry Error : " + ex, ref log4);
        }

        return dt;
    }

    public int GetBucketIndustry(string IndustryGroup, PersonType type)
    {
        var bucket = 0;
        SqlParameter[] parameters =
        {
            new SqlParameter("@IndustryGroup", SqlDbType.VarChar, 2) { Value = IndustryGroup },
            new SqlParameter("@Type", SqlDbType.VarChar, 1) { Value = type == PersonType.Corporate ? "C" : "P" }
        };
        try
        {
            var result = DB_CustomerHealthCheck.executeStoredProcedureScalar("GetBucketIndustry", parameters);

            if (result != null)
                bucket = Convert.ToInt32(result);
            else
                LogUtility.writeLog("GetBucketIndustry() : There is no data from GetBucketIndustry", ref log4);
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetBucketIndustry Error : " + ex, ref log4);
        }

        return bucket;
    }

    public ScoreInfo GetHealthCheckScore(ScoreInfo score, PersonType type)
    {
        var scoreInfo = new ScoreInfo();

        SqlParameter[] parameters =
        {
            new SqlParameter("@Score", SqlDbType.Int) { Value = score.score },
            new SqlParameter("@Group", SqlDbType.Int) { Value = score.scoreGroup },
            new SqlParameter("@Type", SqlDbType.VarChar, 1) { Value = type == PersonType.Corporate ? "C" : "P" }
        };

        try
        {
            var dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetHealthCheckScore", parameters)
                .Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                scoreInfo.score = score.score;
                scoreInfo.scoreGroup = Convert.ToInt32(dt.Rows[0]["GroupCode"]);
                scoreInfo.groupDesc = dt.Rows[0]["GroupDesc"].ToString();
                scoreInfo.ImageBG = dt.Rows[0]["ImageBackground"].ToString();
                scoreInfo.ImageScore = dt.Rows[0]["ImageScore"].ToString();
                scoreInfo.groupShortDesc = dt.Rows[0]["GroupShortDesc"].ToString();
            }
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetHealthCheckScore Error : " + ex, ref log4);
        }

        return scoreInfo;
    }

    public DataTable GetTitleName(PersonType type)
    {
        DataTable dt = null;

        SqlParameter[] parameters =
        {
            new SqlParameter("@Type", SqlDbType.VarChar, 1) { Value = type == PersonType.Corporate ? "C" : "P" }
        };

        try
        {
            dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetTitleName", parameters).Tables[0];
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
        }

        return dt;
    }

    public int InsertRegisterInfo(RegisterInfo info, ScoreInfo score)
    {
        var id = 0;
        SqlParameter[] parameters =
        {
            new SqlParameter("@PersonType", SqlDbType.Int) { Value = info.personType },
            new SqlParameter("@EstablishmentType", SqlDbType.Int) { Value = info.officeType },
            new SqlParameter("@YearIncorporate", SqlDbType.Int) { Value = info.yearIncorporate },
            new SqlParameter("@IndustryCode", SqlDbType.Int) { Value = info.industryCode },
            new SqlParameter("@ProvinceCode", SqlDbType.VarChar) { Value = info.provinceCode },
            new SqlParameter("@RegionCode", SqlDbType.VarChar) { Value = info.regionCode },
            new SqlParameter("@OwnerAge", SqlDbType.Int) { Value = info.ownerAge },
            new SqlParameter("@MaritalStatus", SqlDbType.Int) { Value = info.maritalStatus },
            new SqlParameter("@YearExperience", SqlDbType.Int) { Value = info.yearExperience },
            new SqlParameter("@DebtStatus", SqlDbType.Int) { Value = info.debtStatus },
            new SqlParameter("@TdrAmount", SqlDbType.Int) { Value = info.TdrAmount },
            new SqlParameter("@TdrYear", SqlDbType.Int) { Value = info.TdrYear },
            new SqlParameter("@AssetValue", SqlDbType.Decimal) { Value = info.assetValue },
            new SqlParameter("@DebtValue", SqlDbType.Decimal) { Value = info.debtValue },
            new SqlParameter("@Income", SqlDbType.Decimal) { Value = info.income },
            new SqlParameter("@Expense", SqlDbType.Decimal) { Value = info.expense },
            new SqlParameter("@InstallmentAmount", SqlDbType.Decimal) { Value = info.installmentAmount },
            new SqlParameter("@IsGetProfit", SqlDbType.Int)
                { Value = info.isGetProfit == IsGetProfit.Yes ? 1 : info.isGetProfit == IsGetProfit.No ? 2 : 0 },
            new SqlParameter("@ObjectiveTerm", SqlDbType.Int) { Value = info.objectiveTerm },
            new SqlParameter("@LoanAmount", SqlDbType.Decimal) { Value = info.loanAmount },
            new SqlParameter("@YearInstallment", SqlDbType.Int) { Value = info.yearInstallment },
            new SqlParameter("@Title", SqlDbType.VarChar) { Value = info.title },
            new SqlParameter("@Name", SqlDbType.VarChar) { Value = info.name },
            new SqlParameter("@Surname", SqlDbType.VarChar) { Value = info.surname },
            new SqlParameter("@BusinessName", SqlDbType.VarChar) { Value = info.businessName },
            new SqlParameter("@Phone", SqlDbType.VarChar) { Value = info.phone },
            new SqlParameter("@IdCard", SqlDbType.VarChar) { Value = info.idCard },
            new SqlParameter("@Remark", SqlDbType.VarChar) { Value = info.remark },

            new SqlParameter("@Score", SqlDbType.Int) { Value = score.score },
            new SqlParameter("@ScoreGroup", SqlDbType.Int) { Value = score.scoreGroup },
            new SqlParameter("@IsAcceptConsent", SqlDbType.Int) { Value = info.consent },

            // Extension New Data 
            new SqlParameter("@CostSale", SqlDbType.Decimal) { Value = info.CostSale },
            new SqlParameter("@LoanLCTR", SqlDbType.Decimal) { Value = info.LoanLCTR },
            new SqlParameter("@LoanLG", SqlDbType.Decimal) { Value = info.LoanLG },
            new SqlParameter("@LoanPN", SqlDbType.Decimal) { Value = info.LoanPN },
            new SqlParameter("@LoanOD", SqlDbType.Decimal) { Value = info.LoanOD },
            new SqlParameter("@LoanTL", SqlDbType.Decimal) { Value = info.LoanTL },
            new SqlParameter("@LoanOther", SqlDbType.Decimal) { Value = info.LoanOther },
            new SqlParameter("@DSCR", SqlDbType.Decimal) { Value = info.DSCR },
            new SqlParameter("@LandAsset", SqlDbType.Decimal) { Value = info.LandAsset },
            new SqlParameter("@SumAsset", SqlDbType.Decimal) { Value = info.SumAsset },

            new SqlParameter("@TCGScoreRBP", SqlDbType.Decimal) { Value = info.TCGScoreRBP },
            new SqlParameter("@TCGScoreTotalScore", SqlDbType.Int) { Value = info.TCGScoreTotalScore },
            new SqlParameter("@TCGScoreBand", SqlDbType.NVarChar) { Value = info.TCGScoreBand },
            new SqlParameter("@TCGScoreBandLevel", SqlDbType.Int) { Value = info.TCGScoreBandLevel },
            new SqlParameter("@IsPassCreditBureau", SqlDbType.Int) { Value = info.IsPassCreditBureau },
            new SqlParameter("@CreditBureauLevel", SqlDbType.Int) { Value = info.CreditBureauLevel }
        };

        try
        {
            var result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertRegisterInfo", parameters);

            if (result != null)
                id = Convert.ToInt32(result);
            else
                LogUtility.writeLog("InsertRegisterInfo() : There is no data from InsertRegisterInfo", ref log4);
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertRegisterInfo Error : " + ex, ref log4);
        }

        return id;
    }

    public bool UpdateRegisterInfo(RegisterInfo info)
    {
        SqlParameter[] parameters =
        {
            new SqlParameter("@ID", SqlDbType.Int) { Value = info.id },
            new SqlParameter("@Title", SqlDbType.VarChar) { Value = info.title },
            new SqlParameter("@Name", SqlDbType.VarChar) { Value = info.name },
            new SqlParameter("@Surname", SqlDbType.VarChar) { Value = info.surname },
            new SqlParameter("@BusinessName", SqlDbType.VarChar) { Value = info.businessName },
            new SqlParameter("@Phone", SqlDbType.VarChar) { Value = info.phone },
            new SqlParameter("@IdCard", SqlDbType.VarChar) { Value = info.idCard },
            new SqlParameter("@Remark", SqlDbType.VarChar) { Value = info.remark },
            new SqlParameter("@Event", SqlDbType.VarChar) { Value = info.eventType }
        };

        try
        {
            DB_CustomerHealthCheck.ExecuteStoredProcedureNonQuery("UpdateRegisterInfo", parameters);
            return true;
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("UpdateRegisterInfo Error : " + ex, ref log4);
        }

        return false;
    }

    public bool UpdateConsent(RegisterInfo info)
    {
        SqlParameter[] parameters =
        {
            new SqlParameter("@ID", SqlDbType.Int) { Value = info.id },
            new SqlParameter("@IsAcceptConsent", SqlDbType.Int) { Value = info.consent }
        };

        try
        {
            DB_CustomerHealthCheck.ExecuteStoredProcedureNonQuery("UpdateConsent", parameters);
            return true;
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("UpdateConsent Error : " + ex, ref log4);
        }

        return false;
    }

    public bool UpdateCodeFromClinic(int id, string clinicCustomerCode, string clinicRequestNo)
    {
        SqlParameter[] parameters =
        {
            new SqlParameter("@ID", SqlDbType.Int) { Value = id },
            new SqlParameter("@ClinicCustomerCode", SqlDbType.VarChar) { Value = clinicCustomerCode },
            new SqlParameter("@ClinicRequestNo", SqlDbType.VarChar) { Value = clinicRequestNo }
        };

        try
        {
            DB_CustomerHealthCheck.ExecuteStoredProcedureNonQuery("UpdateCodeFromClinic", parameters);
            return true;
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("UpdateCodeFromClinic Error : " + ex, ref log4);
        }

        return false;
    }

    public string InsertCustomerProfile(RegisterInfo info)
    {
        var customerCode = string.Empty;

        SqlParameter[] parameters =
        {
            /* from user input */
            new SqlParameter("@Name", SqlDbType.VarChar, 100)
                { Value = string.IsNullOrEmpty(info.name) ? info.businessName : info.name },
            new SqlParameter("@SureName", SqlDbType.VarChar, 100)
                { Value = string.IsNullOrEmpty(info.surname) ? "" : info.surname },
            new SqlParameter("@CompanyName", SqlDbType.VarChar, 150) { Value = info.businessName },
            new SqlParameter("@CompanyProvince_Code", SqlDbType.VarChar, 15) { Value = info.provinceCode },
            new SqlParameter("@CompanyType_OfName", SqlDbType.VarChar, 200) { Value = "" },
            /* constant */
            new SqlParameter("@Code", SqlDbType.BigInt) { Value = 0 },
            new SqlParameter("@IdCard", SqlDbType.VarChar, 15) { Value = info.idCard },
            new SqlParameter("@CustomerType", SqlDbType.Int) { Value = 3 },
            new SqlParameter("@IdCardType", SqlDbType.Int) { Value = info.personType + 1 },
            new SqlParameter("@TitleName", SqlDbType.VarChar, 10) { Value = info.title },
            new SqlParameter("@CustomerCodeOfMagic", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@CompanyType_Id", SqlDbType.VarChar, 15) { Value = info.industryCode },
            new SqlParameter("@IsCurrentAddressOfHouse", SqlDbType.Int) { Value = 1 },
            new SqlParameter("@User_Create", SqlDbType.VarChar, 15) { Value = "9991" }
        };

        try
        {
            customerCode = DB_SMEClinic.executeStoredProcedureScalar("proc_InsertCustomerProfile", parameters)
                .ToString();
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertCustomerProfile() Error : " + ex, ref log4);
        }

        return customerCode;
    }

    public void InsertContactProfile(RegisterInfo info, string customerCode, int ContactType)
    {
        SqlParameter[] parameters =
        {
            /* from user input */
            new SqlParameter("@CustomerProfile_Code", SqlDbType.BigInt) { Value = customerCode },
            new SqlParameter("@ContactType", SqlDbType.Int) { Value = ContactType },
            new SqlParameter("@House_Province", SqlDbType.Int) { Value = info.provinceCode },
            new SqlParameter("@MobileNumber", SqlDbType.VarChar, 50) { Value = info.phone },
            new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50) { Value = "" },
            /* constant */
            new SqlParameter("@Id", SqlDbType.Int) { Value = -1 },
            new SqlParameter("@House_Building", SqlDbType.VarChar, 250) { Value = "" },
            new SqlParameter("@House_Soi", SqlDbType.VarChar, 100) { Value = "" },
            new SqlParameter("@House_Road", SqlDbType.VarChar, 100) { Value = "" },
            new SqlParameter("@House_Tumbon", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@House_Amphure", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@House_ZipCode", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@House_Phone", SqlDbType.VarChar, 50) { Value = "" },
            new SqlParameter("@House_Fax", SqlDbType.VarChar, 15) { Value = "" },
            new SqlParameter("@Facebook", SqlDbType.VarChar, 100) { Value = "" },
            new SqlParameter("@LineID", SqlDbType.VarChar, 50) { Value = "" },
            new SqlParameter("@User_Create", SqlDbType.VarChar, 10) { Value = "9991" }
        };

        try
        {
            DB_SMEClinic.ExecuteStoredProcedureNonQuery("proc_InsertContactProfile", parameters);
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertContactProfile() Error : " + ex, ref log4);
        }
    }

    public void InsertContactProfileWithEmail(RegisterInfo info, string customerCode, int ContactType, string email)
    {
        SqlParameter[] parameters =
        {
            /* from user input */
            new SqlParameter("@CustomerProfile_Code", SqlDbType.BigInt) { Value = customerCode },
            new SqlParameter("@ContactType", SqlDbType.Int) { Value = ContactType },
            new SqlParameter("@House_Province", SqlDbType.Int) { Value = info.provinceCode },
            new SqlParameter("@MobileNumber", SqlDbType.VarChar, 50) { Value = info.phone },
            new SqlParameter("@EmailAddress", SqlDbType.VarChar, 100) { Value = email },
            /* constant */
            new SqlParameter("@Id", SqlDbType.Int) { Value = -1 },
            new SqlParameter("@House_Building", SqlDbType.VarChar, 250) { Value = "" },
            new SqlParameter("@House_Soi", SqlDbType.VarChar, 100) { Value = "" },
            new SqlParameter("@House_Road", SqlDbType.VarChar, 100) { Value = "" },
            new SqlParameter("@House_Tumbon", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@House_Amphure", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@House_ZipCode", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@House_Phone", SqlDbType.VarChar, 50) { Value = "" },
            new SqlParameter("@House_Fax", SqlDbType.VarChar, 15) { Value = "" },
            new SqlParameter("@Facebook", SqlDbType.VarChar, 100) { Value = "" },
            new SqlParameter("@LineID", SqlDbType.VarChar, 50) { Value = "" },
            new SqlParameter("@User_Create", SqlDbType.VarChar, 10) { Value = "9991" }
        };

        try
        {
            DB_SMEClinic.ExecuteStoredProcedureNonQuery("proc_InsertContactProfile", parameters);
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertContactProfile() Error : " + ex, ref log4);
        }
    }

    public string InsertRequest(string customerCode, int Activity_Id)
    {
        var requestNo = string.Empty;

        SqlParameter[] parameters =
        {
            /* from user input */
            new SqlParameter("@CustomerCode", SqlDbType.BigInt) { Value = customerCode },
            new SqlParameter("@Activity_Id", SqlDbType.Int) { Value = Activity_Id },
            new SqlParameter("@Remark", SqlDbType.VarChar) { Value = "" },
            new SqlParameter("@IsTimeOfTCGContact_Morning", SqlDbType.Bit) { Value = 1 },
            new SqlParameter("@IsTimeOfTCGContact_Afternoon", SqlDbType.Bit) { Value = 1 },
            /* constant */
            new SqlParameter("@RequestNo", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@InputDataType", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@IsTimeOfTCGContact_Night", SqlDbType.Bit) { Value = 0 },
            new SqlParameter("@User_Create", SqlDbType.VarChar, 10) { Value = "9991" }
        };

        try
        {
            requestNo = DB_SMEClinic.executeStoredProcedureScalar("proc_InsertRequest", parameters).ToString();
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertRequest() Error : " + ex, ref log4);
        }

        return requestNo;
    }

    public string InsertRequestPGS10(string customerCode, int Activity_Id)
    {
        var requestNo = string.Empty;

        SqlParameter[] parameters =
        {
            /* from user input */
            new SqlParameter("@CustomerCode", SqlDbType.BigInt) { Value = customerCode },
            new SqlParameter("@Activity_Id", SqlDbType.Int) { Value = Activity_Id },
            new SqlParameter("@Remark", SqlDbType.VarChar) { Value = "" },
            new SqlParameter("@IsTimeOfTCGContact_Morning", SqlDbType.Bit) { Value = 1 },
            new SqlParameter("@IsTimeOfTCGContact_Afternoon", SqlDbType.Bit) { Value = 1 },
            /* constant */
            new SqlParameter("@RequestNo", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@InputDataType", SqlDbType.Int) { Value = 0 },
            new SqlParameter("@IsTimeOfTCGContact_Night", SqlDbType.Bit) { Value = 0 },
            new SqlParameter("@User_Create", SqlDbType.VarChar, 10) { Value = "9991" }
        };

        try
        {
            requestNo = DB_SMEClinic.executeStoredProcedureScalar("proc_InsertRequestPGS10", parameters).ToString();
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertRequestPGS10() Error : " + ex, ref log4);
        }

        return requestNo;
    }

    public void InsertFieldData(string MasterData_KeyId, int FieldInfo_Id, string FieldValue)
    {
        SqlParameter[] parameters =
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = -1 },
            new SqlParameter("@MasterData_KeyId", SqlDbType.Int) { Value = MasterData_KeyId },
            new SqlParameter("@FieldInfo_Id", SqlDbType.Int) { Value = FieldInfo_Id },
            new SqlParameter("@FieldValue", SqlDbType.VarChar, 1000) { Value = FieldValue }
        };

        try
        {
            DB_SMEClinic.ExecuteStoredProcedureNonQuery("proc_InsertFieldData", parameters);
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertFieldData() Error : " + ex, ref log4);
        }
    }


    // New Function
    public bool UpdateUID(string uid, string customerProfileCode)
    {
        SqlParameter[] parameters =
        {
            new SqlParameter("@Uid", SqlDbType.VarChar) { Value = uid },
            new SqlParameter("@CustomerProfile_Code", SqlDbType.VarChar) { Value = customerProfileCode }
        };

        try
        {
            DB_SMEClinic.ExecuteStoredProcedureNonQuery("proc_UpdateConsent_CustomerProfile", parameters);
            return true;
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("UpdateUID Error : " + ex, ref log4);
        }

        return false;
    }

    public bool InsertUIDRegisterInfo(string uid, int registerInfoId, string infoType, string subInfoType)
    {
        SqlParameter[] parameters =
        {
            new SqlParameter("@UID", SqlDbType.VarChar) { Value = uid },
            new SqlParameter("@RegisterID", SqlDbType.Int) { Value = registerInfoId },
            new SqlParameter("@InfoType", SqlDbType.NVarChar) { Value = infoType },
            new SqlParameter("@SubInfoType", SqlDbType.NVarChar) { Value = subInfoType },
            new SqlParameter("@Channel", SqlDbType.VarChar) { Value = "LINEOA" }
        };

        try
        {
            DB_CustomerHealthCheck.ExecuteStoredProcedureNonQuery("InsertUIDMapRegister", parameters);
            return true;
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("InsertUIDRegisterInfo Error : " + ex, ref log4);
        }

        return false;
    }

    public DataTable GetCustomerProfileHistoryByCIDAndType(string uid, string idCardType)
    {
        DataTable dt = null;

        SqlParameter[] parameters =
        {
            new SqlParameter("@Uid", SqlDbType.NVarChar, 100) { Value = uid },
            new SqlParameter("@IdCardType", SqlDbType.NVarChar, 1) { Value = idCardType }
        };

        try
        {
            dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapCustomerProfileHistory", parameters)
                .Tables[0];
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetCustomerProfileByUID Error : " + ex, ref log4);
        }

        return dt;
    }

    public DataTable GetFieldName(int FieldGroupId)
    {
        DataTable dt = null;

        SqlParameter[] parameters =
        {
            new SqlParameter("@FieldGroupId", SqlDbType.Int) { Value = FieldGroupId }
        };

        try
        {
            dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetFieldName", parameters).Tables[0];
        }
        catch (Exception ex)
        {
            LogUtility.writeLog("GetFieldName Error : " + ex, ref log4);
        }

        return dt;
    }
}