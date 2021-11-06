using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTP.Entity
{
    public class ConnectingHelper
    {
        public static string BuildConnectionString(SqlConnectionStringBuilder builder, SqlConnString sqlConn)
        {
            builder.DataSource = sqlConn.Host;
            builder.InitialCatalog = sqlConn.Database;
            builder.UserID = sqlConn.User;
            builder.Password = sqlConn.Password;

            var resultConnectionString = builder.ConnectionString;

            return resultConnectionString;
        }

        public class SqlConnString
        {
            public string Database { get; set; }
            public string Host { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }
    }
}
