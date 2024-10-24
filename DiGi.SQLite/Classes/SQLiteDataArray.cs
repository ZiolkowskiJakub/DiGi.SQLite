using DiGi.Core.Interfaces;
using DiGi.SQLite.Interfaces;
using System.Text.Json.Nodes;

namespace DiGi.SQLite.Classes
{
    public class SQLiteDataArray : SQLiteData<JsonArray>
    {
        public SQLiteDataArray(JsonArray jsonArray)
            : base(jsonArray)
        {

        }

        public SQLiteDataArray(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        public SQLiteDataArray(SQLiteDataArray sQLiteDataArray)
            : base(sQLiteDataArray)
        {

        }

        public override ISerializableObject Clone()
        {
            return new SQLiteDataArray(this);
        }

    }
}