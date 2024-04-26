using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMSDotNetCore.ConsoleApp
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder=new SqlConnectionStringBuilder() {
            DataSource = "AGD-SW-523",
            InitialCatalog = "MMMSDotNet",
            UserID="sa",
            Password="sa@123"


        };

    }
}
