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
            string connectionString = "Server=tcp:bancomatserver.database.windows.net,1433;Initial Catalog=Bancomat;Persist Security Info=False;User ID=MiseterxXx;Password=4554,Futkm364554;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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


