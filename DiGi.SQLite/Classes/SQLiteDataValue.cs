using DiGi.Core.Interfaces;
using System.Text.Json.Nodes;

namespace DiGi.SQLite.Classes
{
    public class SQLiteDataValue : SQLiteData<object>
    {
        public SQLiteDataValue(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        public SQLiteDataValue(SQLiteDataValue sQLiteDataValue)
            : base(sQLiteDataValue)
        {

        }

        public SQLiteDataValue(double value)
            : base(value)
        {

        }

        public SQLiteDataValue(bool value)
            : base(value)
        {

        }

        public SQLiteDataValue(string value)
            :base(value)
        {
        
        }

        public override ISerializableObject Clone()
        {
            return new SQLiteDataValue(this);
        }

    }
}
