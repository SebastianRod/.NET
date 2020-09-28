using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Roulete_.Controllers
{
    public class DbController
    {
        private SQLiteConnection getConnection()
        {
            string dbFile = Environment.GetEnvironmentVariable("DB_ROUTE");
            SQLiteConnection dbConnection;
            dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            dbConnection.Open();
            return dbConnection;
        }

        public int createRoulette()
        {
            try
            {
                string insert = "INSERT INTO Roulette (Status) VALUES ('Closed')";

                using (SQLiteConnection connection = getConnection())
                {
                    SQLiteCommand createCommand = new SQLiteCommand(insert, connection);
                    int result = createCommand.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.StackTrace);
                return 0;
            }
        }
    }
}
