using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public class ExcelManager
{
    private string CreateTableQuery;
    private readonly string Path;
    private readonly string TableName;

    public ExcelManager(string path, string tableName)
    {
        TableName = tableName;
        Path = path;
    }

    public DataSet DataSet { get; private set; }

    public void ReadExcelData()
    {
        var strExcelConn = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = " + Path +
                           "; Extended Properties ='Excel 8.0; HDR = Yes'";
        var connExcel = new OleDbConnection(strExcelConn);
        try
        {
            var cmdExcel = new OleDbCommand();
            cmdExcel.Connection = connExcel;

            ///*****Get schema info and Read Sheet Name and save it as TableName *******//
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var excelTable = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            CreateTableQuery = "CREATE TABLE " + TableName + "(";

            /*****Get schema info and read the column names and build Query to Create similar SQL table*****/
            //
            dtExcelSchema =
                connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, excelTable, null });
            connExcel.Close();

            var FieldNames = "";
            var dv = new DataView(dtExcelSchema);
            dv.Sort = "ORDINAL_POSITION";
            foreach (DataRowView rowView in dv)
            {
                var row = rowView.Row;
                CreateTableQuery += row["COLUMN_NAME"] + " " + ((OleDbType)row["DATA_TYPE"]) + ",";
                FieldNames += row["COLUMN_NAME"] + ",";
            }

            /////******************Replace data types************/////
            CreateTableQuery = CreateTableQuery.TrimEnd(",".ToCharArray()) + ")";
            CreateTableQuery = CreateTableQuery.Replace("WChar", "NVARCHAR(500)");
            CreateTableQuery = CreateTableQuery.Replace("Double", "INT");
            FieldNames = FieldNames.TrimEnd(",".ToCharArray()) + "";

            /******************read records from excel file************/

            cmdExcel.CommandText = "Select " + FieldNames + " from[" + excelTable + "]";
            DataSet = new DataSet();
            var da = new OleDbDataAdapter();
            connExcel.Open();
            da.SelectCommand = cmdExcel;
            da.Fill(DataSet);
            connExcel.Close();
        }
        catch (Exception ex)
        {
            connExcel.Close();
            throw;
        }
        finally
        {
            connExcel.Close();
        }
    }

    public bool CreateTable(string sqlConn, string Table)
    {
        try
        {
            if (CreateTableQuery != "")
            {
                var conn = new SqlConnection();
                //string sqlConn = "data source = wedeveloper.net\\MSSQLSERVER2016; initial catalog=ukieworld; user id=db02; password=P@ssw0rd;";
                conn.ConnectionString = sqlConn;
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();

                cmd.CommandText = "IF OBJECT_ID(N'" + Table + "', N'U') IS NOT NULL BEGIN  DROP TABLE " + Table +
                                  " END";
                cmd.ExecuteNonQuery();

                cmd.CommandText = CreateTableQuery;
                cmd.ExecuteNonQuery();

                conn.Close();

                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool ClearTable(string sqlConn, string Table)
    {
        try
        {
            if (CreateTableQuery != "")
            {
                var conn = new SqlConnection();
                //string sqlConn = "data source = wedeveloper.net\\MSSQLSERVER2016; initial catalog=ukieworld; user id=db02; password=P@ssw0rd;";
                conn.ConnectionString = sqlConn;
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();

                cmd.CommandText = "Delete from " + Table + ";";
                cmd.ExecuteNonQuery();

                cmd.CommandText = CreateTableQuery;
                cmd.ExecuteNonQuery();

                conn.Close();

                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool BulkInsertData(string sqlConn)
    {
        try
        {
            var conn = new SqlConnection();
            //string sqlConn = "data source = wedeveloper.net\\MSSQLSERVER2016; initial catalog=ukieworld; user id=db02; password=P@ssw0rd;";
            conn.ConnectionString = sqlConn;
            var dt = new DataTable();
            dt = DataSet.Tables[0];
            var sbc = new SqlBulkCopy(conn);
            sbc.DestinationTableName = TableName;
            conn.Open();
            sbc.WriteToServer(dt);
            conn.Close();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteNullValue(string sqlConn, string Table, string id)
    {
        try
        {
            var conn = new SqlConnection();
            //string sqlConn = "data source = wedeveloper.net\\MSSQLSERVER2016; initial catalog=ukieworld; user id=db02; password=P@ssw0rd;";
            conn.ConnectionString = sqlConn;
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "delete from " + Table + " where " + id + " is null;";
            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool IsExistTable()
    {
        return false;
    }
}