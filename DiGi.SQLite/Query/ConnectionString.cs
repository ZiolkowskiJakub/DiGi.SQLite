namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static string ConnectionString(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            return $"Data Source={path}";
        }

    }
}

