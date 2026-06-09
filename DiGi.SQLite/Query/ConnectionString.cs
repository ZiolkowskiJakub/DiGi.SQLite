namespace DiGi.SQLite
{
    public static partial class Query
    {
        /// <summary>
        /// Generates a SQLite connection string based on the provided file path.
        /// </summary>
        /// <param name="path">The path to the SQLite database file.</param>
        /// <returns>A formatted connection string if the path is valid; otherwise, <see langword="null"/>.</returns>
        public static string? ConnectionString(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            return $"Data Source={path}";
        }
    }
}