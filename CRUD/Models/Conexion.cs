using Microsoft.Data.SqlClient;

namespace CRUD.Models
{
    public class Conexion
    {
        private string SqlC = string.Empty;
        public SqlConnection Connect()
        {
            var Sqlcon = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            SqlC = Sqlcon.GetSection("ConnectionStrings:Sqlcon").Value;
            SqlConnection conn = new SqlConnection(SqlC);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception)
            {

                conn.Close();
                return conn;
                throw;
            }

        }
    }
}
