using System;
using System.Collections.Generic;
using DAL.Repos.MasterData;
using DataModel.Models.MasterData;

namespace BLL.Controller.HealthCheck
{
    public class MasterDataCon
    {
        public class Product
        {
            private Product()
            {
            }

            public static Product Instance { get; } = new Product();

            public BaseModel<List<ProductModel>> GetProduct()
            {
                var result = new BaseModel<List<ProductModel>>();
                try
                {
                    var buffer = new ProductRepo();
                    var bufferResult = buffer.GetProductAll().ToListof<ProductModel>();
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
                    LocalLogManager.Logger(ex.GetBaseException().Message);
                    return result;
                }
            }

            public BaseModel<List<ProductModel>> GetProductByID(string id)
            {
                var result = new BaseModel<List<ProductModel>>();
                try
                {
                    var buffer = new ProductRepo();
                    var bufferResult = buffer.GetProductByID(id).ToListof<ProductModel>();
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

        public class Bank
        {
            private Bank()
            {
            }

            public static Bank Instance { get; } = new Bank();

            public BaseModel<List<BankModel>> GetBankAll()
            {
                var result = new BaseModel<List<BankModel>>();
                try
                {
                    var buffer = new BankRepo();
                    var bufferResult = buffer.GetBankAll().ToListof<BankModel>();
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

            public BaseModel<List<BankModel>> GetBankByID(string id)
            {
                var result = new BaseModel<List<BankModel>>();
                try
                {
                    var buffer = new BankRepo();
                    var bufferResult = buffer.GetBankByID(id).ToListof<BankModel>();
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

            public BaseModel<List<BankModel>> GetBankByProductID(string id)
            {
                var result = new BaseModel<List<BankModel>>();
                try
                {
                    var buffer = new BankRepo();
                    var bufferResult = buffer.GetBankByProductID(id).ToListof<BankModel>();
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
}