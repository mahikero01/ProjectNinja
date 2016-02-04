using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

            public void ModifyDataStoredProcedure()
            { 
            
            }

        #endregion

    }
}