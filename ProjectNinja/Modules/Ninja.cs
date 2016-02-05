using System.Data;
using System.Data.SqlClient;

namespace ProjectNinja.Modules
{
    public class Ninja : DBModel
    {
        #region "Private Member Variables"
        
            private string _rollNo;
            private string _name;
            private string _department;
            private string _section;

        #endregion

        #region "Public Properties"

            public string RollNo { set { this._rollNo = value; } }
            public string Name { set { this._name = value; } }
            public string Department { set { this._department = value; } }
            public string Section { set { this._section = value; } }

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

            public int InsertData2()
            {
                var arrayOfParameter = new SqlCommand().Parameters;
                arrayOfParameter.AddWithValue("@rollno", _rollNo);
                arrayOfParameter.AddWithValue("@name", _name);
                arrayOfParameter.AddWithValue("@department", _department);
                arrayOfParameter.AddWithValue("@section", _section);

                return this.ModifyDataStoredProcedure(@"USP_StudentDetailsProc4", arrayOfParameter);
            }

            public int WithReturn()
            {
                return this.ModifyDataStoredProcedureWithReturn(@"USP_StudentDetailsProc5");
            }

        #endregion
    }
}