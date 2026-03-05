using System;

namespace CustomerHealthController
{
    public class Corporate
    {
        public int scoreLoanAmount(double amount)
        {
            var score = 0;

            if (amount < 100000)
                score = 94;
            else if (amount < 3000000)
                score = 133;
            else if (amount < 5000000)
                score = 144;
            else if (amount < 12000000)
                score = 151;
            else
                score = 153;
            return score;
        }

        public int scoreYearIncorporate(int year)
        {
            var score = 0;
            year = (DateTime.Now.Year > 2500 ? DateTime.Now.Year : DateTime.Now.Year + 543) - year - 1;

            if (year > 2561)
                score = 131;
            else if (year > 2555)
                score = 112;
            else if (year > 2545)
                score = 128;
            else if (year > 2535)
                score = 136;
            else if (year > 2520)
                score = 138;
            else if (year >= 2443)
                score = 145;
            else
                score = 131; /* Outlier */

            return score;
        }

        public int scoreBizProvince(int bucket)
        {
            var score = 0;

            switch (bucket)
            {
                case 6:
                    score = 82;
                    break;
                case 5:
                    score = 91;
                    break;
                case 4:
                    score = 112;
                    break;
                case 3:
                    score = 132;
                    break;
                case 2:
                    score = 155;
                    break;
                case 1:
                    score = 244;
                    break;
            }

            return score;
        }

        public int scoreEstablishmentStatus(EstablishmentType key)
        {
            var score = 0;

            switch (key)
            {
                case EstablishmentType.OfficeOwner:
                    score = 129;
                    break; /* ไม่ใช่ที่เช่า เป็นเจ้าของ */
                case EstablishmentType.OfficeRental:
                    score = 110;
                    break; /* ที่เช่า */
                case EstablishmentType.NoShow:
                    score = 149;
                    break; /* ไม่ระบุ */
            }

            return score;
        }

        public int scoreDebtToIncome(double debt, double income)
        {
            var score = 0;

            var ratio = debt / income;
            if (ratio >= 3)
                score = 92;
            else if (ratio >= 2)
                score = 110;
            else if (ratio >= 1)
                score = 116;
            else if (ratio >= 0.5)
                score = 133;
            else
                score = 135;
            return score;
        }

        public int scoreManagementAge(int age)
        {
            var score = 0;

            if (age <= 25)
                score = 106;
            else if (age <= 30)
                score = 118;
            else if (age <= 50)
                score = 130;
            else if (age <= 60)
                score = 136;
            else
                score = 147;
            return score;
        }
    }
}