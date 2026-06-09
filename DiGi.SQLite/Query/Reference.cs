using DiGi.Core.Interfaces;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves a string reference for the specified serializable object.
        /// </summary>
        /// <param name="serializableObject">The serializable object to obtain a reference from.</param>
        /// <returns>A string representing the unique identifier of the object if it implements <see cref="IUniqueObject"/>, 
        /// a hash code based on its string representation otherwise, or <see langword="null"/> if the object is null.</returns>
        public static string? Reference(this ISerializableObject? serializableObject)
        {
            if (serializableObject == null)
            {
                return null;
            }

            if (serializableObject is IUniqueObject uniqueObject)
            {
                return uniqueObject.UniqueId;
            }

            return Core.Convert.ToSystem_String(serializableObject)?.GetHashCode().ToString();
        }
    }
}