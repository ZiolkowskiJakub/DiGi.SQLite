using DiGi.Core.Classes;
using DiGi.Core.IO.Wrapper.Classes;
using DiGi.SQLite.Constants;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace DiGi.SQLite.Classes
{
    /// <summary>
    /// Provides a SQLite database implementation of the <see cref="Wrapper"/> class for persisting and retrieving serializable objects using unique references.
    /// </summary>
    public class SQLiteWrapper : Wrapper
    {
        private bool disposed = false;
        private SqliteConnection? sqliteConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteWrapper"/> class.
        /// </summary>
        public SQLiteWrapper()
            : base()
        {
        }

        ~SQLiteWrapper()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets the connection string used to connect to the SQLite database.
        /// </summary>
        public string? ConnectionString { get; set; } = null;

        /// <summary>
        /// Releases the resources used by the <see cref="SQLiteWrapper"/>.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposed)
            {
                if (disposing)
                {
                    if (sqliteConnection != null)
                    {
                        sqliteConnection.Close();
                        sqliteConnection.Dispose();
                    }
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Retrieves the data for a specific set of wrapper items from the SQLite database and populates their JSON nodes.
        /// </summary>
        /// <param name="wrapperItems">The collection of <see cref="WrapperItem"/> objects to be populated with data from the database.</param>
        /// <returns>True if the retrieval process was executed; otherwise, false.</returns>
        protected override bool Pull(IEnumerable<WrapperItem>? wrapperItems)
        {
            if (wrapperItems == null)
            {
                return false;
            }

            WrapperItemValueCluster wrapperItemValueCluster = [];
            foreach (WrapperItem wrapperItem in wrapperItems)
            {
                if (wrapperItem?.UniqueReference is null)
                {
                    continue;
                }

                wrapperItemValueCluster.Add(wrapperItem);
            }

            List<TypeReference>? typeReferences = wrapperItemValueCluster.GetKeys_1();
            if (typeReferences == null || typeReferences.Count == 0)
            {
                return false;
            }

            sqliteConnection ??= new SqliteConnection(ConnectionString);

            if (sqliteConnection.State == ConnectionState.Closed)
            {
                sqliteConnection.Open();
            }

            using SqliteCommand sqliteCommand = new() { Connection = sqliteConnection };

            foreach (TypeReference typeReference in typeReferences)
            {
                string? tableName = Query.TableName(typeReference);
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    continue;
                }

                if (!Query.Exists(sqliteCommand, tableName))
                {
                    continue;
                }

                List<WrapperItem>? wrapperItems_TypeReference = wrapperItemValueCluster.GetValues<WrapperItem>(typeReference);
                if (wrapperItems_TypeReference == null || wrapperItems_TypeReference.Count == 0)
                {
                    continue;
                }

                List<List<WrapperItem>>? wrapperItemsList = Core.Query.Split(wrapperItems_TypeReference, Constants.Query.MaxLength - 1);
                if (wrapperItemsList is null)
                {
                    continue;
                }

                foreach (List<WrapperItem> wrapperItems_Temp in wrapperItemsList)
                {
                    Dictionary<string, WrapperItem> dictionary = [];

                    StringBuilder stringBuilder = new(string.Format("SELECT UniqueReference, JsonNode, Checksum FROM {0} WHERE ", tableName));
                    for (int i = 0; i < wrapperItems_Temp.Count; i++)
                    {
                        stringBuilder.Append($"UniqueReference = @value{i}");
                        if (i < wrapperItems_Temp.Count - 1)
                        {
                            stringBuilder.Append(" OR ");
                        }

                        WrapperItem wrapperItem_TypeReference = wrapperItems_Temp[i];

                        if (wrapperItem_TypeReference?.UniqueReference?.ToString() is string uniqueReference)
                        {
                            dictionary[uniqueReference] = wrapperItem_TypeReference;
                        }
                    }

                    sqliteCommand.CommandText = stringBuilder.ToString();

                    sqliteCommand.Parameters.Clear();

                    for (int i = 0; i < wrapperItems_Temp.Count; i++)
                    {
                        sqliteCommand.Parameters.AddWithValue($"@value{i}", dictionary.Keys.ElementAt(i));
                    }

                    using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();

                    while (sqliteDataReader.Read())
                    {
                        string uniqueReference = sqliteDataReader.GetString(0);
                        string json = sqliteDataReader.GetString(1);
                        string? checksum = sqliteDataReader.IsDBNull(2) ? null : sqliteDataReader.GetString(2);

                        if (!dictionary.TryGetValue(uniqueReference, out WrapperItem wrapperItem) || wrapperItem == null)
                        {
                            continue;
                        }

                        wrapperItem.JsonNode = JsonNode.Parse(json);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Retrieves all available type references stored in the SQLite database based on the defined table prefix.
        /// </summary>
        /// <param name="typeReferences">When this method returns, contains a collection of <see cref="TypeReference"/> objects found in the database.</param>
        /// <returns>True if one or more type references were successfully retrieved; otherwise, false.</returns>
        protected override bool Pull(out IEnumerable<TypeReference> typeReferences)
        {
            sqliteConnection ??= new SqliteConnection(ConnectionString);

            if (sqliteConnection.State == ConnectionState.Closed)
            {
                sqliteConnection.Open();
            }

            HashSet<TypeReference> typeReferences_Temp = [];
            using (SqliteCommand sqliteCommand = new() { Connection = sqliteConnection })
            {
                List<string> names = [];

                sqliteCommand.CommandText = string.Format("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' AND name LIKE '{0}_%'", Table.Name.Prefix.Type);

                using (var reader = sqliteCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(0));
                    }
                }

                int count = names.Count;

                for (int i = 0; i < count; i++)
                {
                    sqliteCommand.CommandText = string.Format("SELECT UniqueReference FROM {0} LIMIT 1", names[i]);

                    object? result = sqliteCommand.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        continue;
                    }

                    if (!Core.Query.TryParse(result.ToString(), out UniqueReference? uniqueReference) || uniqueReference is null)
                    {
                        continue;
                    }

                    TypeReference? typeReference = uniqueReference.TypeReference;
                    if (typeReference == null)
                    {
                        continue;
                    }

                    typeReferences_Temp.Add(typeReference);
                }
            }

            typeReferences = typeReferences_Temp;
            return typeReferences_Temp != null && typeReferences_Temp.Count != 0;
        }

        /// <summary>
        /// Retrieves all unique references for a specific type reference from the SQLite database.
        /// </summary>
        /// <param name="typeReference">The <see cref="TypeReference"/> to filter by.</param>
        /// <param name="uniqueReferences">When this method returns, contains a collection of <see cref="UniqueReference"/> objects associated with the specified type reference.</param>
        /// <returns>True if one or more unique references were successfully retrieved; otherwise, false.</returns>
        protected override bool Pull(TypeReference? typeReference, out IEnumerable<UniqueReference>? uniqueReferences)
        {
            uniqueReferences = null;

            if (typeReference == null)
            {
                return false;
            }

            string? tableName = Query.TableName(typeReference);
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return false;
            }

            sqliteConnection ??= new SqliteConnection(ConnectionString);

            if (sqliteConnection.State == ConnectionState.Closed)
            {
                sqliteConnection.Open();
            }

            HashSet<UniqueReference> uniqueReferences_Temp = [];
            using (SqliteCommand sqliteCommand = new() { Connection = sqliteConnection })
            {
                sqliteCommand.CommandText = string.Format("SELECT UniqueReference FROM {0}", tableName);

                using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    string reference = sqliteDataReader.GetString(0);

                    if (!Core.Query.TryParse(reference, out UniqueReference? uniqueReference) || uniqueReference is null)
                    {
                        continue;
                    }

                    uniqueReferences_Temp.Add(uniqueReference);
                }
            }

            uniqueReferences = uniqueReferences_Temp;
            return uniqueReferences_Temp != null && uniqueReferences_Temp.Count != 0;
        }

        /// <summary>
        /// Persists the specified wrapper items into the SQLite database, creating tables if they do not exist.
        /// </summary>
        /// <param name="wrapperItems">The collection of <see cref="WrapperItem"/> objects to be persisted.</param>
        /// <returns>True if the persistence operation was successful; otherwise, false.</returns>
        protected override bool Push(IEnumerable<WrapperItem>? wrapperItems)
        {
            if (wrapperItems == null)
            {
                return false;
            }

            WrapperItemValueCluster wrapperItemValueCluster = [];
            foreach (WrapperItem wrapperItem in wrapperItems)
            {
                if (wrapperItem?.JsonNode == null)
                {
                    continue;
                }

                wrapperItemValueCluster.Add(wrapperItem);
            }

            List<TypeReference>? typeReferences = wrapperItemValueCluster.GetKeys_1();
            if (typeReferences == null || typeReferences.Count == 0)
            {
                return false;
            }

            sqliteConnection ??= new SqliteConnection(ConnectionString);

            if (sqliteConnection.State == ConnectionState.Closed)
            {
                sqliteConnection.Open();
            }

            using SqliteCommand sqliteCommand = new() { Connection = sqliteConnection };

            foreach (TypeReference typeReference in typeReferences)
            {
                string? tableName = Query.TableName(typeReference);
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    continue;
                }

                List<WrapperItem>? wrapperItems_TypeReference = wrapperItemValueCluster.GetValues<WrapperItem>(typeReference);
                if (wrapperItems_TypeReference == null || wrapperItems_TypeReference.Count == 0)
                {
                    continue;
                }

                sqliteCommand.CommandText = string.Format(@"CREATE TABLE IF NOT EXISTS {0} (Id INTEGER PRIMARY KEY AUTOINCREMENT, UniqueReference TEXT NOT NULL UNIQUE, JsonNode TEXT NOT NULL, Checksum TEXT)", tableName);
                sqliteCommand.ExecuteNonQuery();

                sqliteCommand.CommandText = string.Format("INSERT OR REPLACE INTO {0} (UniqueReference, JsonNode, Checksum) VALUES (@UniqueReference, @JsonNode, @Checksum)", tableName);

                sqliteCommand.Parameters.Clear();

                SqliteParameter sqliteParameter_UniqueReference = new("@UniqueReference", SqliteType.Text);
                sqliteCommand.Parameters.Add(sqliteParameter_UniqueReference);

                SqliteParameter sqliteParameter_JsonNode = new("@JsonNode", SqliteType.Text);
                sqliteCommand.Parameters.Add(sqliteParameter_JsonNode);

                SqliteParameter sqliteParameter_Checksum = new("@Checksum", SqliteType.Text);
                sqliteCommand.Parameters.Add(sqliteParameter_Checksum);

                foreach (WrapperItem wrapperItem_TypeReference in wrapperItems_TypeReference)
                {
                    object? checksum = wrapperItem_TypeReference.Checksum;

                    checksum ??= DBNull.Value;

                    sqliteParameter_UniqueReference.Value = wrapperItem_TypeReference?.UniqueReference?.ToString();
                    sqliteParameter_JsonNode.Value = wrapperItem_TypeReference?.JsonNode?.ToString();
                    sqliteParameter_Checksum.Value = checksum;

                    sqliteCommand.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}