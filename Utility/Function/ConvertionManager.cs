using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class ConvertionManager
{
    public static byte[] imageToByteArray(Image imageIn)
    {
        var ms = new MemoryStream();
        imageIn.Save(ms, ImageFormat.Gif);
        return ms.ToArray();
    }

    public static Image byteArrayToImage(byte[] byteArrayIn)
    {
        var ms = new MemoryStream(byteArrayIn);
        var returnImage = Image.FromStream(ms);
        return returnImage;
    }

    public static string NullableDateToString(DateTime? date, string format = "dd/MM/yyyy")
    {
        DateTime UpdatedTime;

        if (date.HasValue)
        {
            UpdatedTime = date.Value;
            return UpdatedTime.ToString(format);
        }

        return "";
    }
}