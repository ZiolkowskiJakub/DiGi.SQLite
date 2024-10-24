using Microsoft.Data.Sqlite;
using System;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static SqliteType? SqliteType(this Type type)
        {
            if(type == null)
            {
                return null;
            }

            Type type_Temp = Nullable.GetUnderlyingType(type);
            if (type_Temp == null)
            {
                type_Temp = type;
            }

            if(type_Temp.IsEnum)
            {
                return Microsoft.Data.Sqlite.SqliteType.Integer;
            }

            if(type_Temp == typeof(bool))
            {
                return Microsoft.Data.Sqlite.SqliteType.Integer;
            }

            if (type_Temp == typeof(DateTime))
            {
                return Microsoft.Data.Sqlite.SqliteType.Integer;
            }

            if (type_Temp == typeof(long) || type_Temp == typeof(short) || type_Temp == typeof(int) || type_Temp == typeof(ulong) || type_Temp == typeof(ushort) || type_Temp == typeof(uint))
            {
                return Microsoft.Data.Sqlite.SqliteType.Integer;
            }

            if (Core.Query.IsNumeric(type_Temp))
            {
                return Microsoft.Data.Sqlite.SqliteType.Real;
            }

            if(type_Temp == typeof(string))
            {
                return Microsoft.Data.Sqlite.SqliteType.Text;
            }

            if (type_Temp == typeof(char))
            {
                return Microsoft.Data.Sqlite.SqliteType.Text;
            }

            return Microsoft.Data.Sqlite.SqliteType.Blob;
        }

    }
}

