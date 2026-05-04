using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class DBConnection
    {
        private static string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
