using System;
using System.Collections.Generic;
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
        #endregion

        #region "Public Methods"
            public DataTable DQLStoredProc()
            {
                DataTable data = null;

                return data;

            }

        #endregion

    }
}