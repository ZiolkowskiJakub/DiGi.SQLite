using DiGi.Core.Interfaces;
using DiGi.SQLite.Enums;
using System;
using System.Text.Json.Nodes;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static SQLiteDataType? SQLiteDataType(this object @object)
        {
            return SQLiteDataType(@object?.GetType());
        }

        public static SQLiteDataType? SQLiteDataType(this Type type)
        {
            if (type == null)
            {
                return null;
            }

            Type type_Temp = Nullable.GetUnderlyingType(type);
            if (type_Temp == null)
            {
                type_Temp = type;
            }

            if (type == typeof(string))
            {
                return Enums.SQLiteDataType.Text;
            }

            if (type == typeof(Guid))
            {
                return Enums.SQLiteDataType.Text;
            }

            if (Core.Query.IsNumeric(type, out bool isInteger))
            {
                if (isInteger)
                {
                    return Enums.SQLiteDataType.Integer;
                }
                else
                {
                    return Enums.SQLiteDataType.Real;
                }
            }

            if (type == typeof(DateTime))
            {
                return Enums.SQLiteDataType.Integer;
            }

            if (type == typeof(bool))
            {
                return Enums.SQLiteDataType.Integer;
            }

            if (type.IsEnum)
            {
                return Enums.SQLiteDataType.Integer;
            }

            if (typeof(JsonNode).IsAssignableFrom(type_Temp))
            {
                return Enums.SQLiteDataType.Text;
            }

            if (typeof(ISerializableObject).IsAssignableFrom(type_Temp))
            {
                return Enums.SQLiteDataType.Text;
            }

            return null;
        }

    }
}

