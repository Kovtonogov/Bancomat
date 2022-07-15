using System.Data;
using Microsoft.Data.SqlClient;

namespace Test.Model
{
    class ClientServer
    {
        public string LoginRead(string login)
        {
            string line = null;
            string connectionString = "Server=tcp:bancomatserver.database.windows.net,1433;Initial Catalog=Bancomat;Persist Security Info=False;User ID=MiseterxXx;Password=4554,Futkm364554;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string sql = $"SELECT (password) FROM Balans WHERE login='{login}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                
                DataSet ds = new DataSet();
               
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                
                ds.Clear();
                
                adapter.Fill(ds);
               
                foreach (DataRow row in dt.Rows)
                {
                    
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        line = cell + "";
                    
                }


            }
            return line;

        }


    }
}
