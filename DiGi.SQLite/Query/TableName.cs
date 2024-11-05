using DiGi.Core.Classes;

namespace DiGi.SQLite
{
    public static partial class Query
    {
        public static string TableName(TypeReference typeReference)
        {
            if(typeReference == null)
            {
                return null;
            }

            string uniqueId = Core.Query.UniqueId(typeReference);
            if(string.IsNullOrWhiteSpace(uniqueId))
            {
                return null;
            }

            return string.Format("{0}_{1}", Constans.Table.Name.Prefix.Type, uniqueId);
        }

    }
}

