using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scoring
{
    class Personal
    {
        public int scoreBizProvince(int bucket)
        {
            int score = 0;

            switch (bucket)
            {
                case 6: score = 82; break;
                case 5: score = 91; break;
                case 4: score = 112; break;
                case 3: score = 132; break;
                case 2: score = 155; break;
                case 1: score = 244; break;
            }
            return score;
        }

        public int scoreBizType(int bucket)
        {
            int score = 0;

            switch (bucket)
            {
                case 5: score = 119; break;
                case 4: score = 124; break;
                case 3: score = 128; break;
                case 2: score = 132; break;
                case 1: score = 140; break;
            }
            return score;
        }
        
        public int scoreMaritalStatus(int key)
        {
            int score = 0;

            switch (key)
            {
                case 0: score = 103; break; /* ไม่ระบุ */
                case 1: score = 119; break; /* โสด หย่าร้าง หม้าย */
                case 2: score = 136; break; /* สมรส */
            }
            return score;
        }

        public int scoreLoanAmount(double amount)
        {
            int score = 0;

            if (amount < 10000) { score = 87; }
            else if (amount <= 50000) { score = 111; }
            else if (amount <= 100000) { score = 124; }
            else if (amount < 20000000) { score = 138; }
            else { score = 158; }
            return score;
        }               

        public int scoreBizAge(int age)
        {
            int score = 0;

            if (age < 5)
            {
                score = 117;
            }
            else if (age < 10)
            {
                score = 127;
            }
            else if (age < 15)
            {
                score = 132;
            }
            else if (age < 20)
            {
                score = 135;
            }
            else
            {
                score = 139;
            }
            return score;
        }

        public int scoreManagementAge(int age)
        {
            int score = 0;

            if (age < 25)
            {
                score = 115;
            }
            else if (age < 35)
            {
                score = 124;
            }
            else if (age < 45)
            {
                score = 127;
            }
            else if (age < 60)
            {
                score = 129;
            }
            else
            {
                score = 131;
            }
            return score;
        }
    }
}
