using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CustomerHealthDataAccess
{
    internal class Database
    {
        public enum DBName
        {
            DB_CustomerHealthCheck,
            DB_SMEClinic
        }

        private string _connectionString;

        public Database(DBName DbName)
        {
            switch (DbName)
            {
                case DBName.DB_CustomerHealthCheck:
                    ConnectionString = ConfigurationManager.AppSettings["DB_CustomerHealthCheck"];
                    break;

                case DBName.DB_SMEClinic:
                    ConnectionString = ConfigurationManager.AppSettings["DB_SMEClinic"];
                    break;
            }
        }

        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        public DataSet ExecuteStoredProcedureReturnDataSet(string StoredProcedureName)
        {
            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            var sqlAdapter = new SqlDataAdapter(cmdExecution);

            var datasetResult = new DataSet();
            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

            return datasetResult;
        }

        public DataSet ExecuteCommandTextReturnDataSet(string commandText)
        {
            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(commandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            var sqlAdapter = new SqlDataAdapter(cmdExecution);

            var datasetResult = new DataSet();
            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

            return datasetResult;
        }

        public DataSet ExecuteStoredProcedureReturnDataSet(string StoredProcedureName, SqlParameter[] parameters)
        {
            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
            cmdExecution.CommandType = CommandType.StoredProcedure;
            cmdExecution.Parameters.AddRange(parameters);
            var sqlAdapter = new SqlDataAdapter(cmdExecution);

            var datasetResult = new DataSet();
            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

            return datasetResult;
        }

        public DataSet ExecuteCommandTextReturnDataSet(string commandText, SqlParameter[] parameters)
        {
            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(commandText, connectToDB);
            cmdExecution.CommandType = CommandType.Text;
            cmdExecution.Parameters.AddRange(parameters);
            var sqlAdapter = new SqlDataAdapter(cmdExecution);

            var datasetResult = new DataSet();

            try
            {
                sqlAdapter.Fill(datasetResult);
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

            return datasetResult;
        }

        public int ExecuteStoredProcedureNonQuery(string StoredProcedureName)
        {
            int checkValue;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
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
                    throw new Exception("Error in ExecuteStoredProcedureNonQuery() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public int ExecuteCommandTextNonQuery(string CommandText)
        {
            int checkValue;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(CommandText, connectToDB);
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
                    throw new Exception("Error in ExecuteCommandTextNonQuery() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public int ExecuteStoredProcedureNonQuery(string StoredProcedureName, SqlParameter[] parameters)
        {
            int checkValue;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
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
                    throw new Exception("Error in ExecuteStoredProcedureNonQuery() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public int ExecuteStoredProcedureNonQueryBulk(string StoredProcedureName, SqlParameter[][] parameters)
        {
            var checkValue = 0;

            var connectToDB = new SqlConnection(ConnectionString);


            using (connectToDB)
            {
                try
                {
                    connectToDB.Open();

                    for (var i = 0; i < parameters.Length; i++)
                    {
                        var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
                        cmdExecution.CommandType = CommandType.StoredProcedure;
                        cmdExecution.Parameters.AddRange(parameters[i]);
                        {
                            checkValue = checkValue + cmdExecution.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException err)
                {
                    throw new Exception("Error in ExecuteStoredProcedureNonQueryBulk() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public int ExecuteCommandTextNonQuery(string CommandText, SqlParameter[] parameters)
        {
            int checkValue;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(CommandText, connectToDB);
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
                    throw new Exception("Error in ExecuteCommandTextNonQuery() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public object executeStoredProcedureScalar(string StoredProcedureName)
        {
            object returnValue = null;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
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
                    throw new Exception("Error in executeStoredProcedureScalar() OF DatabaseAccess.cs" + err);
                }
            }

            return returnValue;
        }

        public object ExecuteCommandTextScalar(string CommandText)
        {
            object returnValue = null;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(CommandText, connectToDB);
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
                    throw new Exception("Error in ExecuteCommandTextScalar() OF DatabaseAccess.cs" + err);
                }
            }

            return returnValue;
        }

        public object executeStoredProcedureScalar(string StoredProcedureName, SqlParameter[] parameters)
        {
            object returnValue = null;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
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
                    throw new Exception("Error in executeStoredProcedureScalar() OF DatabaseAccess.cs" + err);
                }
            }

            return returnValue;
        }

        public object ExecuteCommandTextScalar(string CommandText, SqlParameter[] parameters)
        {
            object returnValue = null;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(CommandText, connectToDB);
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
                    throw new Exception("Error in ExecuteCommandTextScalar() OF DatabaseAccess.cs" + err);
                }
            }

            return returnValue;
        }

        public bool executeStoredProcedureHasRow(string StoredProcedureName)
        {
            var checkValue = false;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
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
                    throw new Exception("Error in executeStoredProcedureHasRow() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public bool ExecuteCommandTextHasRow(string CommandText)
        {
            var checkValue = false;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(CommandText, connectToDB);
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
                    throw new Exception("Error in ExecuteCommandTextHasRow() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public bool executeStoredProcedureHasRow(string StoredProcedureName, SqlParameter[] parameters)
        {
            var checkValue = false;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(StoredProcedureName, connectToDB);
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
                    throw new Exception("Error in executeStoredProcedureHasRow() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }

        public bool ExecuteCommandTextHasRow(string CommandText, SqlParameter[] parameters)
        {
            var checkValue = false;

            var connectToDB = new SqlConnection(ConnectionString);
            var cmdExecution = new SqlCommand(CommandText, connectToDB);
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
                    throw new Exception("Error in ExecuteCommandTextHasRow() OF DatabaseAccess.cs" + err);
                }
            }

            return checkValue;
        }
    }
}