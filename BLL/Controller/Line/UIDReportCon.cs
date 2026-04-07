using DAL;
using DAL.Repos.Dashboard;
using DAL.Repos.FACenter;
using DataModel.Models.DCS;
using DataModel.Models.Line;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL.Controller
{
    public class LineDailyReportRepo
    {
        private LineDailyReportRepo()
        {
        }

        public static LineDailyReportRepo Instance { get; } = new LineDailyReportRepo();

        public BaseModel<string> GetSummaryUIDReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetSummaryUIDReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetLastYearSummaryUIDReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetLastYearSummaryUIDReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> GetSummaryUIDHaveLGReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetSummaryUIDHaveLGReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetLastYearSummaryUIDHaveLGReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetLastYearSummaryUIDHaveLGReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> GetSummaryUIDHaveDeptReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetSummaryUIDisDeptReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetLastYearSummaryUIDHaveDeptReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetLastYearSummaryUIDHaveDeptReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> GetKPICuurentlyUIDHaveActiveUserinPercentage(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetKPICuurentlyUIDHaveActiveUserinPercentage(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetKPICuurentlyUIDHaveActiveUserinPercentageForLinehasFallen(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetKPICuurentlyUIDHaveActiveUserinPercentageForLinehasFallen(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetKPICurrentlyUIDHaveLGinPercentage(string yearList)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetKPICurrentlyUIDHaveLGinPercentage(yearList);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetKPICurrentlyUIDHaveLGPlusinPercentage(string yearList)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetKPICurrentlyUIDHaveLGPlusinPercentage(yearList);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> GetSummaryUIDKYCReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetSummaryUIDKYCReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetLastYearSummaryUIDKYCReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetLastYearSummaryUIDKYCReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<string> GetSummaryUID5ColorReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetSummaryUID5ColorReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> GetLastYearSummaryUID5ColorReport(string startDate, string endDate)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetLastYearSummaryUID5ColorReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult.Rows[0][0].ToString();
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<DataTable> GetDataUID5ColorReport(string startDate, string endDate)
        {
            var result = new BaseModel<DataTable>();
            try
            {
                var buffer = new DAL.LineDailyReportRepo();
                var bufferResult = buffer.GetDataUID5ColorReport(startDate, endDate);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();

                }
                else
                {
                    result.SetNotfound();
                }
                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

    }
}