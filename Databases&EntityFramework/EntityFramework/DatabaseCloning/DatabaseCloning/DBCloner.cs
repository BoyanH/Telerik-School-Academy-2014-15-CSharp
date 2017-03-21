using System;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.Entity.Infrastructure;

namespace DatabaseCloning
{
    public class DBCloner
    {
        public static void CloneDb(dynamic context)
        {

            Console.WriteLine("Loading...0%");

            string DBscript;
            DBscript = (context as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();
            DBscript = "CREATE DATABASE [NorthwindTwin] \n GO \nUSE [NorthwindTwin] \n" + DBscript;

            string sqlConnectionString = "Data Source=.\\SQLEXPRESS;Integrated Security=True";
            Console.WriteLine(sqlConnectionString);

            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {

                Server server = new Server(new ServerConnection(conn));
                Console.WriteLine("Loading...10%");
                server.ConnectionContext.ExecuteNonQuery(DBscript);
                Console.WriteLine("Done.");
            }
        }
    }
}
