using DiGi.Core.Interfaces;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static string Id(this ISerializableObject serializableObject)
        {
            if (serializableObject == null)
            {
                return null;
            }

            if (serializableObject is IUniqueObject)
            {
                return ((IUniqueObject)serializableObject).Guid.ToString("B");
            }

            return LongHashCode(Core.Convert.ToString(serializableObject)).ToString();
        }

    }
}

