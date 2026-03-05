using System.Collections.Generic;
using System.Linq;
using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.MasterData;

namespace CustomerHealthController
{
    public class CriteriaCon
    {
        private CriteriaCon()
        {
        }

        public static CriteriaCon Instance { get; } = new CriteriaCon();

        public RegisterInfoModel CheckDynamicCriteria(RegisterInfoModel regisInfo, ProductModel product)
        {
            var bufferCriteria = new List<ProductConditionModel>();
            var result = true;
            if (product != null)
            {
                if (regisInfo.PersonType == 1)
                    bufferCriteria = ProductConditionCon.Instance.GetProductCondition(product.ProductCode).RESULT_OBJ
                        .Where(x => x.CriteriaCustomerType == "Personal" || x.CriteriaCustomerType == "ALL").ToList();
                else if (regisInfo.PersonType == 2)
                    bufferCriteria = ProductConditionCon.Instance.GetProductCondition(product.ProductCode).RESULT_OBJ
                        .Where(x => x.CriteriaCustomerType == "Corporate" || x.CriteriaCustomerType == "ALL").ToList();
                else
                    bufferCriteria = ProductConditionCon.Instance.GetProductCondition(product.ProductCode).RESULT_OBJ;

                if (bufferCriteria != null && bufferCriteria.Count > 0)
                    for (var i = 0; i < bufferCriteria.Count; i++)
                    {
                        var regisFieldValue = GetValue(regisInfo, bufferCriteria[i].CriteriaSourceField);
                        var criteriaValue = bufferCriteria[i].CriteriaValue;
                        var criteriaType = bufferCriteria[i].CriteriaValueType;
                        var criteriaCondition = bufferCriteria[i].CriteriaCondition;

                        switch (criteriaType)
                        {
                            case "double":
                                var doubleRegisValue = double.Parse(regisFieldValue.ToString());
                                var doubleConditionValue = double.Parse(criteriaValue);
                                result = result && CompareDoubleValue(doubleRegisValue, doubleConditionValue,
                                    criteriaCondition);
                                break;
                            case "int":
                                var intRegisValue = int.Parse(regisFieldValue.ToString());
                                var intConditionValue = int.Parse(criteriaValue);
                                result = result && CompareIntValue(intRegisValue, intConditionValue, criteriaCondition);
                                break;
                            case "string":
                                var stringValue = criteriaValue;
                                break;
                        }
                    }
            }

            regisInfo.IsPassProductCriteria = result;
            return regisInfo;
        }

        private bool CompareIntValue(int firstValue, int secondValue, string condition)
        {
            switch (condition)
            {
                case "<=":
                    return firstValue <= secondValue;
                case ">=":
                    return firstValue >= secondValue;
                case "<":
                    return firstValue < secondValue;
                case ">":
                    return firstValue > secondValue;
            }

            return false;
        }

        private bool CompareDoubleValue(double firstValue, double secondValue, string condition)
        {
            switch (condition)
            {
                case "<=":
                    return firstValue <= secondValue;
                case ">=":
                    return firstValue >= secondValue;
                case "<":
                    return firstValue < secondValue;
                case ">":
                    return firstValue > secondValue;
            }

            return false;
        }


        public T GetAttribute<T>(string _name)
        {
            return (T)GetType().GetField(_name).GetValue(this);
        }

        public static object GetValue(RegisterInfoModel obj, string fieldName)
        {
            var nameOfProperty = fieldName;
            var propertyInfo = obj.GetType().GetProperty(nameOfProperty);
            var value = propertyInfo.GetValue(obj, null);

            return value;
        }
    }
}