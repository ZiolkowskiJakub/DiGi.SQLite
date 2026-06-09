using Microsoft.Data.Sqlite;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        /// <summary>
        /// Checks whether a table with the specified name exists in the SQLite database.
        /// </summary>
        /// <param name="sqliteCommand">The <see cref="SqliteCommand"/> used to execute the existence check.</param>
        /// <param name="tableName">The name of the table to search for.</param>
        /// <returns>True if the table exists; otherwise, false.</returns>
        public static bool Exists(this SqliteCommand? sqliteCommand, string? tableName)
        {
            if (sqliteCommand == null || string.IsNullOrEmpty(tableName))
            {
                return false;
            }
            sqliteCommand.Parameters.Clear();

            sqliteCommand.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = @tableName;";
            sqliteCommand.Parameters.AddWithValue("@tableName", tableName);

            object? result = sqliteCommand.ExecuteScalar();

            sqliteCommand.Parameters.Clear();

            return System.Convert.ToInt32(result) > 0;
        }
    }
}