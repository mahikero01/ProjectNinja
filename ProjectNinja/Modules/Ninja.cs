using System.Data;
using System.Data.SqlClient;

namespace ProjectNinja.Modules
{
    public class Ninja : DBModel
    {
        #region "Private Member Variables"
        
            private string _name;
        
        #endregion

        #region "Public Properties"

            public string Name { set { this._name = value; } }

        #endregion

        #region "Public Methods"

            public DataTable GetAllDetails()
            {
                return this.GetDataStoredProcedure(@"USP_StudentDetailsProc");
            }

            public DataTable GetAllDetailsByName()
            {
                var arrayOfParameter = new SqlCommand().Parameters;
                arrayOfParameter.AddWithValue("@name", _name);
                return this.GetDataStoredProcedure(@"USP_StudentDetailsProc2", arrayOfParameter );
            }

            public int InsertData()
            {
                return this.ModifyDataStoredProcedure(@"USP_StudentDetailsProc3");   
            }

        #endregion
    }
}