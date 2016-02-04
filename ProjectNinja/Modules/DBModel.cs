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
                    this.CloseConnection();

                    return resultSet;
                }
                catch (SqlException sqlException)
                {
                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
                    return resultSet;
                }
                catch(Exception exception)
                {
                    _errorMessage = "Runtime Error - " + exception.Message;
                    return resultSet;
                }
                

            }


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
                    this.CloseConnection();

                    return resultSet;
                }
                catch (SqlException sqlException)
                {
                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
                    return resultSet;
                }
                catch (Exception exception)
                {
                    _errorMessage = "Runtime Error - " + exception.Message;
                    return resultSet;
                }
            }


            public int ModifyDataStoredProcedure(string storedProcedure)
            {
                int recordsAffected = 0;

                try
                {

                    this.GetDBConnection();
                    this._dbConnection.Open();
                    SqlTransaction transaction;
                    transaction = this._dbConnection.BeginTransaction();
                    SqlCommand query = new SqlCommand(storedProcedure, this._dbConnection, transaction);
                    query.CommandType = CommandType.StoredProcedure;

                    recordsAffected = 1;
                    query.ExecuteNonQuery();
                    transaction.Commit();

                    transaction.Dispose();
                    transaction = null;
                    query.Dispose();
                    query = null;
                    this.CloseConnection();

                    return recordsAffected;
                }
                catch (SqlException sqlException)
                {
                    _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
                    this.CloseConnection();
                    return recordsAffected;
                }
                catch (Exception exception)
                {
                    _errorMessage = "Runtime Error - " + exception.Message;
                    this.CloseConnection();
                    return recordsAffected;
                }
            }

        #endregion

    }
}