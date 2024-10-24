using DiGi.SQLite.Classes;
using DiGi.SQLite.Interfaces;
using System.Text.Json.Nodes;

namespace DiGi.SQLite
{
    public static partial class Create
    {
        public static ISQLiteData SQLiteData(this JsonNode jsonNode)
        {
            if (jsonNode == null)
            {
                return null;
            }

            switch (jsonNode.GetValueKind())
            {
                case System.Text.Json.JsonValueKind.Object:
                    return new SQLiteDataObject(jsonNode.AsObject());

                case System.Text.Json.JsonValueKind.Number:
                    if (Core.Query.TryConvert(jsonNode.AsValue().GetValue<object>(), out double @double))
                    {
                        return new SQLiteDataValue(@double);
                    }
                    break;

                case System.Text.Json.JsonValueKind.Array:
                    return new SQLiteDataArray(jsonNode.AsArray());

                case System.Text.Json.JsonValueKind.String:
                    if (Core.Query.TryConvert(jsonNode.AsValue().GetValue<object>(), out string @string))
                    {
                        return new SQLiteDataValue(@string);
                    }
                    break;

                case System.Text.Json.JsonValueKind.True:
                    return new SQLiteDataValue(true);

                case System.Text.Json.JsonValueKind.False:
                    return new SQLiteDataValue(false);

                case System.Text.Json.JsonValueKind.Null:
                    return null;

                case System.Text.Json.JsonValueKind.Undefined:
                    return null;

            }

            return null;
        }

    }
}

