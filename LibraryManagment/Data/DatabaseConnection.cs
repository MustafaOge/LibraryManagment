using Microsoft.Data.Sqlite;
using System.Data;

namespace LibraryManagment.Data
{
    public static class DatabaseConnection
    {
        private static readonly string DbConnection =
            $@"Data Source={Environment.CurrentDirectory}\Database\LIBRARY_MANAGEMENT.db";

        public static string ConnState = string.Empty;

        public static void ConnectionTest()
        {
            try
            {
                using (var conn = new SqliteConnection(DbConnection))
                {
                    conn.Open();
                    ConnState = conn.State == ConnectionState.Open
                        ? "Db Success"
                        : "Db Failed";
                }
            }
            catch (Exception ex)
            {
                ConnState = $"Database Connection Error: {ex.Message}";
            }
        }
    }
}
