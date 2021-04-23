using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MiApiUdelp.Data
{
    public class ParametersDataBaseHelper
    {
        public string storedProcedureName { get; set; }
        public SqlParameter[] parameters { get; set; }
    }
}