#### [DiGi\.SQLite](DiGi.SQLite.Overview.md 'DiGi\.SQLite\.Overview')

## DiGi\.SQLite Namespace
### Classes

<a name='DiGi.SQLite.Convert'></a>

## Convert Class

```csharp
public static class Convert
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Convert
### Methods

<a name='DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_)'></a>

## Convert\.ToDiGi\<T\>\(SqliteConnection, Func\<T,bool\>\) Method

Converts serializable objects stored in a SQLite database using the provided connection to a list of objects of type [T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(SqliteConnection, System\.Func\<T,bool\>\)\.T')\.

```csharp
public static System.Collections.Generic.List<T>? ToDiGi<T>(SqliteConnection? sqliteConnection, System.Func<T?,bool>? func=null)
    where T : DiGi.Core.Interfaces.ISerializableObject;
```
#### Type parameters

<a name='DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).T'></a>

`T`

The type of serializable objects to retrieve\. Must implement [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')\.
#### Parameters

<a name='DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).sqliteConnection'></a>

`sqliteConnection` [Microsoft\.Data\.Sqlite\.SqliteConnection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite.sqliteconnection 'Microsoft\.Data\.Sqlite\.SqliteConnection')

The SQLite connection to use for querying data\.

<a name='DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(SqliteConnection, System\.Func\<T,bool\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

An optional filter function to determine if an object should be included in the result list\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(SqliteConnection, System\.Func\<T,bool\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of objects of type [T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(SqliteConnection,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(SqliteConnection, System\.Func\<T,bool\>\)\.T'), or null if the connection is null or no matching objects are found\.

<a name='DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_)'></a>

## Convert\.ToDiGi\<T\>\(string, Func\<T,bool\>\) Method

Converts serializable objects stored in a SQLite database file at the specified path to a list of objects of type [T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(string, System\.Func\<T,bool\>\)\.T')\.

```csharp
public static System.Collections.Generic.List<T>? ToDiGi<T>(string? path, System.Func<T?,bool>? func=null)
    where T : DiGi.Core.Interfaces.ISerializableObject;
```
#### Type parameters

<a name='DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).T'></a>

`T`

The type of serializable objects to retrieve\. Must implement [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')\.
#### Parameters

<a name='DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path to the SQLite database\.

<a name='DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(string, System\.Func\<T,bool\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

An optional filter function to determine if an object should be included in the result list\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(string, System\.Func\<T,bool\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of objects of type [T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToDiGi_T_(string,System.Func_T,bool_).T 'DiGi\.SQLite\.Convert\.ToDiGi\<T\>\(string, System\.Func\<T,bool\>\)\.T'), or null if the path is invalid or the file does not exist\.

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,SqliteConnection)'></a>

## Convert\.ToSQLite\<T\>\(this IEnumerable\<T\>, SqliteConnection\) Method

Converts a collection of serializable objects to a SQLite database using an existing connection\.

```csharp
public static bool ToSQLite<T>(this System.Collections.Generic.IEnumerable<T> serializableObjects, SqliteConnection sqliteConnection)
    where T : DiGi.Core.Interfaces.ISerializableObject;
```
#### Type parameters

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,SqliteConnection).T'></a>

`T`

The type of serializable objects, which must implement [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')\.
#### Parameters

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,SqliteConnection).serializableObjects'></a>

`serializableObjects` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,SqliteConnection).T 'DiGi\.SQLite\.Convert\.ToSQLite\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, SqliteConnection\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of objects to be converted and stored in the SQLite database\.

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,SqliteConnection).sqliteConnection'></a>

`sqliteConnection` [Microsoft\.Data\.Sqlite\.SqliteConnection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite.sqliteconnection 'Microsoft\.Data\.Sqlite\.SqliteConnection')

An open connection to the SQLite database\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the conversion was successful; otherwise, false\.

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,string)'></a>

## Convert\.ToSQLite\<T\>\(this IEnumerable\<T\>, string\) Method

Converts a collection of serializable objects to a SQLite database at the specified path\.

```csharp
public static bool ToSQLite<T>(this System.Collections.Generic.IEnumerable<T> serializableObjects, string path)
    where T : DiGi.Core.Interfaces.ISerializableObject;
```
#### Type parameters

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,string).T'></a>

`T`

The type of serializable objects, which must implement [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')\.
#### Parameters

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,string).serializableObjects'></a>

`serializableObjects` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](DiGi.SQLite.md#DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,string).T 'DiGi\.SQLite\.Convert\.ToSQLite\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, string\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of objects to be converted and stored in the SQLite database\.

<a name='DiGi.SQLite.Convert.ToSQLite_T_(thisSystem.Collections.Generic.IEnumerable_T_,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path where the SQLite database should be created or updated\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the conversion was successful; otherwise, false\.

<a name='DiGi.SQLite.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.SQLite.Query.ConnectionString(string)'></a>

## Query\.ConnectionString\(string\) Method

Generates a SQLite connection string based on the provided file path\.

```csharp
public static string? ConnectionString(string? path);
```
#### Parameters

<a name='DiGi.SQLite.Query.ConnectionString(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to the SQLite database file\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A formatted connection string if the path is valid; otherwise, [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.SQLite.Query.Exists(thisSqliteCommand,string)'></a>

## Query\.Exists\(this SqliteCommand, string\) Method

Checks whether a table with the specified name exists in the SQLite database\.

```csharp
public static bool Exists(this SqliteCommand? sqliteCommand, string? tableName);
```
#### Parameters

<a name='DiGi.SQLite.Query.Exists(thisSqliteCommand,string).sqliteCommand'></a>

`sqliteCommand` [Microsoft\.Data\.Sqlite\.SqliteCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite.sqlitecommand 'Microsoft\.Data\.Sqlite\.SqliteCommand')

The [Microsoft\.Data\.Sqlite\.SqliteCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite.sqlitecommand 'Microsoft\.Data\.Sqlite\.SqliteCommand') used to execute the existence check\.

<a name='DiGi.SQLite.Query.Exists(thisSqliteCommand,string).tableName'></a>

`tableName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the table to search for\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the table exists; otherwise, false\.

<a name='DiGi.SQLite.Query.Reference(thisDiGi.Core.Interfaces.ISerializableObject)'></a>

## Query\.Reference\(this ISerializableObject\) Method

Retrieves a string reference for the specified serializable object\.

```csharp
public static string? Reference(this DiGi.Core.Interfaces.ISerializableObject? serializableObject);
```
#### Parameters

<a name='DiGi.SQLite.Query.Reference(thisDiGi.Core.Interfaces.ISerializableObject).serializableObject'></a>

`serializableObject` [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')

The serializable object to obtain a reference from\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string representing the unique identifier of the object if it implements [DiGi\.Core\.Interfaces\.IUniqueObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iuniqueobject 'DiGi\.Core\.Interfaces\.IUniqueObject'),
            a hash code based on its string representation otherwise, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the object is null\.

<a name='DiGi.SQLite.Query.TableName(DiGi.Core.Classes.TypeReference)'></a>

## Query\.TableName\(TypeReference\) Method

Generates the SQLite table name for the specified type reference\.

```csharp
public static string? TableName(DiGi.Core.Classes.TypeReference? typeReference);
```
#### Parameters

<a name='DiGi.SQLite.Query.TableName(DiGi.Core.Classes.TypeReference).typeReference'></a>

`typeReference` [DiGi\.Core\.Classes\.TypeReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.typereference 'DiGi\.Core\.Classes\.TypeReference')

The type reference used to determine the table name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The generated table name as a string, or null if the type reference is null or an invalid unique identifier is generated\.