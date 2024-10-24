using DiGi.Core.Classes;
using DiGi.SQLite.Enums;
using DiGi.SQLite.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DiGi.SQLite.Classes
{
    public class SQLiteProperty : SerializableObject, ISQLiteObject
    {
        [JsonInclude, JsonPropertyName("Name")]
        private string name = null;

        [JsonInclude, JsonPropertyName("SQLiteData")]
        private ISQLiteData sQLiteData = null;

        public SQLiteProperty(string name, ISQLiteData sQLiteData)
        {
            this.name = name;
            this.sQLiteData = sQLiteData;
        }

        public T GetSQLiteData<T>() where T : ISQLiteData
        {
            return sQLiteData is T ? (T)sQLiteData : default;
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
                return Query.SQLiteDataType(sQLiteData);
            }
        }
    }
}
