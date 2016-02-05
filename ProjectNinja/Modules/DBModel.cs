using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjectNinja.Modules
{
    public class DBModel
    {

        #region "Private Member Variables"

            private string _serverInfo;
            private SqlConnection _dbConnection;
            private string _errorMessage;

        #endregion


        #region "Private Methods"

            private void GetDBConnection()
            {

                this._serverInfo = ConfigurationManager.ConnectionStrings["DevCARSA"].ToString();
                this._dbConnection = new SqlConnection(this._serverInfo);
            
            }

            private void CloseConnection()
            {

                this._dbConnection.Close();
                this._serverInfo = "";
            
            }

        #endregion


        #region "Public Methods"

            //For stored procedure (w/ Parameter) that return resultset value
            public DataTable GetDataStoredProcedure(string storedProcedure)
            {

                DataTable resultSet = null;

                try
                {

                    this.GetDBConnection();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection);
                    query.CommandType = CommandType.StoredProcedure;
                    this._dbConnection.Open();

                    SqlDataAdapter dbAdapter = new SqlDataAdapter(query);
                    resultSet = new DataTable();
                    dbAdapter.Fill(resultSet);

                    dbAdapter.Dispose();
                    dbAdapter = null;
                    query.Dispose();
                    query = null;

                }
                catch (SqlException sqlException)
                {

                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
               
                }
                catch (Exception exception)
                {

                    _errorMessage = "Runtime Error - " + exception.Message;
               
                }
                finally
                { 

                    this.CloseConnection();
              
                }
                
                return resultSet;

            }


            //For stored procedure (w/ Parameter) that return resultset value
            public DataTable GetDataStoredProcedure(string storedProcedure, SqlParameterCollection storedProcedureParameter) 
            {

                DataTable resultSet = null;

                try
                {

                    this.GetDBConnection();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection);
                    query.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter parameter in storedProcedureParameter)
                    {

                        query.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                
                    }

                    this._dbConnection.Open();

                    SqlDataAdapter dbAdapter = new SqlDataAdapter(query);
                    resultSet = new DataTable();
                    dbAdapter.Fill(resultSet);

                    dbAdapter.Dispose();
                    dbAdapter = null;
                    query.Dispose();
                    query = null;

                }
                catch (SqlException sqlException)
                {

                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
               
                }
                catch (Exception exception)
                {

                    _errorMessage = "Runtime Error - " + exception.Message;
              
                }
                finally
                { 

                    this.CloseConnection();
            
                }
                
                return resultSet;
            }


            //For stored procedure does not return resultset value only integer
            //return value will only signify if store procedure is succesfull (1) or not (-1)
            public int ModifyDataStoredProcedure(string storedProcedure)
            {

                int status = 1;

                try
                {

                    this.GetDBConnection();
                    this._dbConnection.Open();
                    SqlTransaction transaction;
                    transaction = this._dbConnection.BeginTransaction();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection, transaction);
                    query.CommandType = CommandType.StoredProcedure;
                    query.ExecuteNonQuery();
                    transaction.Commit();

                    transaction.Dispose();
                    transaction = null;
                    query.Dispose();
                    query = null;

                }
                catch (SqlException sqlException)
                {

                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
            
                }
                catch (Exception exception)
                {

                    _errorMessage = "Runtime Error - " + exception.Message;
            
                }
                finally
                {

                    this.CloseConnection();
            
                }

                return status;

            }


            //For stored procedure (w/ Parameter) does not return resultset value only integer
            //return value will only signify if store procedure is succesfull (1) or not (-1)
            public int ModifyDataStoredProcedure(string storedProcedure, SqlParameterCollection storedProcedureParameter)
            {

                int status = 1;

                try
                {

                    this.GetDBConnection();
                    this._dbConnection.Open();
                    SqlTransaction transaction;
                    transaction = this._dbConnection.BeginTransaction();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection, transaction);
                    query.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter parameter in storedProcedureParameter)
                    {

                        query.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                 
                    }

                    query.ExecuteNonQuery();
                    transaction.Commit();

                    transaction.Dispose();
                    transaction = null;
                    query.Dispose();
                    query = null; 

                }
                catch (SqlException sqlException)
                {

                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
             
                }
                catch (Exception exception)
                {

                    _errorMessage = "Runtime Error - " + exception.Message;
           
                }
                finally 
                {

                    this.CloseConnection();
           
                }

                return status;

            }

            //For stored procedure does not return resultset value only integer 
            //(stored procedure must use "SELECT @integer" for return value)
            public int ModifyDataStoredProcedureWithReturn(string storedProcedure)
            {

                int status = 0;

                try
                {

                    this.GetDBConnection();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection);
                    query.CommandType = CommandType.StoredProcedure;
                    this._dbConnection.Open();

                    SqlDataReader dbReader = query.ExecuteReader();
                    dbReader.Read();
                    status = dbReader.GetInt32(0);

                    dbReader.Dispose();
                    dbReader = null;
                    query.Dispose();
                    query = null;

                }
                catch (SqlException sqlException)
                {

                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
           
                }
                catch (Exception exception)
                {

                    _errorMessage = "Runtime Error - " + exception.Message;
          
                }
                finally 
                {

                    this.CloseConnection();
             
                }

                return status;

            }


            //For stored procedure (w/ Parameter) does not return resultset value only integer 
            //(stored procedure must use "SELECT @integer" for return value)
            public int ModifyDataStoredProcedureWithReturn(string storedProcedure, SqlParameterCollection storedProcedureParameter)
            {

                int status = 0;

                try
                {

                    this.GetDBConnection();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection);
                    query.CommandType = CommandType.StoredProcedure;
                    this._dbConnection.Open();

                    foreach (SqlParameter parameter in storedProcedureParameter)
                    {

                        query.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                
                    }

                    SqlDataReader dbReader = query.ExecuteReader();
                    dbReader.Read();
                    status = dbReader.GetInt32(0);

                    dbReader.Dispose();
                    dbReader = null;
                    query.Dispose();
                    query = null;

                }
                catch (SqlException sqlException)
                {

                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
        
                }
                catch (Exception exception)
                {

                    _errorMessage = "Runtime Error - " + exception.Message;
               
                }
                finally
                {

                    this.CloseConnection();
          
                }

                return status;

            }

        #endregion
    }

}