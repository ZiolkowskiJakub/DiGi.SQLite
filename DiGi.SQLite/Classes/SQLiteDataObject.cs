using DiGi.Core.Interfaces;
using System.Text.Json.Nodes;

namespace DiGi.SQLite.Classes
{
    public class SQLiteDataObject : SQLiteData<JsonObject>
    {
        public SQLiteDataObject(JsonObject jsonObject)
            : base(GetJsonObject(jsonObject, true)) 
        {
            value = GetJsonObject(jsonObject, false);
        }

        public SQLiteDataObject(SQLiteDataObject sQLiteDataObject)
            : base(sQLiteDataObject)
        {

        }

        public override ISerializableObject Clone()
        {
            return new SQLiteDataObject(this);
        }

        private static JsonObject GetJsonObject(JsonObject jsonObject, bool @base)
        {
            if(jsonObject == null)
            {
                return null;
            }

            if (Core.Query.FullTypeName(jsonObject) == Core.Query.FullTypeName(typeof(SQLiteDataObject)))
            {
                return @base ? jsonObject : null;
            }
            else
            {
                return @base ? null : jsonObject;
            }
        }
    }
}

