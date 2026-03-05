using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerHealthCheck.Middleware
{
    public class SendMailHealthCheckModel
    {
            public string R05Title_Des_Thai { get; set; } = string.Empty; // คำนำนาม
            public string CustomerName { get; set; } = string.Empty; // ชื่อ
            public string CustomerSurname { get; set; } = string.Empty; // นามสกุล
            public string BusinessName { get; set; } = string.Empty; // ชื่อกิจการ
            public string MobilePhone { get; set; } = string.Empty; // เบอร์โทรศัพท์
            public string IdCard { get; set; } = string.Empty; // เลขบัตรประชาชน/เลขนิติบุคคล
            public string EventContact { get; set; } = string.Empty; // ช่องทางการติดต่อ
            public string EmailClinic { get; set; } = string.Empty; // อีเมลล์
            public string TypeBussiness { get; set; } = string.Empty; // รูปแบบธุรกิจ
            public string HC_EstablishmentType { get; set; } = string.Empty; // กรรมสิทธิ์สถานที่ประกอบการ
            public int HC_YearIncorporate { get; set; } // อายุกิจการ(ปี)
            public string R25Industry_Group_Name { get; set; } = string.Empty; // ประเภทกิจการ
            public string R04Province_Name { get; set; } = string.Empty; // จังหวัดที่ตั้งกิจการ
            public int HC_OwnerAge { get; set; } // อายุผู้บริหารหลัก
            public string HC_MaritalStatus { get; set; } = string.Empty; // สถานภาพการสมรสของผู้บริหาร
            public int HC_YearExperience { get; set; } // ประสบการณ์โดยตรงในการทำธุรกิจนี้
            public string HC_DebtStatus { get; set; } = string.Empty; // สถานะหนี้ปัจจุบันของกิจการ
            public decimal HC_AssetValue { get; set; } // มูลค่าสินทรัพย์รวมของกิจการ (บาท)
            public decimal HC_DebtValue { get; set; } // หนี้สินรวมของกิจการ (บาท)
            public decimal HC_Income { get; set; } // รายได้รวมของกิจการ (บาทต่อเดือน)
            public decimal HC_Expense { get; set; } // ค่าใช้จ่ายกิจการ (บาทต่อเดือน)
            public decimal HC_InstallmentAmount { get; set; } // ภาระหนี้ทั้งหมดที่ต้องผ่อนชำระ (ต่อเดือน)
            public string HC_IsGetProfit { get; set; } = string.Empty; // กิจการมีรายได้เพิ่มขึ้น
            public string ClinicObjectiveTerm { get; set; } = string.Empty; // วัตถุประสงค์ในการขอสินเชื่อ
            public decimal HC_LoanAmount { get; set; } // วงเงินสินเชื่อที่คุณต้องการ
            public int HC_YearInstallment { get; set; } // ระยะเวลาผ่อนชำระที่ต้องการ
            public string HC_GroupShortDesc { get; set; } = string.Empty; // Health Check (ผล)
            public string HC_GroupDesc { get; set; } = string.Empty; // Health Check (ผล)
            public string HC_Remark { get; set; } = string.Empty; // ข้อความเพื่อติดต่อกลับ
        
    }
}