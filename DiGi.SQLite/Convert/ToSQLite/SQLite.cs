using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.SQLite.Classes;
using DiGi.SQLite.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.SQLite
{
    public static partial class Convert
    {
        public static bool ToSQLite<T>(this IEnumerable<T> serializableObjects, string path) where T : ISerializableObject
        {
            if (string.IsNullOrWhiteSpace(path) || !System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
            {
                return false;
            }

            bool result = false;

            using (SqliteConnection sqliteConnection = new SqliteConnection($"Data Source={path}"))
            {
                try
                {
                    sqliteConnection.Open();

                    result = ToSQLite(serializableObjects, sqliteConnection);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    sqliteConnection.Close();
                }
            }

            return result;
        }

        public static bool ToSQLite<T>(this IEnumerable<T> serializableObjects, SqliteConnection sqliteConnection) where T : ISerializableObject
        {
            if (serializableObjects == null)
            {
                return false;
            }

            Dictionary<string, List<T>> dictionary = new Dictionary<string, List<T>>();
            foreach (T serializableObject in serializableObjects)
            {
                string fullTypeName = Core.Query.FullTypeName(serializableObject?.GetType());
                if (string.IsNullOrWhiteSpace(fullTypeName))
                {
                    continue;
                }

                if (!dictionary.TryGetValue(fullTypeName, out List<T> serializableObjects_Temp) || serializableObjects_Temp == null)
                {
                    serializableObjects_Temp = new List<T>();
                    dictionary[fullTypeName] = serializableObjects_Temp;
                }

                serializableObjects_Temp.Add(serializableObject);
            }

            using (SqliteCommand sqliteCommand = new SqliteCommand() { Connection = sqliteConnection })
            {
                sqliteCommand.CommandText = @"CREATE TABLE IF NOT EXISTS Types (Id INTEGER PRIMARY KEY AUTOINCREMENT, FullTypeName TEXT NOT NULL UNIQUE)";
                sqliteCommand.ExecuteNonQuery();

                sqliteCommand.CommandText = "INSERT OR IGNORE INTO Types (FullTypeName) VALUES (@FullTypeName)";
                foreach (string fullTypeName in dictionary.Keys)
                {
                    sqliteCommand.Parameters.Clear();
                    sqliteCommand.Parameters.AddWithValue("@FullTypeName", fullTypeName);

                    sqliteCommand.ExecuteNonQuery();
                }

                foreach (KeyValuePair<string, List<T>> keyValuePair in dictionary)
                {
                    if (keyValuePair.Value == null || keyValuePair.Value.Count == 0)
                    {
                        continue;
                    }

                    string fullTypeName = keyValuePair.Key;

                    sqliteCommand.CommandText = "SELECT Id FROM Types WHERE FullTypeName = @FullTypeName LIMIT 1";

                    sqliteCommand.Parameters.Clear();
                    sqliteCommand.Parameters.AddWithValue("@FullTypeName", fullTypeName);

                    int typeId = System.Convert.ToInt32(sqliteCommand.ExecuteScalar());

                    string tableName = string.Format("Type_{0}", typeId);

                    sqliteCommand.CommandText = string.Format(@"CREATE TABLE IF NOT EXISTS {0} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Reference TEXT NOT NULL UNIQUE, Json TEXT NOT NULL)", tableName);
                    sqliteCommand.ExecuteNonQuery();

                    sqliteCommand.CommandText = string.Format("INSERT OR REPLACE INTO {0} (Reference, Json) VALUES (@Reference, @Json)", tableName);

                    sqliteCommand.Parameters.Clear();

                    SqliteParameter sqliteParameter_Reference = new SqliteParameter("@Reference", SqliteType.Text);
                    sqliteCommand.Parameters.Add(sqliteParameter_Reference);

                    SqliteParameter sqliteParameter_Json = new SqliteParameter("@Json", SqliteType.Text);
                    sqliteCommand.Parameters.Add(sqliteParameter_Json);

                    foreach (T serializableObject in keyValuePair.Value)
                    {
                        if (serializableObject == null)
                        {
                            continue;
                        }

                        string reference = serializableObject.Reference();
                        if (reference == null)
                        {
                            continue;
                        }

                        string json = Core.Convert.ToString(serializableObject);
                        if (json == null)
                        {
                            continue;
                        }

                        sqliteParameter_Reference.Value = reference;
                        sqliteParameter_Json.Value = json;

                        sqliteCommand.ExecuteNonQuery();
                    }
                }
            }

            return true;
        }

        public static bool ToSQLite(this SQLiteModel sQLiteModel, string path)
        {
            if (sQLiteModel == null || string.IsNullOrWhiteSpace(path) || !System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
            {
                return false;
            }

            List<ISQLiteData> sQLiteDatas = sQLiteModel.SQLiteDatas;
            if(sQLiteDatas == null)
            {
                return false;
            }

            List<SQLiteDataObject> sQLiteDataObjects = sQLiteModel.GetQSLiteDatas<SQLiteDataObject>();
            if (sQLiteDataObjects == null)
            {
                return false;
            }

            SQLiteDataValueCluster<SQLiteDataObject> sQLiteDataValueCluster_Temp = new SQLiteDataValueCluster<SQLiteDataObject>();

            foreach (SQLiteDataObject sQLiteDataObject in sQLiteDataObjects)
            {
                if (sQLiteDataObject == null)
                {
                    continue;
                }

                sQLiteDataValueCluster_Temp.Add(sQLiteDataObject);

                List<SQLiteProperty> sQLiteProperties = Query.SQLiteProperties<SQLiteDataObject>(sQLiteDataObject.Value, true);
                if (sQLiteProperties != null)
                {
                    foreach (SQLiteProperty sQLiteProperty in sQLiteProperties)
                    {
                        if (sQLiteProperty == null)
                        {
                            continue;
                        }

                        SQLiteDataObject sQLiteDataObject_Temp = sQLiteProperty.GetSQLiteData<SQLiteDataObject>();
                        sQLiteDataValueCluster_Temp.Add(sQLiteDataObject_Temp);
                    }
                }
            }

            List<TypeReference> typeReferences = sQLiteDataValueCluster_Temp.GetKeys_1();
            if (typeReferences != null)
            {
                foreach (TypeReference typeReference in typeReferences)
                {
                    List<SQLiteDataObject> sQLiteDataObjects_Type = sQLiteDataValueCluster_Temp.GetValues<SQLiteDataObject>(typeReference);


                }
            }

            return false;
        }

    }
}

