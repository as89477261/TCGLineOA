using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerHealthController
{
    public class RegisterInfo
    {
        public PersonType personType;               /* กิจการคุณจดทะเบียนรูปแบบใด */
        public EstablishmentType officeType;        /* กรรมสิทธิ์ของสถานที่ประกอบกิจการ */
        public int yearIncorporate;                 /* ก่อตั้งกิจการมาแล้ว (กี่ปี) */
        public string industryCode;                 /* ประเภทกิจการของคุณ คือ */
        public string provinceCode;                 /* กิจการของคุณตั้งอยู่ที่จังหวัด */        
        public int ownerAge;                        /* ผู้บริหารหลักอายุ (กี่ปี) */
        public MaritalType maritalStatus;           /* สถานะภาพการสมรสของผู้บริหารหลัก */
        public int yearExperience;                  /* ประสบการณ์โดยตรงในการทําธุรกิจนี้ */
        public DebtStatusType debtStatus;           /* สถานะหนี้ของกิจการ */
        public int TdrAmount;                       /* จำนวน (ครั้งที่ปรับโครงสร้างหนี้) */
        public int TdrYear;                         /* ล่าสุดปีพ.ศ.(ที่ปรับโครงสร้างหนี้) */
        public double assetValue;                   /* มูลค่าสินทรัพย์รวมของกิจการ (ล้านบาท) */
        public double debtValue;                    /* หนี้สินรวมของกิจการ (ล้านบาท) */
        public double income;                       /* รายได้รวมของกิจการ (ต่อเดือน) */
        public double expense;                      /* กิจการคุณมีค่าใช้จ่าย (ต่อเดือน) */
        public double installmentAmount;            /* ภาระหนี้ที่ต้องผ่อนชําระ (ต่อเดือน) */
        public IsGetProfit isGetProfit;             /* 3 ปีที่ผ่านมา กิจการคุณมีรายได้เพิ่มขึ้น */
        //public ObjectiveTerm objectiveTerm;       /* วัตถุประสงค์ในการขอสินเชื่อ */
        public int objectiveTerm;                   /* วัตถุประสงค์ในการขอสินเชื่อ */
        public double loanAmount;                   /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท) */
        public int yearInstallment;                 /* ระยะเวลาในการผ่อนชําระที่คุณต้องการ (ปี) */
        public int id;                              /* ID ที่ insert เข้าระบบ */
        public int consent;                         /* เก็บหน้าสุดท้ายว่าลูกค้ายินยอมเปิดเผยข้อมูลส่วนบุคคลหรือเปล่า */
        public string requestNo;                    /* เลขใบคำขอใน clinic online */
        //public EventType eventType;               /* ที่มาของการติดต่อ */
        public int eventType;                       /* ที่มาของการติดต่อ */

        /* ข้อมูลเพิ่มเติมเพื่อลงทะเบียน */
        public string title;                        /* คำนำหน้า */
        public string name;                         /* ชื่อ */
        public string surname;                      /* นามสกุล */
        public string businessName;                 /* ชื่อกิจการ */
        public string phone;                        /* เบอร์โทร */
        public string idCard;                       /* เลขประชาชน เลขนิติบุคคล */
        public string remark;                       /* หมายเหตุ */

        public string uid;                          /* Line UID */
    }
}