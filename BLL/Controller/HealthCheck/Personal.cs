namespace CustomerHealthController
{
    public class Personal
    {
        public int scoreProvince(int bucket)
        {
            var score = 0;

            switch (bucket)
            {
                case 6:
                    score = 93;
                    break;
                case 5:
                    score = 114;
                    break;
                case 4:
                    score = 122;
                    break;
                case 3:
                    score = 133;
                    break;
                case 2:
                    score = 149;
                    break;
                case 1:
                    score = 175;
                    break;
            }

            return score;
        }

        public int scoreBizType(int bucket)
        {
            var score = 0;

            switch (bucket)
            {
                case 5:
                    score = 119;
                    break;
                case 4:
                    score = 124;
                    break;
                case 3:
                    score = 128;
                    break;
                case 2:
                    score = 132;
                    break;
                case 1:
                    score = 140;
                    break;
            }

            return score;
        }

        public int scoreMaritalStatus(MaritalType key)
        {
            var score = 0;

            switch (key)
            {
                case MaritalType.NoShow:
                    score = 103;
                    break; /* ไม่ระบุ */
                case MaritalType.Single:
                    score = 119;
                    break; /* โสด */
                case MaritalType.Divorce:
                    score = 119;
                    break; /* หย่าร้าง */
                case MaritalType.Widow:
                    score = 119;
                    break; /* หม้าย */
                case MaritalType.Married:
                    score = 136;
                    break; /* สมรส */
            }

            return score;
        }

        public int scoreLoanAmount(double amount)
        {
            var score = 0;

            if (amount <= 10000)
                score = 87;
            else if (amount <= 50000)
                score = 111;
            else if (amount <= 100000)
                score = 124;
            else if (amount < 20000000)
                score = 138;
            else
                score = 158;
            return score;
        }

        public int scoreYearExperience(int year)
        {
            var score = 0;

            if (year < 5)
                score = 117;
            else if (year < 10)
                score = 127;
            else if (year < 15)
                score = 132;
            else if (year < 20)
                score = 135;
            else
                score = 139;
            return score;
        }

        public int scoreManagementAge(int age)
        {
            var score = 0;

            if (age < 25)
                score = 115;
            else if (age < 35)
                score = 124;
            else if (age < 45)
                score = 127;
            else if (age < 60)
                score = 129;
            else
                score = 131;
            return score;
        }
    }
}