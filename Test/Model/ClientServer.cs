using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Test.Model
{
    class ClientServer
    {
        public string LoginRead(string login)
        {
            string line = null;
            string connectionString = "Server=tcp:vipko.database.windows.net,1433;Initial Catalog=Bankomat;Persist Security Info=False;User ID=Mister;Password=4554vbcnth4554Z;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string sql = $"SELECT (password) FROM Balans WHERE login='{login}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);


                DataTable dt = ds.Tables[0];
                // добавим новую строку
                /*DataRow newRow = dt.NewRow();
                newRow["login"] = "Mariya";
                newRow["password"] = "123456";
                newRow["money"] = "10000";
                dt.Rows.Add(newRow);*/


                //dt.Rows[0]["money"] = "5000";

                // Изменим значение в столбце Age для первой строки


                // создаем объект SqlCommandBuilder
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                // альтернативный способ - обновление только одной таблицы
                //adapter.Update(dt);
                // заново получаем данные из бд
                // очищаем полностью DataSet
                ds.Clear();
                // перезагружаем данные
                adapter.Fill(ds);



                // Отображаем данные
                // перебор всех таблиц

                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        line = cell + "";
                    
                }


            }
            return line;

        }


    }
}
