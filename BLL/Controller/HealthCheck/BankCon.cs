using System;
using System.Collections.Generic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.MasterData;

namespace BLL.Controller.HealthCheck
{
    public class BankCon
    {
        private BankCon()
        {
        }

        public static BankCon Instance { get; } = new BankCon();

        public BaseModel<List<BankModel>> GetBankProfile(string uid)
        {
            var result = new BaseModel<List<BankModel>>();
            try
            {
                var buffer = new BankRepo();
                var bufferResult = buffer.GetBankProfile(uid).ToListof<BankModel>();
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

        public BaseModel<List<BankModel>> GetAllBank()
        {
            var result = new BaseModel<List<BankModel>>();
            try
            {
                var buffer = new BankRepo();
                var bufferResult = buffer.GetAllBank().ToListof<BankModel>();
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

        public BaseModel<List<BankModel>> GetAllBankByID(string bankCode)
        {
            var result = new BaseModel<List<BankModel>>();
            try
            {
                var buffer = new BankRepo();
                var bufferResult = buffer.GetAllBankByID(bankCode).ToListof<BankModel>();
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

        public BaseModel<List<BankModel>> GetAllBankByListID(string listBankCode)
        {
            var result = new BaseModel<List<BankModel>>();
            try
            {
                var buffer = new BankRepo();
                var bufferResult = buffer.GetAllBankByListID(listBankCode).ToListof<BankModel>();
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