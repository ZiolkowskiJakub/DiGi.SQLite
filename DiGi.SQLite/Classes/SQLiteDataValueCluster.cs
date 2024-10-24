using DiGi.Core.Classes;
using DiGi.SQLite.Interfaces;

namespace DiGi.SQLite.Classes
{
    public class SQLiteDataValueCluster<T> : SerializableObjectListCluster<TypeReference, UniqueIdReference, T>, ISQLiteObject where T : ISQLiteData
    {
        protected override TypeReference GetKey_1(T value)
        {
            return value?.UniqueIdReference?.TypeReference;
        }

        protected override UniqueIdReference GetKey_2(T value)
        {
            return value?.UniqueIdReference;
        }
    }
}
