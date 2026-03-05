using System;

public class BaseModel<T> : BaseObject
{
    public BaseModel()
    {
        RESULT_STATUS = "";
        RESULT_CODE = "";
        RESULT_MESSAGE = "";
    }

    public T RESULT_OBJ { get; set; }

    public void SetSuccess()
    {
        RESULT_STATUS = "OK";
        RESULT_CODE = "200";
        RESULT_MESSAGE = "Success";
    }

    public void SetNotfound()
    {
        RESULT_STATUS = "FAIL";
        RESULT_CODE = "400";
        RESULT_MESSAGE = "No Content";
    }

    public Exception SetException(Exception ex)
    {
        RESULT_STATUS = "EXP";
        RESULT_CODE = "500";
        RESULT_MESSAGE = ex.Message;

        return ex;
    }
}