using DiGi.Core.Classes;
using DiGi.Core.Interfaces;

namespace DiGi.SQLite.Interfaces
{
    public interface ISQLiteData : ISerializableObject, ISQLiteObject
    {
        public UniqueIdReference UniqueIdReference { get; }
    }

    public interface ISQLiteData<T> : ISQLiteData
    {
        public T Value { get; }
    }
}
