using Microsoft.Data.SqlClient;
using System.Data;

namespace MonitoringManagerAPI.Data
{
    public class DbSession : IDisposable
    {
        public IDbConnection connection { get; }
        public IDbTransaction transaction { get; set; }
        public DbSession (IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
        }
        public void Dispose() => connection?.Dispose();
    }
}
