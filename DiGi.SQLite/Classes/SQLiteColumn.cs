using DiGi.Core.Classes;
using DiGi.SQLite.Enums;
using DiGi.SQLite.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.SQLite.Classes
{
    public class SQLiteColumn : SerializableObject, ISQLiteObject
    {
        [JsonInclude, JsonPropertyName("Name")]
        private string name;

        [JsonInclude, JsonPropertyName("SQLiteDataType")]
        private SQLiteDataType? sQLiteDataType;

        public SQLiteColumn(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        public SQLiteColumn(string name, SQLiteDataType? sQLiteDataType)
            : base()
        {
            this.name = name;
            this.sQLiteDataType = sQLiteDataType;
        }

        public SQLiteColumn(SQLiteColumn sQLiteColumn)
            : base()
        {
            if (sQLiteColumn != null)
            {
                name = sQLiteColumn.name;
                sQLiteDataType = sQLiteColumn.sQLiteDataType;
            }
        }

        [JsonIgnore]
        public string Name
        {
            get
            {
                return name;
            }
        }

        [JsonIgnore]
        public SQLiteDataType? SQLiteDataType
        {
            get
            {
                return sQLiteDataType;
            }
        }
    }
}
