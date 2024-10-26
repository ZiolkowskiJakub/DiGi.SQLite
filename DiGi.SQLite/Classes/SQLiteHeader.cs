using DiGi.Core.Classes;
using DiGi.SQLite.Enums;
using DiGi.SQLite.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.SQLite.Classes
{
    public class SQLiteHeader : SerializableObject, ISQLiteObject, IEnumerable<SQLiteColumn>
    {
        [JsonInclude, JsonPropertyName("Name")]
        private string name;

        [JsonIgnore]
        private Dictionary<string, SQLiteColumn> dictionary = new Dictionary<string, SQLiteColumn>();

        public SQLiteHeader(JsonObject jsonObject)
            : base(jsonObject)
        {

        }

        public SQLiteHeader(SQLiteHeader sQLiteHeader)
            : base()
        {
            if (sQLiteHeader != null)
            {
                SQLiteColumns = sQLiteHeader.SQLiteColumns;
                name = sQLiteHeader.name;
            }
        }

        public SQLiteHeader(string name, IEnumerable<SQLiteColumn> sQLiteColumns)
            : base()
        {
            this.name = name;

            if (sQLiteColumns != null)
            {
                SQLiteColumns = new List<SQLiteColumn>(sQLiteColumns);
            }
        }

        [JsonInclude, JsonPropertyName("SQLiteColumns")]
        public List<SQLiteColumn> SQLiteColumns
        {
            get
            {
                return dictionary.Values.ToList();
            }

            set
            {
                dictionary.Clear();
                if (value == null)
                {
                    return;
                }

                foreach (SQLiteColumn sQLiteColumn in value)
                {
                    if (string.IsNullOrWhiteSpace(sQLiteColumn?.Name))
                    {
                        continue;
                    }

                    dictionary[sQLiteColumn.Name] = sQLiteColumn;
                }
            }
        }

        public SQLiteColumn this[string name]
        {
            get
            {
                if (!dictionary.TryGetValue(name, out SQLiteColumn result))
                {
                    return null;
                }

                return result;
            }
        }

        [JsonIgnore]
        public string Name
        {
            get
            {
                return name;
            }
        }

        public IEnumerator<SQLiteColumn> GetEnumerator()
        {
            return dictionary.Values.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}