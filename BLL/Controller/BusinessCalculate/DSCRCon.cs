using System;
using System.Configuration;

namespace BLL.Controller
{
    public class DSCRCon
    {
        private DSCRCon()
        {
        }

        public static DSCRCon Instance { get; } = new DSCRCon();

        public BaseModel<RegisterInfo> CalculateTermLoan(RegisterInfo obj)
        {
            var result = new BaseModel<RegisterInfo>();
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            try
            {
                // Step 1
                var percent1 = int.Parse(ConfigurationManager.AppSettings["Percent01"]);
                var percent2 = double.Parse(ConfigurationManager.AppSettings["Percent02"]);
                p1 = obj.income - obj.CostSale - obj.expense;

                if (obj.LoanLCTR + obj.LoanPN + obj.LoanOD + obj.LoanTL + obj.LoanOther > 0)
                    p2 = obj.installmentAmount
                         + (obj.LoanLCTR + obj.LoanPN + obj.LoanOD + obj.LoanTL + obj.LoanOther) * percent1 / 100 / 12
                         + obj.LoanLG * percent2 / 100 / 12;

                if (obj.LoanTL + obj.LoanOther > 0) p3 = (obj.LoanTL + obj.LoanOther) / (obj.yearInstallment * 12);


                var bufferResult = p1 / (p2 + p3);
                obj.DSCR = bufferResult < -9.99 ? -9.99 : bufferResult;

                if (bufferResult != null)
                {
                    result.RESULT_OBJ = obj;
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

        public BaseModel<RegisterInfo> CalculateRevolvingLoan(RegisterInfo obj)
        {
            var result = new BaseModel<RegisterInfo>();
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            try
            {
                // Step 1
                var percent1 = int.Parse(ConfigurationManager.AppSettings["Percent01"]);
                var percent2 = double.Parse(ConfigurationManager.AppSettings["Percent02"]);
                p1 = obj.income - obj.CostSale - obj.expense;

                if (obj.LoanLCTR + obj.LoanPN + obj.LoanOD + obj.LoanTL + obj.LoanOther > 0)
                    p2 = obj.installmentAmount
                         + (obj.LoanLCTR + obj.LoanPN + obj.LoanOD + obj.LoanTL + obj.LoanOther) * percent1 / 100 / 12
                         + obj.LoanLG * percent2 / 100 / 12;

                if (obj.LoanTL + obj.LoanOther > 0) p3 = (obj.LoanTL + obj.LoanOther) / (obj.yearInstallment * 12);


                var bufferResult = p1 / (p2 + p3);
                obj.DSCR = bufferResult < -9.99 ? -9.99 : bufferResult;
                ;

                if (bufferResult != null)
                {
                    result.RESULT_OBJ = obj;
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

        public BaseModel<RegisterInfo> CalculateTermAndRevolvingLoan(RegisterInfo obj)
        {
            var result = new BaseModel<RegisterInfo>();
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            try
            {
                // Step 1
                var percent1 = int.Parse(ConfigurationManager.AppSettings["Percent01"]);
                var percent2 = double.Parse(ConfigurationManager.AppSettings["Percent02"]);
                p1 = obj.income - obj.CostSale - obj.expense;

                if (obj.LoanLCTR + obj.LoanPN + obj.LoanOD + obj.LoanTL + obj.LoanOther > 0)
                    p2 = obj.installmentAmount
                         + (obj.LoanLCTR + obj.LoanPN + obj.LoanOD + obj.LoanTL + obj.LoanOther) * percent1 / 100 / 12
                         + obj.LoanLG * percent2 / 100 / 12;

                if (obj.LoanTL + obj.LoanOther > 0) p3 = (obj.LoanTL + obj.LoanOther) / (obj.yearInstallment * 12);


                var bufferResult = p1 / (p2 + p3);
                obj.DSCR = bufferResult < -9.99 ? -9.99 : bufferResult;
                ;


                if (bufferResult != null)
                {
                    result.RESULT_OBJ = obj;
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