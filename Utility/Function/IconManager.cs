public class IconManager
{
    public static string GetIconStatus(object checkObject)
    {
        if (checkObject != null)
        {
            var status = checkObject.ToString();
            return status == "1" ? "~/images/ICON/btn_enable.png" : "~/images/ICON/btn_disable.png";
        }

        return "~/images/ICON/btn_default.png";
    }

    public static string GetIconKeyLock(object checkObject)
    {
        if (checkObject != null)
        {
            var status = checkObject.ToString();
            return status == "1" ? "~/images/ICON/lock.png" : "~/images/ICON/unlock.png";
        }

        return "~/images/ICON/btn_default.png";
    }

    public static string GetIconEnable(object checkObject)
    {
        if (checkObject != null)
        {
            var status = checkObject.ToString();
            return status == "1" ? "~/images/ICON/btn_enable.png" : "~/images/ICON/btn_disable.png";
        }

        return "~/images/ICON/btn_disable.png";
    }

    public static string GetIconVIP(object checkObject)
    {
        if (checkObject != null)
        {
            var status = checkObject.ToString();
            return status == "1" ? "~/images/ICON/btn_vip.png" : "~/images/ICON/btn_default.png";
        }

        return "~/images/ICON/btn_disable.png";
    }
}