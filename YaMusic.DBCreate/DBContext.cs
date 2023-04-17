using System.Data.SqlClient;

namespace YaMusic.DBCreate
{
    internal class DBContext
    {
        private SqlConnection _connection;

        internal DBContext(SqlConnection connection)
        {
            _connection = connection;
        }

        internal void ExecuteNonQueryCommand(string query, string desc = "command")
        {
            try
            {
                SqlCommand command = _connection.CreateCommand();
                command.CommandText = query;
                var result = command.ExecuteNonQuery();
                Console.WriteLine($"команда - {desc} выполена");
                Console.WriteLine($"затронуто {result} строк ");
                Console.WriteLine("--------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
