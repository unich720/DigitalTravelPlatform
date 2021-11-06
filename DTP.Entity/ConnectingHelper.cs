using Microsoft.Data.SqlClient;

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
