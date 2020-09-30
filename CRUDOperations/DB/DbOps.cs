using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Configuration;

namespace CRUDOperations.DB
{
    public class DbOps
    {
        private SQLiteConnection getConnection()
        {
            string dbFile = ConfigurationManager.AppSettings["DB_ROUTE"];
            SQLiteConnection dbConnection;
            dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            dbConnection.Open();
            return dbConnection;
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> users = new List<Usuario>();

            string command = "SELECT * FROM USUARIO;";

            try
            {
                using (SQLiteConnection connection = getConnection())
                {
                    SQLiteCommand findCommand = new SQLiteCommand(command, connection);
                    SQLiteDataReader reader = findCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario user = new Usuario();
                        try
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string nombre = Convert.ToString(reader["Nombre"]);
                            DateTime fecha = Convert.ToDateTime(Convert.ToString(reader["Fecha_Nacimiento"]));
                            string sexo = Convert.ToString(reader["Sexo"]);

                            user.Ide = id;
                            user.Name = nombre;
                            user.BirthDate = fecha;
                            user.Sex = sexo;

                            users.Add(user);
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return users;
        }

        public bool CreateUser(Usuario user)
        {
            bool result = false;

            string command = "INSERT INTO USUARIO (Nombre, Fecha_Nacimiento, Sexo) VALUES ('" + user.Name + "','" + user.BirthDate + "','" + user.Sex + "');";

            try
            {
                using (SQLiteConnection connection = getConnection())
                {
                    SQLiteCommand createCommand = new SQLiteCommand(command, connection);
                    result = createCommand.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public bool EditUser(Usuario user)
        {
            bool result = false;

            string command = "UPDATE USUARIO SET Nombre = '" + user.Name + "', Fecha_Nacimiento = '" + user.BirthDate + "', Sexo = '" + user.Sex + "' WHERE Id = "+ user.Ide + ";";

            try
            {
                using (SQLiteConnection connection = getConnection())
                {
                    SQLiteCommand editCommand = new SQLiteCommand(command, connection);
                    result = editCommand.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public bool DeleteUser(int userId)
        {
            bool result = false;

            string command = "DELETE FROM USUARIO WHERE Id = " + userId + ";";

            try
            {
                using (SQLiteConnection connection = getConnection())
                {
                    SQLiteCommand deleteCommand = new SQLiteCommand(command, connection);
                    result = deleteCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {

            }

            return result;
        }
    }
}