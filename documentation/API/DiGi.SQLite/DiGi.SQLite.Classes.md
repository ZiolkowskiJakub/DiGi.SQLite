#### [DiGi\.SQLite](index.md 'index')

## DiGi\.SQLite\.Classes Namespace
### Classes

<a name='DiGi.SQLite.Classes.SQLiteWrapper'></a>

## SQLiteWrapper Class

Provides a SQLite database implementation of the [DiGi\.Core\.IO\.Wrapper\.Classes\.Wrapper](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.wrapper.classes.wrapper 'DiGi\.Core\.IO\.Wrapper\.Classes\.Wrapper') class for persisting and retrieving serializable objects using unique references\.

```csharp
public class SQLiteWrapper : DiGi.Core.IO.Wrapper.Classes.Wrapper
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.IO\.Wrapper\.Classes\.Wrapper](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.wrapper.classes.wrapper 'DiGi\.Core\.IO\.Wrapper\.Classes\.Wrapper') → SQLiteWrapper
### Constructors

<a name='DiGi.SQLite.Classes.SQLiteWrapper.SQLiteWrapper()'></a>

## SQLiteWrapper\(\) Constructor

Initializes a new instance of the [SQLiteWrapper](DiGi.SQLite.Classes.md#DiGi.SQLite.Classes.SQLiteWrapper 'DiGi\.SQLite\.Classes\.SQLiteWrapper') class\.

```csharp
public SQLiteWrapper();
```
### Properties

<a name='DiGi.SQLite.Classes.SQLiteWrapper.ConnectionString'></a>

## SQLiteWrapper\.ConnectionString Property

Gets or sets the connection string used to connect to the SQLite database\.

```csharp
public string? ConnectionString { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Dispose(bool)'></a>

## SQLiteWrapper\.Dispose\(bool\) Method

Releases the resources used by the [SQLiteWrapper](DiGi.SQLite.Classes.md#DiGi.SQLite.Classes.SQLiteWrapper 'DiGi\.SQLite\.Classes\.SQLiteWrapper')\.

```csharp
protected override void Dispose(bool disposing);
```
#### Parameters

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Dispose(bool).disposing'></a>

`disposing` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True to release both managed and unmanaged resources; false to release only unmanaged resources\.

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(DiGi.Core.Classes.TypeReference,System.Collections.Generic.IEnumerable_DiGi.Core.Classes.UniqueReference_)'></a>

## SQLiteWrapper\.Pull\(TypeReference, IEnumerable\<UniqueReference\>\) Method

Retrieves all unique references for a specific type reference from the SQLite database\.

```csharp
protected override bool Pull(DiGi.Core.Classes.TypeReference? typeReference, out System.Collections.Generic.IEnumerable<DiGi.Core.Classes.UniqueReference>? uniqueReferences);
```
#### Parameters

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(DiGi.Core.Classes.TypeReference,System.Collections.Generic.IEnumerable_DiGi.Core.Classes.UniqueReference_).typeReference'></a>

`typeReference` [DiGi\.Core\.Classes\.TypeReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.typereference 'DiGi\.Core\.Classes\.TypeReference')

The [DiGi\.Core\.Classes\.TypeReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.typereference 'DiGi\.Core\.Classes\.TypeReference') to filter by\.

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(DiGi.Core.Classes.TypeReference,System.Collections.Generic.IEnumerable_DiGi.Core.Classes.UniqueReference_).uniqueReferences'></a>

`uniqueReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

When this method returns, contains a collection of [DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference') objects associated with the specified type reference\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if one or more unique references were successfully retrieved; otherwise, false\.

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(System.Collections.Generic.IEnumerable_DiGi.Core.Classes.TypeReference_)'></a>

## SQLiteWrapper\.Pull\(IEnumerable\<TypeReference\>\) Method

Retrieves all available type references stored in the SQLite database based on the defined table prefix\.

```csharp
protected override bool Pull(out System.Collections.Generic.IEnumerable<DiGi.Core.Classes.TypeReference> typeReferences);
```
#### Parameters

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(System.Collections.Generic.IEnumerable_DiGi.Core.Classes.TypeReference_).typeReferences'></a>

`typeReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.Classes\.TypeReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.typereference 'DiGi\.Core\.Classes\.TypeReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

When this method returns, contains a collection of [DiGi\.Core\.Classes\.TypeReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.typereference 'DiGi\.Core\.Classes\.TypeReference') objects found in the database\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if one or more type references were successfully retrieved; otherwise, false\.

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(System.Collections.Generic.IEnumerable_DiGi.Core.IO.Wrapper.Classes.WrapperItem_)'></a>

## SQLiteWrapper\.Pull\(IEnumerable\<WrapperItem\>\) Method

Retrieves the data for a specific set of wrapper items from the SQLite database and populates their JSON nodes\.

```csharp
protected override bool Pull(System.Collections.Generic.IEnumerable<DiGi.Core.IO.Wrapper.Classes.WrapperItem>? wrapperItems);
```
#### Parameters

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Pull(System.Collections.Generic.IEnumerable_DiGi.Core.IO.Wrapper.Classes.WrapperItem_).wrapperItems'></a>

`wrapperItems` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.wrapper.classes.wrapperitem 'DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of [DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.wrapper.classes.wrapperitem 'DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem') objects to be populated with data from the database\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the retrieval process was executed; otherwise, false\.

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Push(System.Collections.Generic.IEnumerable_DiGi.Core.IO.Wrapper.Classes.WrapperItem_)'></a>

## SQLiteWrapper\.Push\(IEnumerable\<WrapperItem\>\) Method

Persists the specified wrapper items into the SQLite database, creating tables if they do not exist\.

```csharp
protected override bool Push(System.Collections.Generic.IEnumerable<DiGi.Core.IO.Wrapper.Classes.WrapperItem>? wrapperItems);
```
#### Parameters

<a name='DiGi.SQLite.Classes.SQLiteWrapper.Push(System.Collections.Generic.IEnumerable_DiGi.Core.IO.Wrapper.Classes.WrapperItem_).wrapperItems'></a>

`wrapperItems` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.wrapper.classes.wrapperitem 'DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of [DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.wrapper.classes.wrapperitem 'DiGi\.Core\.IO\.Wrapper\.Classes\.WrapperItem') objects to be persisted\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the persistence operation was successful; otherwise, false\.