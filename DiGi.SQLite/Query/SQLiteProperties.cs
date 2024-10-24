using DiGi.Core;
using DiGi.SQLite.Classes;
using DiGi.SQLite.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static List<SQLiteProperty> SQLiteProperties<T>(this JsonObject jsonObject, bool includeNested) where T : ISQLiteData
        {
            if (jsonObject == null)
            {
                return null;
            }

            List<SQLiteProperty> result = new List<SQLiteProperty>();

            List<JsonObject> jsonObjects_Nested = includeNested ? new List<JsonObject>() : null;

            foreach (KeyValuePair<string, JsonNode> keyValuePair in jsonObject)
            {
                JsonNode jsonNode = keyValuePair.Value;
                if(jsonNode == null)
                {
                    continue;
                }

                if(jsonObjects_Nested != null)
                {
                    System.Text.Json.JsonValueKind jsonValueKind = jsonNode.GetValueKind();

                    if (jsonValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        jsonObjects_Nested.Add(jsonNode.AsObject());
                    }
                    else if (jsonValueKind == System.Text.Json.JsonValueKind.Array)
                    {
                        JsonArray jsonArray = jsonNode.AsArray()?.Flatten();
                        if (jsonArray != null)
                        {
                            foreach (JsonNode jsonNode_JsonArray in jsonArray)
                            {
                                if (jsonNode_JsonArray?.GetValueKind() != System.Text.Json.JsonValueKind.Object)
                                {
                                    continue;
                                }

                                jsonObjects_Nested.Add(jsonNode_JsonArray.AsObject());
                            }
                        }
                    }
                }

                ISQLiteData sQLiteData = Create.SQLiteData(jsonNode);
                if(sQLiteData == null)
                {
                    continue;
                }

                if(!(sQLiteData is T))
                {
                    continue;
                }

                result.Add(new SQLiteProperty(keyValuePair.Key, sQLiteData));
            }

            if(jsonObjects_Nested != null)
            {
                foreach(JsonObject jsonObject_Nested in jsonObjects_Nested)
                {
                    List<SQLiteProperty> sQLiteProperties = SQLiteProperties<T>(jsonObject_Nested, includeNested);
                    if(sQLiteProperties != null && sQLiteProperties.Count != 0)
                    {
                        result.AddRange(sQLiteProperties);
                    }
                }
            }

            return result;
        }
    }
}

