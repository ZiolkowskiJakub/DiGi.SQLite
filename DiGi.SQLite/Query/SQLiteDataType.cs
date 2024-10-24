using DiGi.SQLite.Enums;
using System;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static SQLiteDataType? SQLiteDataType(this object @object)
        {
            if(@object == null)
            {
                return null;
            }

            if(@object is string)
            {
                return Enums.SQLiteDataType.Text;
            }

            if(Core.Query.IsNumeric(@object, out bool isInteger))
            {
                if(isInteger)
                {
                    return Enums.SQLiteDataType.Integer;
                }
                else
                {
                    return Enums.SQLiteDataType.Real;
                }
            }

            if(@object is DateTime)
            {
                return Enums.SQLiteDataType.Integer;
            }

            if(@object is bool)
            {
                return Enums.SQLiteDataType.Integer;
            }

            if (@object is Enum)
            {
                return Enums.SQLiteDataType.Integer;
            }

            return Enums.SQLiteDataType.Blob;
        }

    }
}

