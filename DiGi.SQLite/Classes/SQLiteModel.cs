using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.SQLite.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.SQLite.Classes
{
    public class SQLiteModel : SerializableObject, ISerializableModel, ISQLiteObject
    {
        [JsonIgnore]
        private SQLiteDataValueCluster<ISQLiteData> sQLiteDataValueCluster = new SQLiteDataValueCluster<ISQLiteData>();

        public SQLiteModel()
        {

        }

        public SQLiteModel(IEnumerable<ISQLiteData> sQLiteDatas)
        {

        }

        public SQLiteModel(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        public List<T> AddRange<T>(IEnumerable<T> serializableObjects) where T : ISerializableObject
        {
            if(serializableObjects == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach(T serializableObject in serializableObjects)
            {
                bool added = Add(serializableObject);
                if(added)
                {
                    result.Add(serializableObject);
                }
            }

            return result;
        }

        public bool Add(ISerializableObject serializableObject)
        {
            if(serializableObject == null)
            {
                return false;
            }

            return Add(serializableObject.ToJsonObject());
        }

        public bool Add(JsonObject jsonObject)
        {
            ISQLiteData sQLiteData = Create.SQLiteData(jsonObject);
            if(sQLiteData == null)
            {
                return false;
            }

            return sQLiteDataValueCluster.Add(sQLiteData);
        }

        [JsonInclude, JsonPropertyName("SQLiteDatas")]
        public List<ISQLiteData> SQLiteDatas
        {
            get
            {
                return sQLiteDataValueCluster.Values;
            }

            set
            {
                sQLiteDataValueCluster.Values = value;
            }
        }

        public List<T> GetQSLiteDatas<T>() where T : ISQLiteData
        {
            return sQLiteDataValueCluster.GetValues<T>();
        }
    }
}
