using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Scoring
{
    class Database
    {
        private string _connectionString;

        public enum DBName
        {
            DB_CustomerHealthCheck
        }

        public Database(DBName DbName)
        {
            switch (DbName)
            {
                case DBName.DB_CustomerHealthCheck:
                    ConnectionString = ConfigurationManager.AppSettings["DB_CustomerHealthCheck"].ToString();
                    break;

                default:
                    break;
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value.ToString(); }
        }

        public DataSet ExecuteStoredProcedureReturnDataSet(string StoredProcedureName)
        {
            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmdExecution);

            DataSet datasetResult = new DataSet();
            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return datasetResult;
        }

        public DataSet ExecuteCommandTextReturnDataSet(string commandText)
        {
            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(commandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmdExecution);

            DataSet datasetResult = new DataSet();
            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return datasetResult;
        }

        public DataSet ExecuteStoredProcedureReturnDataSet(string StoredProcedureName, SqlParameter[] parameters)
        {
            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            cmdExecution.Parameters.AddRange(parameters);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmdExecution);

            DataSet datasetResult = new DataSet();
            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return datasetResult;
        }

        public DataSet ExecuteCommandTextReturnDataSet(string commandText, SqlParameter[] parameters)
        {
            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(commandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            cmdExecution.Parameters.AddRange(parameters);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmdExecution);

            DataSet datasetResult = new DataSet();

            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return datasetResult;
        }

        public int ExecuteStoredProcedureNonQuery(string StoredProcedureName)
        {
            int checkValue;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteStoredProcedureNonQuery() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public int ExecuteCommandTextNonQuery(string CommandText)
        {
            int checkValue;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(CommandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteCommandTextNonQuery() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public int ExecuteStoredProcedureNonQuery(string StoredProcedureName, SqlParameter[] parameters)
        {
            int checkValue;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            cmdExecution.Parameters.AddRange(parameters);

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteStoredProcedureNonQuery() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public int ExecuteStoredProcedureNonQueryBulk(string StoredProcedureName, SqlParameter[][] parameters)
        {
            int checkValue = 0;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);


            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
                        cmdExecution.CommandType = CommandType.StoredProcedure;
                        cmdExecution.Parameters.AddRange(parameters[i]);
                        {
                            checkValue = checkValue + cmdExecution.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteStoredProcedureNonQueryBulk() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public int ExecuteCommandTextNonQuery(string CommandText, SqlParameter[] parameters)
        {
            int checkValue;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(CommandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            cmdExecution.Parameters.AddRange(parameters);

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteCommandTextNonQuery() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public Object executeStoredProcedureScalar(string StoredProcedureName)
        {
            Object returnValue = null;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        returnValue = cmdExecution.ExecuteScalar();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in executeStoredProcedureScalar() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return returnValue;
        }

        public Object ExecuteCommandTextScalar(string CommandText)
        {
            Object returnValue = null;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(CommandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        returnValue = cmdExecution.ExecuteScalar();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteCommandTextScalar() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return returnValue;
        }

        public Object executeStoredProcedureScalar(string StoredProcedureName, SqlParameter[] parameters)
        {
            Object returnValue = null;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            cmdExecution.Parameters.AddRange(parameters);

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        returnValue = cmdExecution.ExecuteScalar();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in executeStoredProcedureScalar() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return returnValue;
        }

        public Object ExecuteCommandTextScalar(string CommandText, SqlParameter[] parameters)
        {
            Object returnValue = null;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(CommandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            cmdExecution.Parameters.AddRange(parameters);

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        returnValue = cmdExecution.ExecuteScalar();
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteCommandTextScalar() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return returnValue;
        }

        public bool executeStoredProcedureHasRow(string StoredProcedureName)
        {
            bool checkValue = false;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteReader().HasRows;
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in executeStoredProcedureHasRow() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public bool ExecuteCommandTextHasRow(string CommandText)
        {
            bool checkValue = false;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(CommandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();
                    checkValue = cmdExecution.ExecuteReader().HasRows;
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteCommandTextHasRow() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public bool executeStoredProcedureHasRow(string StoredProcedureName, SqlParameter[] parameters)
        {
            bool checkValue = false;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            cmdExecution.Parameters.AddRange(parameters);

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteReader().HasRows;
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in executeStoredProcedureHasRow() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }

        public bool ExecuteCommandTextHasRow(string CommandText, SqlParameter[] parameters)
        {
            bool checkValue = false;

            SqlConnection connectToDB = new SqlConnection(ConnectionString);
            SqlCommand cmdExecution = new SqlCommand(CommandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            cmdExecution.Parameters.AddRange(parameters);

            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    using (cmdExecution)
                    {
                        checkValue = cmdExecution.ExecuteReader().HasRows;
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteCommandTextHasRow() OF DatabaseAccess.cs" + err.Message);
                }
            }
            return checkValue;
        }
    }
}
