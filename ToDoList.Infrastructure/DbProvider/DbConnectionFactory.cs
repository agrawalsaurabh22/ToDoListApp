using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ToDoList.Infrastructure.Interface;

namespace ToDoList.Infrastructure.DbProvider
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public DbConnectionFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["todolistconnection"].ConnectionString; 
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
