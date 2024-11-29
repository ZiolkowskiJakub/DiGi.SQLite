using DiGi.Core.Interfaces;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static string Reference(this ISerializableObject serializableObject)
        {
            if (serializableObject == null)
            {
                return null;
            }

            if (serializableObject is IUniqueObject)
            {
                return ((IUniqueObject)serializableObject).Guid.ToString();
            }

            return Core.Convert.ToSystem_String(serializableObject).GetHashCode().ToString();
        }

    }
}

