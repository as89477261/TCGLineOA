using System.Web.UI.WebControls;

public class BasePdpaApiModel<T>
{
    public T result { get; set; }

    public string targetUrl { get; set; } = null; 

    public bool success { get; set; } = false;

    public string error { get; set; }

    public bool unAuthorizedRequest { get; set; } = true;

    public bool __abp {  get; set; } =  false;

}
