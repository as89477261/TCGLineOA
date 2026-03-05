using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DAL.Repos.MasterData;
using DAL.Repos.NDIDInfo;
using DataModel.Models.LOG;
using DataModel.Models.NDID;

namespace BLL.Controller
{
    public class LogActivityCon
    {
        private LogActivityCon()
        {
        }

        public static LogActivityCon Instance { get; } = new LogActivityCon();

        public void InsertFixObjAndMultitaskingLogActivity(string uid, LogActivityEnum logActivity, string remark = "")
        {
            var obj = GenLogActivityObject(uid, logActivity, remark);

            Task.Run(() =>
           {
               InsertLogActivity(obj);
           });
        }

        public void InsertFixObjAndMultitaskingLogActivity(LogActivity obj)
        {
            Task.Run(() =>
           {
               InsertLogActivity(obj);
           });
        }


        public BaseModel<string> InsertLogActivity(LogActivity obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new LogActivityRepo();
                var bufferResult = buffer.InsertLogActivity(obj);
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

        //---////////////////////////////////
        //---////////////////////////////////


        // -- ///   มีเบสดีๆสักหลังแล้ว มาปรับเป็นดึงจากเบส
        public enum LogActivityEnum
        {
            Main_Load,
            History_Load,
            Profile_Load,

            Events_Load,
            Events_DIPROM_Load,
            Events_SET_Load,
            Events_PGS10_Load,
            Events_TCGxGSB_Load,
            Events_TCGxEXIM_Load,
            Events_TCGxSET_Load,
            Events_TCCProject_Load,

            HealthCheck_Load,
            TCGRegister_Load,
            MyLG_Load,
            MyBill_Load,
            Debt_Load,
            Debt_HoldingCode21_Load, //แยกหนี้ ออกจาก Events เนื่องจากพักชำรพต้องมีการ KYC ทุกครั้งซึ่งอาจทำครั้งแรกครั้งเดียวแต่ Events หลากหลายมาก อาจต้อง customize บ่อยๆ 
            Debt_3Color_Load,

            FA_Doctor_Load,
            NDIDConfirmRequest_Load,
            NDIDConfirmRequest_CHooseBank_Load,
            Calculate_Load,
            PDPA_Load,

        }

        private LogActivity GenLogActivityObject(string uid, LogActivityEnum activityType, string remark = "")
        {
            var obj = new LogActivity();
            obj.UID = uid;
            obj.Status = true;
            obj.CreateBy = "System";
            obj.Remark = remark;

            switch (activityType)
            {
                case LogActivityEnum.Main_Load:
                    obj.ApplicationCode = "APP01";
                    obj.SubApplicationCode = "SAPP01001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.History_Load:
                    obj.ApplicationCode = "APP02";
                    obj.SubApplicationCode = "SAPP02001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Profile_Load:
                    obj.ApplicationCode = "APP03";
                    obj.SubApplicationCode = "SAPP03001";
                    obj.ActivityCode = "ACT001";
                    break;

                //-- Events ---////////////////
                case LogActivityEnum.Events_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Events_DIPROM_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04002";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Events_SET_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04003";
                    obj.ActivityCode = "ACT001";
                    break;

                case LogActivityEnum.Events_PGS10_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04004";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Events_TCGxGSB_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04005";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Events_TCGxEXIM_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04006";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Events_TCGxSET_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04007";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Events_TCCProject_Load:
                    obj.ApplicationCode = "APP04";
                    obj.SubApplicationCode = "SAPP04008";
                    obj.ActivityCode = "ACT001";
                    break;


                case LogActivityEnum.HealthCheck_Load:
                    obj.ApplicationCode = "APP05";
                    obj.SubApplicationCode = "SAPP05001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.TCGRegister_Load:
                    obj.ApplicationCode = "APP06";
                    obj.SubApplicationCode = "SAPP06001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.MyLG_Load:
                    obj.ApplicationCode = "APP07";
                    obj.SubApplicationCode = "SAPP07001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.MyBill_Load:
                    obj.ApplicationCode = "APP08";
                    obj.SubApplicationCode = "SAPP08001";
                    obj.ActivityCode = "ACT001";
                    break;




                //-- Debt ---////////
                case LogActivityEnum.Debt_Load:
                    obj.ApplicationCode = "APP09";
                    obj.SubApplicationCode = "SAPP09001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Debt_HoldingCode21_Load:
                    obj.ApplicationCode = "APP09";
                    obj.SubApplicationCode = "SAPP09002";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Debt_3Color_Load:
                    obj.ApplicationCode = "APP09";
                    obj.SubApplicationCode = "SAPP09003";
                    obj.ActivityCode = "ACT001";
                    break;


                case LogActivityEnum.FA_Doctor_Load:
                    obj.ApplicationCode = "APP10";
                    obj.SubApplicationCode = "SAPP10001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.NDIDConfirmRequest_Load:
                    obj.ApplicationCode = "APP11";
                    obj.SubApplicationCode = "SAPP11001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.NDIDConfirmRequest_CHooseBank_Load:
                    obj.ApplicationCode = "APP11";
                    obj.SubApplicationCode = "SAPP11002";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.Calculate_Load:
                    obj.ApplicationCode = "APP12";
                    obj.SubApplicationCode = "SAPP12001";
                    obj.ActivityCode = "ACT001";
                    break;
                case LogActivityEnum.PDPA_Load:
                    obj.ApplicationCode = "APP13";
                    obj.SubApplicationCode = "SAPP13001";
                    obj.ActivityCode = "ACT001";
                    break;

                default:
                    break;
            }

            return obj;
        }

    }
}