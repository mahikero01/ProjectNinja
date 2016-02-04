using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectNinja.Modules
{
    public class Ninja : DBModel
    {
        #region "Public Methods"

            public DataTable GetAllDetails()
            {
                return this.GetDataStoredProcedure(@"USP_StudentDetailsProc");
            }

        #endregion
    }
}