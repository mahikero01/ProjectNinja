using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectNinja
{
    public partial class Ninja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AspButton(object sender, EventArgs e)
        {
            string svrInfo = ConfigurationManager.ConnectionStrings["DevCARSA"].ToString();
            //string sqlQry = @"SELECT Name, Department FROM StudentDetails";
            string sqlQry = @"USP_StudentDetailsProc";

            using(SqlConnection conn = new SqlConnection(svrInfo))
            {
                
                using(SqlCommand cmd = new SqlCommand(sqlQry, conn))
                {

                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                    
                        if (rdr.HasRows)
                        {

                            while(rdr.Read())
                            {
                                //Debug.WriteLine("{0}\t{1}", rdr.GetString(0), rdr.GetString(1));
                                Debug.WriteLine(rdr.GetString(0));
                            }

                        }
                        else
                        {
                            Debug.WriteLine("No rows");
                        }

                    }
                
                }

            }
        }

        [System.Web.Services.WebMethod]
        public static string GetName(string name) {

            return name;

        }
    }
}