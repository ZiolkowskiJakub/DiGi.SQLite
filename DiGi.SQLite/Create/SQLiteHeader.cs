using DiGi.SQLite.Classes;
using DiGi.SQLite.Enums;
using DiGi.SQLite.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.SQLite
{
    public static partial class Create
    {
        public static SQLiteHeader SQLiteHeader(this IEnumerable<SQLiteDataObject> sQLiteDataObjects)
        {
            if(sQLiteDataObjects == null || sQLiteDataObjects.Count() == 0)
            {
                return null;
            }

            Dictionary<string, SQLiteDataType?> dictionary = new Dictionary<string, SQLiteDataType?>();
            foreach(SQLiteDataObject sQLiteDataObject in sQLiteDataObjects)
            {
                List<SQLiteProperty> sQLiteProperties = Query.SQLiteProperties<ISQLiteData>(sQLiteDataObject?.Value, false);
                if(sQLiteProperties == null)
                {
                    continue;
                }

                foreach(SQLiteProperty sQLiteProperty in sQLiteProperties)
                {
                    if(sQLiteProperty == null)
                    {
                        continue;
                    }

                    string name = sQLiteProperty.Name;
                    SQLiteDataType? sQLiteDataType = sQLiteProperty.SQLiteDataType;

                    if(!dictionary.TryGetValue(name, out SQLiteDataType? sQLiteDataType_Existing) || sQLiteDataType_Existing == null || !sQLiteDataType_Existing.HasValue)
                    {
                        dictionary[name] = sQLiteDataType;
                    }
                }
            }

            List<SQLiteColumn> sQLiteColumns = new List<SQLiteColumn>();
            foreach(KeyValuePair<string, SQLiteDataType?> keyValuePair in dictionary)
            {
                sQLiteColumns.Add(new SQLiteColumn(keyValuePair.Key, keyValuePair.Value));
            }

            throw new System.NotImplementedException();

            //TODO: Continue here (WIP)
            //return new SQLiteHeader();
        }
    }
}

