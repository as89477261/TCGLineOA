
using CustomerHealthModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CustomerHealthController
{
    public class Calculate
    {
        RegisterDB service = new RegisterDB();
        public ScoreInfo calculateScore(RegisterInfo info)
        {
            ScoreInfo scoreInfo = new ScoreInfo();

            /* กรณี สถานะหนี้ของกิจการ เลือกคำตอบเป็น "อยู่ในกระบวนการทางกฎหมาย" */
            if (info.debtStatus == DebtStatusType.LegalProcess)
            {
                scoreInfo.scoreGroup = 3;
            }

            /* กรณี สถานะหนี้ของกิจการ เลือกคำตอบเป็น "ปรับโครงสร้างหนี้" */
            else if (info.debtStatus == DebtStatusType.TDR)
            {
                if (info.TdrAmount > 2)
                {
                    scoreInfo.scoreGroup = 3;
                }
                else if (info.TdrYear > DateTime.Now.Year - 2)
                {
                    scoreInfo.scoreGroup = 3;
                }
            }

            /* กรณี 3 ปีที่ผ่านมา กิจการคุณมีรายได้เพิ่มขึ้น เลือกคำตอบเป็น "ไม่ใช่" */
            else if (info.isGetProfit == IsGetProfit.No)
            {
                scoreInfo.scoreGroup = 3;
            }

            else
            {
                if (info.personType == PersonType.Person) /* บุคคลธรรมดา */
                {
                    Personal personal = new Personal();

                    int bucketProvince = service.GetBucketProvince(info.provinceCode, info.personType); /* เอารหัสจังหวัดไปหาค่า bucket ก่อน */
                    scoreInfo.score += personal.scoreProvince(bucketProvince); /* กิจการของคุณตั้งอยู่ที่จังหวัด */
                    int bucketIndustry = service.GetBucketIndustry(info.industryCode, info.personType); /* เอารหัสกลุ่มอุตสาหกรรมไปหาค่า bucket ก่อน */
                    scoreInfo.score += personal.scoreBizType(bucketIndustry); /* ประเภทกิจการของคุณ */
                    scoreInfo.score += personal.scoreYearExperience(info.yearExperience); /* ประสบการณ์โดยตรงในการทําธุรกิจนี้ */
                    scoreInfo.score += personal.scoreManagementAge(info.ownerAge); /* ผู้บริหารหลักอายุ */
                    scoreInfo.score += personal.scoreMaritalStatus(info.maritalStatus); /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ */
                    scoreInfo.score += personal.scoreLoanAmount(info.loanAmount); /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ */
                }
                else if (info.personType == PersonType.Corporate) /* นิติบุคคล */
                {
                    Corporate corp = new Corporate();

                    scoreInfo.score += corp.scoreLoanAmount(info.loanAmount); /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ */
                    scoreInfo.score += corp.scoreYearIncorporate(info.yearIncorporate); /* ก่อตั้งกิจการมาแล้วกี่ปี */
                    int bucketProvince = service.GetBucketProvince(info.provinceCode, info.personType); /* เอารหัสจังหวัดไปเป็นค่า bucket ก่อน */
                    scoreInfo.score += corp.scoreBizProvince(bucketProvince); /* กิจการของคุณตั้งอยู่ที่จังหวัด */
                    scoreInfo.score += corp.scoreEstablishmentStatus(info.officeType); /* กรรมสิทธิ์ของสถานที่ประกอบกิจการ */
                    scoreInfo.score += corp.scoreDebtToIncome(info.expense, info.income); /* กิจการคุณมีค่าใช้จ่าย หาร รายได้รวมของกิจการ */
                    scoreInfo.score += corp.scoreManagementAge(info.ownerAge); /* ผู้บริหารหลักอายุ */
                }
            }
            
            scoreInfo = service.GetHealthCheckScore(scoreInfo, info.personType);
            return scoreInfo;
        }
    }
}