using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Windows;

public static class ExtensionManager
{
    public static string ToThaiDate(this DateTime dt)
    {
        var result = dt.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
        return result;
    }

    public static string ToYoutubeEmbeded(this string url, string YoutubeMiddleNameFrom, string youtubeMiddleNameTo)
    {
        if (url != null && url != "")
        {
            var result = url.Replace(YoutubeMiddleNameFrom, youtubeMiddleNameTo);
            return result;
        }

        return url;
    }

    public static string ToStringWithZero(this object obj)
    {
        if (obj != null)
        {
            var data = obj.ToString();
            return data;
        }

        return "0";
    }

    public static string ToStringWithCheck(this string obj)
    {
        if (!string.IsNullOrEmpty(obj))
            return obj;
        return " - ";
    }

    public static string ToStringWithEmpty(this object obj)
    {
        if (obj != null)
        {
            var data = obj.ToString();
            return data;
        }

        return "";
    }

    public static string ToReplaceWithEmpty(this string obj, string oldString, string newString)
    {
        if (!string.IsNullOrEmpty(obj))
            return obj.Replace(oldString, newString);
        return "";
    }


    // Base64 Decode Encode 
    public static string EncodeBase64(this string value)
    {
        var valueBytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(valueBytes);
    }

    public static string DecodeBase64(this string value)
    {
        var valueBytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(valueBytes);
    }

    public static byte[] ReadAllBytes(this Stream instream)
    {
        if (instream is MemoryStream)
            return ((MemoryStream)instream).ToArray();

        using (var memoryStream = new MemoryStream())
        {
            instream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }

    public static void RedirectWithData(NameValueCollection data, string url)
    {
        var response = HttpContext.Current.Response;
        response.Clear();

        var s = new StringBuilder();
        s.Append("<html>");
        s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
        s.AppendFormat("<form name='form' action='{0}' method='post'>", url);
        foreach (string key in data) s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", key, data[key]);
        s.Append("</form></body></html>");
        response.Write(s.ToString());
        response.End();
    }

    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        if (e is Enum)
        {
            var type = e.GetType();
            var values = Enum.GetValues(type);

            foreach (int val in values)
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null) return descriptionAttribute.Description;
                }
        }

        return null; // could also return string.Empty
    }

    public static string DateTimeCulture(this DateTime item, string format = "dd/MM/yyyy HH:mm:ss")
    {
        if (item == null || string.IsNullOrEmpty(item.ToString())) return null;

        return item.ToString(format, new CultureInfo("th-TH"));
    }

    public static T To<T>(this DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
            foreach (DataRow row in dt.Rows)
            {
                var item = GetItem<T>(row);
                return item;
            }

        return default;
    }

    public static List<T> ToList<T>(this DataTable dt)
    {
        var data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            var item = GetItem<T>(row);
            data.Add(item);
        }

        return data;
    }

    public static List<T> ToListof<T>(this DataTable dt)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
        if (dt != null)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties =>
                             columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                return instanceOfT;
            }).ToList();

            return targetList;
        }

        return null;
    }


    // Money


    public static string StringToMoneyFormat(this string txt, bool isNoDigit = false)
    {
        try
        {
            decimal n;
            n = Math.Round(Convert.ToDecimal(txt), 2);

            string newTxt;
            newTxt = n.ToString("N");
            if (isNoDigit) newTxt = newTxt.Replace(".00", "");

            //txt = txt.Replace(",", ".");
            //string newtxt = string.Format("{0:#.00}", Convert.ToDecimal(txt) );

            return newTxt;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error al parsear número");
            //throw;
            return txt;
        }
    }
    public static string StringToMoneyFormat(this decimal txt, bool isNoDigit = false)
    {
        try
        {
            decimal n;
            n = Math.Round(txt, 2);

            string newTxt;
            newTxt = n.ToString("N");
            if (isNoDigit) newTxt = newTxt.Replace(".00", "");

            //txt = txt.Replace(",", ".");
            //string newtxt = string.Format("{0:#.00}", Convert.ToDecimal(txt) );

            return newTxt;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error al parsear número");
            //throw;
            return "";
        }
    }
    private static T GetItem<T>(DataRow dr)
    {
        var temp = typeof(T);
        var obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        foreach (var pro in temp.GetProperties())
            if (pro.Name == column.ColumnName && dr[column.ColumnName] != DBNull.Value)
                pro.SetValue(obj, dr[column.ColumnName], null);
            else
                continue;
        return obj;
    }

    public static object GetPropValue(this object obj, string name)
    {
        foreach (var part in name.Split('.'))
        {
            if (obj == null) return null;

            var type = obj.GetType();
            var info = type.GetProperty(part);
            if (info == null) return null;

            obj = info.GetValue(obj, null);
        }

        return obj;
    }

    public static T GetPropValue<T>(this object obj, string name)
    {
        var retval = GetPropValue(obj, name);
        if (retval == null) return default;

        // throws InvalidCastException if types are incompatible
        return (T)retval;
    }

    public static string GetPropValueToString(this object obj, string name)
    {
        var retval = GetPropValue(obj, name);
        if (retval == null) return default;

        // throws InvalidCastException if types are incompatible
        return retval.ToString();
    }

    public static string GetaAllMessages(this Exception exception)
    {
        var messages = exception.FromHierarchy(ex => ex.InnerException)
            .Select(ex => ex.Message);
        return string.Join(Environment.NewLine, messages);
    }


    // Get ModelState error
    public static string GetErrorMessage(this ModelStateDictionary modelState)
    {
        var message = string.Join("\r\n", modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
        return message;
    }


    //CookieManager


    // dictionary manager


    // all error checking left out for brevity

    // a.k.a., linked list style enumerator
    public static IEnumerable<TSource> FromHierarchy<TSource>(
        this TSource source,
        Func<TSource, TSource> nextItem,
        Func<TSource, bool> canContinue)
    {
        for (var current = source; canContinue(current); current = nextItem(current)) yield return current;
    }

    public static IEnumerable<TSource> FromHierarchy<TSource>(
        this TSource source,
        Func<TSource, TSource> nextItem)
        where TSource : class
    {
        return FromHierarchy(source, nextItem, s => s != null);
    }
}