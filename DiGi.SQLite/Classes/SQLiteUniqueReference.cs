using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.SQLite.Classes
{
    public class SQLiteUniqueReference : Reference
    {
        [JsonInclude, JsonPropertyName("TypeReference")]
        private TypeReference typeReference;

        [JsonInclude, JsonPropertyName("Id")]
        private string id;

        private SQLiteUniqueReference(string fullTypeName, string id)
            : base()
        {
            typeReference = new TypeReference(fullTypeName);
            this.id = id;
        }

        public SQLiteUniqueReference(string fullTypeName, Guid guid)
            : base()
        {
            typeReference = new TypeReference(fullTypeName);
            id = guid.ToString("B");
        }

        public SQLiteUniqueReference(string fullTypeName, long @long)
            : base()
        {
            typeReference = new TypeReference(fullTypeName);
            id = @long.ToString();
        }

        public SQLiteUniqueReference(Type type, Guid guid)
            : base()
        {
            typeReference = new TypeReference(type);
            id = guid.ToString("B");
        }

        public SQLiteUniqueReference(Type type, long @long)
            : base()
        {
            typeReference = new TypeReference(type);
            id = @long.ToString();
        }

        public SQLiteUniqueReference(ISerializableObject serializableObject)
            : base()
        {
            if (serializableObject != null)
            {
                typeReference = new TypeReference(serializableObject);
                id = serializableObject.Id();
            }
        }

        public SQLiteUniqueReference(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        public override string ToString()
        {
            string result = base.ToString();
            if (!string.IsNullOrWhiteSpace(result))
            {
                result += "::";
            }

            if(string.IsNullOrEmpty(id))
            {
                result += id;
            }


            return result;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override ISerializableObject Clone()
        {
            return new UniqueReference(typeReference?.FullTypeName, id);
        }

        public static bool operator ==(SQLiteUniqueReference sQLiteUniqueReference_1, SQLiteUniqueReference sQLiteUniqueReference_2)
        {
            return sQLiteUniqueReference_1?.ToString() == sQLiteUniqueReference_2?.ToString();
        }

        public static bool operator !=(SQLiteUniqueReference sQLiteUniqueReference_1, SQLiteUniqueReference sQLiteUniqueReference_2)
        {
            return sQLiteUniqueReference_1?.ToString() != sQLiteUniqueReference_2?.ToString();
        }

        [JsonIgnore]
        public string Id
        {
            get
            {
                return id;
            }
        }

        [JsonIgnore]
        public TypeReference TypeReference
        {
            get
            {
                return typeReference;
            }
        }
    }
}
