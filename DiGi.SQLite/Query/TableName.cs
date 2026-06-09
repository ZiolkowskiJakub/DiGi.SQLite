using DiGi.Core.Classes;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        /// <summary>
        /// Generates the SQLite table name for the specified type reference.
        /// </summary>
        /// <param name="typeReference">The type reference used to determine the table name.</param>
        /// <returns>The generated table name as a string, or null if the type reference is null or an invalid unique identifier is generated.</returns>
        public static string? TableName(TypeReference? typeReference)
        {
            if (typeReference == null)
            {
                return null;
            }

            string uniqueId = Core.Query.UniqueId(typeReference);
            if (string.IsNullOrWhiteSpace(uniqueId))
            {
                return null;
            }

            return string.Format("{0}_{1}", Constants.Table.Name.Prefix.Type, uniqueId);
        }
    }
}