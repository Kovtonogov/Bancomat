using System.Data;
using Microsoft.Data.SqlClient;

namespace Test.Model
{
    class TestConnect
    {
        public bool read()
        {
            bool result = true;
            string sql = "SELECT * FROM Balans";
            string connectionString = "Server=tcp:vipko.database.windows.net,1433;Initial Catalog=Bankomat;Persist Security Info=False;User ID=Mister;Password=4554vbcnth4554Z;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                
                DataSet ds = new DataSet();
                
                adapter.Fill(ds);

            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}


