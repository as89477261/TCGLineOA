using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL
{
    public class LineDailyReportRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetSummaryUIDReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT  count(uid)
                            FROM [DB_SMEClinic].[dbo].[Uid]
                            where  1=1 and uid is not null and uid != '' ";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetSummaryUIDReport Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetLastYearSummaryUIDReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT  count(uid)
                            FROM [DB_SMEClinic].[dbo].[Uid]
                            where  1=1 and CAST(CreateDateTime AS DATE) >= '" + startDate + @"' and CAST(CreateDateTime AS DATE) <= '" + endDate + @"' and uid is not null and uid != '' ";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetLastYearSummaryUIDReport Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetSummaryUIDHaveLGReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"select count(idcard) countUIDHaveLG from (
                            select distinct a.idcard,b.[T06Name_Thai_Customer],T06Date_Create,T08LG_No,T08LG_Date,T08Active,T08Status_LG,d.R07Status_Name from (
                            SELECT [IdCard] idcard,CreateDateTime cd FROM [DB_SMEClinic].[dbo].[V_UIDMapCustomerProfileHistory] where uid is not null and uid != '' and idcard is not null and idcard != ''  and len(IdCard) = 13 
                            union 
                            SELECT      [IdCard] idcard,CreateDate cd FROM [DB_CustomerHealthCheck].[dbo].[RegisterInfo] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            union
                            SELECT     b.IdentityID idcard,a.CreatedDate cd FROM [DB_CustomerHealthCheck].[dbo].[TPT_UIDMapEnrollment] a  join [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] b on a.RegisterID = b.DummyID
                             where IdentityID is not null and IdentityID != '' and len(IdentityID) = 13 
                            union
                            SELECT      [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDept] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union
                            SELECT      [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDIPROM] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union
                            SELECT       [IDCard] idcard,CreatedDate cd FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFAEvent] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            ) a 

                             join [DB_SICGC3].[dbo].[T06_Customer] b on a.idcard = b.[T06Card_ID] 
                             join [DB_SICGC3].[dbo].[T08_LG] c on b.T06Customer_Code = c.T08Customer_Code 
                            left join [DB_SICGC3].[dbo].[R07_Status] d on c.T08Status_LG = d.R07Status_Code and d.R07Status_Group = 'B' and T08Status_LG = '100'
                             where 1=1
                             and T08Status_LG = '100' ) d";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetLastYearSummaryUIDHaveLGReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"select count(idcard) countUIDHaveLG from (
                            select distinct a.idcard,b.[T06Name_Thai_Customer],T06Date_Create,T08LG_No,T08LG_Date from (
                            SELECT [IdCard] idcard,CreateDateTime cd FROM [DB_SMEClinic].[dbo].[V_UIDMapCustomerProfileHistory] where uid is not null and uid != '' and idcard is not null and idcard != ''  and len(IdCard) = 13 
                            and CAST(CreateDateTime AS DATE) >= '" + startDate + @"' and CAST(CreateDateTime AS DATE) <= '" + endDate + @"'
                            union 
                            SELECT      [IdCard] idcard,CreateDate cd FROM [DB_CustomerHealthCheck].[dbo].[RegisterInfo] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            and CAST(CreateDate AS DATE) >= '" + startDate + @"' and CAST(CreateDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT     b.IdentityID idcard,a.CreatedDate cd FROM [DB_CustomerHealthCheck].[dbo].[TPT_UIDMapEnrollment] a  join [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] b on a.RegisterID = b.DummyID
                             where IdentityID is not null and IdentityID != '' and len(IdentityID) = 13 
                            and CAST(a.CreatedDate AS DATE) >= '" + startDate + @"' and CAST(a.CreatedDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT      [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDept] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            and CAST(CreatedDate AS DATE) >= '" + startDate + @"' and CAST(CreatedDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT      [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDIPROM] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            and CAST(CreatedDate AS DATE) >= '" + startDate + @"' and CAST(CreatedDate AS DATE) <='" + endDate + @"'
                            union
                            SELECT       [IDCard] idcard,CreatedDate cd FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFAEvent] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            and CAST(CreatedDate AS DATE) >= '" + startDate + @"' and CAST(CreatedDate AS DATE) <= '" + endDate + @"' ) a 

                            join [DB_SICGC3].[dbo].[T06_Customer] b on a.idcard = b.[T06Card_ID] 
                            join [DB_SICGC3].[dbo].[T08_LG] c on b.T06Customer_Code = c.T08Customer_Code 
                            where 1=1 and SUBSTRING(T08LG_Date, 1, 4) = '2568' and T08Status_LG = '100' ) d";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetSummaryUIDisDeptReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @" select distinct a.idcard,b.[T06Name_Thai_Customer],T06Date_Create 
                            into #tmp1 
                            from (
                            SELECT [IdCard] idcard FROM [DB_SMEClinic].[dbo].[V_UIDMapCustomerProfileHistory] where uid is not null and uid != '' and idcard is not null and idcard != ''  and len(IdCard) = 13 
                            union 
                            SELECT      [IdCard] idcard FROM [DB_CustomerHealthCheck].[dbo].[RegisterInfo] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            union
                            SELECT     b.IdentityID idcard FROM [DB_CustomerHealthCheck].[dbo].[TPT_UIDMapEnrollment] a  join [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] b on a.RegisterID = b.DummyID
                            where IdentityID is not null and IdentityID != '' and len(IdentityID) = 13
                            union
                            SELECT      [IdentityCard] idcard   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDept] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union
                            SELECT      [IdentityCard] idcard   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDIPROM] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union
                            SELECT       [IDCard] idcard FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFAEvent] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            ) a 
                            join [DB_SICGC3].[dbo].[T06_Customer] b on a.idcard = b.[T06Card_ID]

                            SELECT DebtorCode , IDCard , ContactName , StatusDebt 
                            into #tmpDebt
                            FROM [192.168.0.64].[DB_DCS].[dbo].[DT_Debtor] b WITH(NOLOCK)
                           
                            SELECT count(a.idcard) FROM #tmp1 a
                            LEFT JOIN #tmpDebt b WITH(NOLOCK) ON  a.idcard = b.IDCard
                            where b.debtorcode is not null
                           
                            drop table #tmp1
                            drop table #tmpDebt
                            ";
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetLastYearSummaryUIDHaveDeptReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"select distinct a.idcard,b.[T06Name_Thai_Customer],T06Date_Create 
                            into #tmp1 
                            from (
                            SELECT [IdCard] idcard FROM [DB_SMEClinic].[dbo].[V_UIDMapCustomerProfileHistory] where uid is not null and uid != '' and idcard is not null and idcard != ''  and len(IdCard) = 13 
                            and CAST(CreateDateTime AS DATE) >= '" + startDate + @"' and CAST(CreateDateTime AS DATE) <= '" + endDate + @"'
                            union 
                            SELECT      [IdCard] idcard FROM [DB_CustomerHealthCheck].[dbo].[RegisterInfo] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            and CAST(CreateDate AS DATE) >= '" + startDate + @"' and CAST(CreateDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT     b.IdentityID idcard FROM [DB_CustomerHealthCheck].[dbo].[TPT_UIDMapEnrollment] a  join [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] b on a.RegisterID = b.DummyID
                             where IdentityID is not null and IdentityID != '' and len(IdentityID) = 13
                            and CAST(a.CreatedDate AS DATE) >= '" + startDate + @"' and CAST(a.CreatedDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT      [IdentityCard] idcard   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDept] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            and CAST(CreatedDate AS DATE) >= '" + startDate + @"' and CAST(CreatedDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT      [IdentityCard] idcard   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDIPROM] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            and CAST(CreatedDate AS DATE) >= '" + startDate + @"' and CAST(CreatedDate AS DATE) <= '" + endDate + @"'
                            union
                            SELECT       [IDCard] idcard FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFAEvent] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            and CAST(CreatedDate AS DATE) >= '" + startDate + @"' and CAST(CreatedDate AS DATE) <= '" + endDate + @"'
                            ) a 
                            join [DB_SICGC3].[dbo].[T06_Customer] b on a.idcard = b.[T06Card_ID]


                            SELECT DebtorCode , IDCard , ContactName , StatusDebt 
                            into #tmpDebt
                            FROM [192.168.0.64].[DB_DCS].[dbo].[DT_Debtor] b WITH(NOLOCK) 


                            SELECT count(a.idcard) FROM #tmp1 a
                            LEFT JOIN #tmpDebt b WITH(NOLOCK) ON  a.idcard = b.IDCard
                            where b.debtorcode is not null


                            drop table #tmp1
                            drop table #tmpDebt";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetKPICuurentlyUIDHaveActiveUserinPercentage(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT count( distinct [Uid]) FROM [DB_CustomerHealthCheck].[dbo].[TPT_LogActivity]  where CreateDate >= '" + startDate + "' ";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetKPICuurentlyUIDHaveActiveUserinPercentageForLinehasFallen(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT count( distinct [Uid]) FROM [DB_SMEClinic].[dbo].[Uid]  where CAST(CreateDateTime AS DATE) >= '" + startDate + "' and CAST(CreateDateTime AS DATE) <= '" + endDate + "' ";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetKPICurrentlyUIDHaveLGinPercentage(string yearList)
        {
            DataTable dt = null;

            string sql = @" select count(d.idcard) from (
                            select distinct a.idcard,b.[T06Name_Thai_Customer],T06Date_Create,T08LG_No,T08LG_Date,T08Active,T08Status_LG,d.R07Status_Name from (
                            SELECT [IdCard] idcard,CreateDateTime cd FROM [DB_SMEClinic].[dbo].[V_UIDMapCustomerProfileHistory] where uid is not null and uid != '' and idcard is not null and idcard != ''  and len(IdCard) = 13 
                            union 
                            SELECT      [IdCard] idcard,CreateDate cd FROM [DB_CustomerHealthCheck].[dbo].[RegisterInfo] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            union
                            SELECT     b.IdentityID idcard,a.CreatedDate cd FROM [DB_CustomerHealthCheck].[dbo].[TPT_UIDMapEnrollment] a  join [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] b on a.RegisterID = b.DummyID
                             where IdentityID is not null and IdentityID != '' and len(IdentityID) = 13 
                            union
                            SELECT      [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDept] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union
                            SELECT      [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDIPROM] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union
                            SELECT       [IDCard] idcard,CreatedDate cd FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFAEvent] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            ) a 

                             join [DB_SICGC3].[dbo].[T06_Customer] b on a.idcard = b.[T06Card_ID] 
                             join [DB_SICGC3].[dbo].[T08_LG] c on b.T06Customer_Code = c.T08Customer_Code 
                             left join [DB_SICGC3].[dbo].[R07_Status] d on c.T08Status_LG = d.R07Status_Code and d.R07Status_Group = 'B' and T08Status_LG = '100'
                             where 1=1
                             and T08Status_LG = '100'
                             and SUBSTRING(T08LG_Date, 1, 4) in (" + yearList + ")) d";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetKPICurrentlyUIDHaveLGPlusinPercentage(string yearList)
        {
            DataTable dt = null;

            string sql = @"select count(uid) from ( 
                            SELECT distinct (a.[Uid]) uid FROM [DB_CustomerHealthCheck].[dbo].[TPT_LogActivity] a  
                            join (select distinct uid,a.idcard,b.[T06Name_Thai_Customer],T06Date_Create,T08LG_No,T08LG_Date,T08Active,T08Status_LG,d.R07Status_Name from (
                            SELECT uid, [IdCard] idcard,CreateDateTime cd FROM [DB_SMEClinic].[dbo].[V_UIDMapCustomerProfileHistory] where uid is not null and uid != '' and idcard is not null and idcard != ''  and len(IdCard) = 13 
                            union SELECT uid,  b.IdentityID idcard,a.CreatedDate cd FROM [DB_CustomerHealthCheck].[dbo].[TPT_UIDMapEnrollment] a  join [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] b on a.RegisterID = b.DummyID where IdentityID is not null and IdentityID != '' and len(IdentityID) = 13 
                            union SELECT   uid,   [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDept] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union SELECT   uid,   [IdentityCard] idcard,CreatedDate cd   FROM [DBFA_CENTER].[dbo].[TPT_UIDMapDIPROM] where [IdentityCard] is not null and [IdentityCard] != '' and len([IdentityCard]) = 13 
                            union SELECT   uid,    [IDCard] idcard,CreatedDate cd FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFAEvent] where idcard is not null and idcard != '' and len(IdCard) = 13 
                            ) a 
                            join [DB_SICGC3].[dbo].[T06_Customer] b on a.idcard = b.[T06Card_ID] 
                            join [DB_SICGC3].[dbo].[T08_LG] c on b.T06Customer_Code = c.T08Customer_Code 
                            left join [DB_SICGC3].[dbo].[R07_Status] d on c.T08Status_LG = d.R07Status_Code and d.R07Status_Group = 'B' and T08Status_LG = '100'
                            where 1=1 and T08Status_LG = '100' and (SUBSTRING(T08LG_Date, 1, 4) not in (" + yearList + @") )
                            ) b on a.UID = b.Uid where year(a.CreateDate) = '2025'                            
                            ) x";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetSummaryUIDKYCReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT count(*)  FROM [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal] a  where IsDummy = 0 ";
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetSummaryUIDKYCReport Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetLastYearSummaryUIDKYCReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT count(*)  FROM [DB_TCGID].[dbo].[TCGID_T_Enrolment_Personal]  where CAST([CreatedDate] AS DATE) >= '" + startDate + "' and CAST([CreatedDate] AS DATE) <= '" + endDate + "' and IsDummy = 0 ";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetLastYearSummaryUIDKYCReport Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetSummaryUID5ColorReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT count(uid)  FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFATransaction] ";
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetSummaryUID5ColorReport Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetLastYearSummaryUID5ColorReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT count(uid)  FROM [DBFA_CENTER].[dbo].[TPT_UIDMapFATransaction]  where CAST([CreateDate] AS DATE) >= '" + startDate + "' and CAST([CreateDate] AS DATE) <= '" + endDate + "' ";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetLastYearSummaryUID5ColorReport Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetActiveUserReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT  [Uid],[CreateDateTime],[Uid_Channel],[Amr],[Aud],[Email],[Exp],[Iat],[Iss],[Name],[Nonce],[Picture],[UpdateTime],[SystemCreateDate]
                            FROM [DB_SMEClinic].[dbo].[Uid]
                            where  1=1 and [CreateDateTime] < '10/21/2025' and uid is not null and uid != ''
                            order by SystemCreateDate desc";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }
        public DataTable GetReport(string startDate, string endDate)
        {
            DataTable dt = null;

            string sql = @"SELECT  [Uid],[CreateDateTime],[Uid_Channel],[Amr],[Aud],[Email],[Exp],[Iat],[Iss],[Name],[Nonce],[Picture],[UpdateTime],[SystemCreateDate]
                            FROM [DB_SMEClinic].[dbo].[Uid]
                            where  1=1 and [CreateDateTime] < '10/21/2025' and uid is not null and uid != ''
                            order by SystemCreateDate desc";

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteCommandTextReturnDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }

    }
}