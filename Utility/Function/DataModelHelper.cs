///Authapothc Creare 

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

/// <summary>
///     Utilities สำหรับการ casting Model DataSet DataTable
/// </summary>
public static class DataModelHelper
{
    //INTERFACE
    public static void CreateIDataTable<T>(ref DataTable datatable)
    {
        var entityType = typeof(T);
        var table = new DataTable(entityType.Name);
        var properties = TypeDescriptor.GetProperties(entityType);

        foreach (PropertyDescriptor prop in properties) table.Columns.Add(prop.Name, prop.PropertyType);
        datatable = table;
    }

    //DATA
    public static void CreateList<T>(ref List<T> item, DataTable dataTable)
    {
        try
        {
            item = new List<T>();

            if (item.GetType().IsGenericType && item is IEnumerable == false) throw new Exception();
            var ItemType = item.GetType().GetGenericArguments()[0];


            var ObjectList = new List<T>();

            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                var TempObject = Activator.CreateInstance<T>();
                for (var j = 0; j < dataTable.Columns.Count; j++)
                {
                    var colName = Convert.ToString(dataTable.Columns[j]);
                    var prop = ItemType.GetProperty(colName,
                        BindingFlags.SetProperty | BindingFlags.IgnoreCase | BindingFlags.Public |
                        BindingFlags.Instance);
                    if (prop == null) continue;

                    var value = dataTable.Rows[i][colName];

                    if (IsNullableType(prop.PropertyType))
                    {
                        if (value == DBNull.Value)
                            value = null;

                        prop.SetValue(TempObject, value, null);

                        //prop.SetValue(TempObject, dataTable.Rows[i][colName], null);
                    }
                    else
                    {
                        prop.SetValue(TempObject, Convert.ChangeType(dataTable.Rows[i][colName], prop.PropertyType),
                            null);
                    }
                }

                ObjectList.Add(TempObject);
            }

            item = ObjectList;
        }
        catch (Exception ex)
        {
            item = null;
            //LogFileHelper.insertErrorLogFile(ex.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            throw ex;
        }
    }

    /// <summary>
    ///     Function for Check Nullable Type
    /// </summary>
    /// <param name="propertyType"></param>
    /// <returns></returns>
    private static bool IsNullableType(Type propertyType)
    {
        return propertyType.IsGenericType &&
               ReferenceEquals(propertyType.GetGenericTypeDefinition(), typeof(Nullable<>));
    }

    public static void CreateObject<T>(ref T item, DataTable dataTable)
    {
        try
        {
            item = Activator.CreateInstance<T>();

            if (item.GetType().IsGenericType && item is IEnumerable) throw new Exception();

            var type = item.GetType();

            for (var i = 0; i < dataTable.Rows.Count; i++)
            for (var j = 0; j < dataTable.Columns.Count; j++)
            {
                var colName = Convert.ToString(dataTable.Columns[j]);
                var prop = type.GetProperty(colName,
                    BindingFlags.SetProperty | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (prop == null) continue;

                var value = dataTable.Rows[i][colName];

                if (IsNullableType(prop.PropertyType))
                {
                    if (value == DBNull.Value)
                        value = null;

                    prop.SetValue(item, value, null);
                    //prop.SetValue(TempObject, dataTable.Rows[i][colName], null);
                }
                else
                {
                    prop.SetValue(item, Convert.ChangeType(dataTable.Rows[0][colName], prop.PropertyType), null);
                }
            }
        }
        catch (Exception ex)
        {
            //LogFileHelper.insertErrorLogFile(ex.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            throw ex;
        }
    }

    public static DataTable ToDataTable<T>(List<T> items, string dtName)
    {
        var dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        var Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        foreach (var prop in Props)
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        foreach (var item in items)
        {
            var values = new object[Props.Length];
            for (var i = 0; i < Props.Length; i++)
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            dataTable.Rows.Add(values);
        }

        //put a breakpoint here and check datatable
        return dataTable;
    }

    public static List<T> DataTableToList<T>(this DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            var objectList = new List<T>();

            var item = typeof(T);

            var enumerable = item as IEnumerable;

            if (item.IsGenericType && enumerable != null == false)
                throw new Exception("Errror is not Casting for IEnumerable of Type.");

            var itemType = item.GetGenericArguments()[0];

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var tmpObj = Activator.CreateInstance<T>();
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    var col = Convert.ToString(dt.Columns[j]);
                    var prop = itemType.GetProperty(col);
                    if (prop == null) continue;

                    var value = dt.Rows[i][col];

                    if (prop.PropertyType.OIsNullableType())
                    {
                        if (value == DBNull.Value)
                            value = null;

                        prop.SetValue(tmpObj, value, null);
                    }
                    else
                    {
                        prop.SetValue(tmpObj, Convert.ChangeType(dt.Rows[i][col], prop.PropertyType), null);
                    }
                }

                objectList.Add(tmpObj);
            }

            return objectList;
        }

        return null;
    }

    private static bool OIsNullableType(this Type prop)
    {
        return prop.IsGenericType && ReferenceEquals(prop.GetGenericTypeDefinition(), typeof(Nullable<>));
    }

    public static string CheckNull(object T)
    {
        string result;

        if (T == null)
            result = string.Empty;
        else
            result = T.ToString();

        return result;
    }
}


public static class ObjectCopier
{
    public static void CopyPropertiesTo<T, TU>(this T source, out TU dest)
    {
        dest = Activator.CreateInstance<TU>();

        var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
        var destProps = typeof(TU).GetProperties()
            .Where(x => x.CanWrite)
            .ToList();

        foreach (var sourceProp in sourceProps)
            if (destProps.Any(x => x.Name.ToUpper() == sourceProp.Name.ToUpper()))
            {
                var p = destProps.First(x => x.Name.ToUpper() == sourceProp.Name.ToUpper());
                p.SetValue(dest, sourceProp.GetValue(source, null), null);
            }
    }

    public static void CopyPropertiesListTo<T, TU>(this List<T> sources, out List<TU> dests)
    {
        dests = Activator.CreateInstance<List<TU>>();

        foreach (var source in sources)
        {
            var dest = Activator.CreateInstance<TU>();
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                .Where(x => x.CanWrite)
                .ToList();

            foreach (var sourceProp in sourceProps)
                if (destProps.Any(x => x.Name.ToUpper() == sourceProp.Name.ToUpper()))
                {
                    var p = destProps.First(x => x.Name.ToUpper() == sourceProp.Name.ToUpper());
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }

            dests.Add(dest);
        }
    }

    public static void refPropertiesTo<T, TU>(this T source, ref TU dest)
    {
        var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
        var destProps = typeof(TU).GetProperties()
            .Where(x => x.CanWrite)
            .ToList();

        foreach (var sourceProp in sourceProps)
            if (destProps.Any(x => x.Name.ToUpper() == sourceProp.Name.ToUpper()))
            {
                var p = destProps.First(x => x.Name.ToUpper() == sourceProp.Name.ToUpper());
                p.SetValue(dest, sourceProp.GetValue(source, null), null);
            }
    }

    public static void ObjToHashtable<T>(this T source, out Hashtable dest)
    {
        dest = new Hashtable();
        var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();

        foreach (var sourceProp in sourceProps) dest.Add(sourceProp.Name, sourceProp.GetValue(source, null));
    }
}