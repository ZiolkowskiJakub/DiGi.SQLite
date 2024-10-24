using DiGi.Core.Classes;
using DiGi.SQLite.Enums;
using DiGi.SQLite.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.SQLite.Classes
{
    public abstract class SQLiteData : SerializableObject, ISQLiteData
    {
        public SQLiteData()
            : base()
        {

        }

        public SQLiteData(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        [JsonIgnore]
        public abstract UniqueIdReference UniqueIdReference { get; }
    }

    public abstract class SQLiteData<T> : SQLiteData, ISQLiteData<T>
    {
        [JsonInclude, JsonPropertyName("Value")]
        protected T value;

        [JsonIgnore]
        private UniqueIdReference uniqueIdReference = null;

        public SQLiteData(T value)
            :base()
        {
            this.value = value;
        }

        public SQLiteData(JsonObject jsonObject)
            :base(jsonObject)
        {

        }

        public SQLiteData(SQLiteData<T> sQLiteData)
        {
            if(sQLiteData != null)
            {
                value = sQLiteData.value;
            }
        }

        [JsonIgnore]
        public override UniqueIdReference UniqueIdReference
        {
            get
            {
                if (value == null)
                {
                    return null;
                }

                if (uniqueIdReference == null)
                {
                    uniqueIdReference = Core.Create.UniqueIdReference(value);
                }

                return uniqueIdReference?.Clone() as UniqueIdReference;
            }
        }

        [JsonIgnore]
        public T Value
        {
            get
            {
                return value;
            }
        }

        public SQLiteDataType? SQLiteDataType
        {
            get
            {
               return Query.SQLiteDataType(value);
            }
        }
    }
}
