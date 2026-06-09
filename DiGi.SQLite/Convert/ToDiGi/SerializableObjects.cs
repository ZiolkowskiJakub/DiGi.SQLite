using DiGi.Core.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace DiGi.SQLite
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts serializable objects stored in a SQLite database file at the specified path to a list of objects of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of serializable objects to retrieve. Must implement <see cref="ISerializableObject"/>.</typeparam>
        /// <param name="path">The file path to the SQLite database.</param>
        /// <param name="func">An optional filter function to determine if an object should be included in the result list.</param>
        /// <returns>A list of objects of type <typeparamref name="T"/>, or null if the path is invalid or the file does not exist.</returns>
        public static List<T>? ToDiGi<T>(string? path, Func<T?, bool>? func = null) where T : ISerializableObject
        {
            if (string.IsNullOrWhiteSpace(path) || !System.IO.File.Exists(path))
            {
                return null;
            }

            List<T>? result = [];

            using (SqliteConnection sqliteConnection = new($"Data Source={path}"))
            {
                try
                {
                    sqliteConnection.Open();

                    result = ToDiGi(sqliteConnection, func);
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

        /// <summary>
        /// Converts serializable objects stored in a SQLite database using the provided connection to a list of objects of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of serializable objects to retrieve. Must implement <see cref="ISerializableObject"/>.</typeparam>
        /// <param name="sqliteConnection">The SQLite connection to use for querying data.</param>
        /// <param name="func">An optional filter function to determine if an object should be included in the result list.</param>
        /// <returns>A list of objects of type <typeparamref name="T"/>, or null if the connection is null or no matching objects are found.</returns>
        public static List<T>? ToDiGi<T>(SqliteConnection? sqliteConnection, Func<T?, bool>? func = null) where T : ISerializableObject
        {
            if (sqliteConnection == null)
            {
                return null;
            }

            using SqliteCommand sqliteCommand = new() { Connection = sqliteConnection };

            sqliteCommand.CommandText = "SELECT Id, FullTypeName FROM Types";

            List<Tuple<int, Type>> tuples = [];
            using (SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
            {
                while (sqliteDataReader.Read())
                {
                    string fullTypeName = sqliteDataReader.GetString(1);

                    Type? type = Core.Query.Type(fullTypeName);
                    if (type == null)
                    {
                        continue;
                    }

                    if (!typeof(T).IsAssignableFrom(type))
                    {
                        continue;
                    }

                    int typeId = sqliteDataReader.GetInt32(0);

                    tuples.Add(new Tuple<int, Type>(typeId, type));
                }
            }

            if (tuples == null || tuples.Count == 0)
            {
                return null;
            }

            List<T> result = [];

            foreach (Tuple<int, Type> tuple in tuples)
            {
                sqliteCommand.CommandText = string.Format("SELECT Json FROM {0}", string.Format("Type_{0}", tuple.Item1));

                using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();

                while (sqliteDataReader.Read())
                {
                    List<T>? ts = Core.Convert.ToDiGi<T>(sqliteDataReader.GetString(0));
                    if (ts == null || ts.Count == 0)
                    {
                        continue;
                    }

                    if (func != null && !func.Invoke(ts[0]))
                    {
                        continue;
                    }

                    result.Add(ts[0]);
                }
            }

            return result;
        }
    }
}