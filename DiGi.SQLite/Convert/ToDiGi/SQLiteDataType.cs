using DiGi.SQLite.Enums;
using Microsoft.Data.Sqlite;

namespace DiGi.SQLite
{
    public static partial class Convert
    {
        public static SQLiteDataType ToDiGi(this SqliteType sqliteType)
        {
            switch (sqliteType)
            {
                case SqliteType.Blob:
                    return SQLiteDataType.Blob;

                case SqliteType.Real:
                    return SQLiteDataType.Real;

                case SqliteType.Integer:
                    return SQLiteDataType.Integer;

                case SqliteType.Text:
                    return SQLiteDataType.Text;
            }

            throw new System.NotImplementedException();
        }
    }
}