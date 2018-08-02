## Table of Contents

* [Getting started](#GettingStarted)
	* [Requirements](#Requirements)
	* [Supported databases](#SupportedDatabases)
	* [Installation](#Installation)

* [Core concepts](#CoreConcepts)
	* [DbContext](#DbContext)
	* [DbCommand](#DbCommand)
	* [Events](#Events)
	* [Builders](#Builders)
	* [Mapping](#Mapping)
	* [When should you dispose?](#Dispose)

* [Code samples](#CodeSamples)
	* [Create and initialize a DbContext](#InitDbContext)
	* [Query for a list of items](#Query)
	* [Query for a single item](#QuerySingle)
	* [Query for a scalar value](#QueryValue)
	* [Query for a list of scalar values](#QueryValues)
	* [Parameters](#Parameters)
	* [Mapping](#CodeSamplesMapping)
	* [Multiple result sets](#MultiResultSets)
	* [Select data & Paging](#SelectData)
	* [Insert data](#InsertData)
	* [Update data](#UpdateData)
	* [Delete data](#DeleteData)
	* [Stored procedures](#StoredProcedures)
	* [Transactions](#Transactions)
	* [Entity factory](#EntityFactory)

# {anchor:Contents}Contents
## {anchor:GettingStarted}Getting started
{anchor:Requirements}**Requirements**
* .NET 4.0.

{anchor:SupportedDatabases}**Supported databases**
* MS SQL Server using the native .NET driver. 
* MS SQL Azure using the native .NET driver.
* MS Access using the native .NET driver.
* MS SQL Server Compact 4.0 through the [Microsoft SQL Server Compact 4.0 driver](http://www.microsoft.com/download/en/details.aspx?id=17876).
* Oracle through the [ODP.NET driver](http://www.oracle.com/technetwork/topics/dotnet/index-085163.html).
* MySQL through the [MySQL Connector .NET driver](http://www.mysql.com/downloads/connector/net/). 
* SQLite through the [SQLite ADO.NET Data Provider](http://system.data.sqlite.org/).
* PostgreSql through the [Npgsql](http://pgfoundry.org/projects/npgsql/) provider.
* IBM DB2
* Sybase through the [https://github.com/FredoKapo/FLUENT-ORM-ASE-PROVIDER](https://github.com/FredoKapo/FLUENT-ORM-ASE-PROVIDER) provider.

{anchor:Installation}**Installation**
If you are using NuGet: 
* Search for FluentData and click Install.
If you are not using NuGet:
# Download the zip with the binary files.
# Extract it, and copy the files to your solution or project folder.
# Add a project reference to FluentData.dll.

## {anchor:CoreConcepts}Core concepts
{anchor:DbContext}**DbContext**
This class is the starting point for working with FluentData. It has properties for defining configurations such as the connection string to the database, and operations for querying the database.

{anchor:DbCommand}**DbCommand**
This is the class that is responsible for performing the actual query against the database.

{anchor:Events}**Events**
The DbContext class has support for the following events:
* OnConnectionClosed
* OnConnectionOpened
* OnConnectionOpening
* OnError
* OnExecuted
* OnExecuting
By using any of these then you can for instance write to the log if an error has occurred or when a query has been executed.

{anchor:Builders}**Builders**
A builder provides a nice fluent API for generating SQL for insert, update and delete queries.

{anchor:Mapping}**Mapping**
FluentData can automap the result from a SQL query to either a dynamic type (new in .NET 4.0) or to your own .NET entity type (POCO - Plain Old CLR Object) by using the following convention:

+Automap to an entity type:+
# If the field name does not contain an underscore ("_") then it will try to try to automap to a property with the same name. For instance a field named "Name" would be automapped to a property also named "Name".
# If a field name does contain an underscore ("_") then it will try to map to a nested property. For instance a field named "Category_Name" would be automapped to the property "Category.Name".
If there is a mismatch between the fields in the database and in the entity type then the alias keyword in SQL can be used or you can create your own mapping method. Check the mapping section below for code samples.

+Automap to a dynamic type:+
# For dynamic types every field will be automapped to a property with the same name. For instance the field name Name would be automapped to the Name property.

{anchor:Dispose}**When should you dispose?**
* DbContext must be disposed if you have enabled UseTransaction or UseSharedConnection.
* DbCommand must be disposed if you have enabled UseMultiResult (or MultiResultSql).
* StoredProcedureBuilder must be disposed if you have enabled UseMultiResult.
In all the other cases dispose will be handled automatically by FluentData. This means that a database connection is opened just before a query is executed and closed just after the execution has been completed.

## {anchor:CodeSamples}Code samples
{anchor:InitDbContext}**Create and initialize a DbContext**
The connection string on the DbContext class can be initialized either by giving the connection string name in the *.config file or by sending in the entire connection string.

**Important configurations**
* IgnoreIfAutoMapFails - Calling this prevents automapper from throwing an exception if a column cannot be mapped to a corresponding property due to a name mismatch.

**Create and initialize a DbContext**
The DbContext can be initialized by either calling ConnectionStringName which will read the connection string from the *.config file:
{code:c#}
public IDbContext Context()
{
	return new DbContext().ConnectionStringName("MyDatabase",
			new SqlServerProvider());
}
{code:c#}

or by calling the ConnectionString method to set the connection string explicitly:
{code:c#}
public IDbContext Context()
{
	return new DbContext().ConnectionString(
	"Server=MyServerAddress;Database=MyDatabase;Trusted_Connection=True;", new SqlServerProvider());
}
{code:c#}

**Providers**
If you want to work against another database than SqlServer then simply replace the new SqlServerProvider() in the sample code above with any of the following:
AccessProvider, DB2Provider, OracleProvider, MySqlProvider, PostgreSqlProvider, SqliteProvider, SqlServerCompact, SqlAzureProvider, SqlServerProvider.

{anchor:Query}**Query for a list of items**
Return a list of dynamic objects (new in .NET 4.0):
{code:c#}
List<dynamic> products = Context.Sql("select * from Product").QueryMany<dynamic>();
{code:c#}

Return a list of strongly typed objects:
{code:c#}
List<Product> products = Context.Sql("select * from Product").QueryMany<Product>();
{code:c#}

Return a list of strongly typed objects in a custom collection:
{code:c#}
ProductionCollection products = Context.Sql("select * from Product").QueryMany<Product, ProductionCollection>();
{code:c#}

Return a DataTable:
See Query for a single item.

{anchor:QuerySingle}**Query for a single item**

Return as a dynamic object:
{code:c#}
dynamic product = Context.Sql(@"select * from Product
				where ProductId = 1").QuerySingle<dynamic>();
{code:c#}

Return as a strongly typed object:
{code:c#}
Product product = Context.Sql(@"select * from Product
			where ProductId = 1").QuerySingle<Product>();
{code:c#}

Return as a DataTable:
{code:c#}
DataTable products = Context.Sql("select * from Product").QuerySingle<DataTable>();
{code:c#}
Both QueryMany<DataTable> and QuerySingle<DataTable> can be called to return a DataTable, but since QueryMany returns a List<DataTable> then it's more convenient to call QuerySingle which returns just DataTable. Eventhough the method is called QuerySingle then multiple rows will still be returned as part of the DataTable.

{anchor:QueryValue}**Query for a scalar value**
{code:c#}
int numberOfProducts = Context.Sql(@"select count(*)
			from Product").QuerySingle<int>();
{code:c#}

{anchor:QueryValues}**Query for a list of scalar values**
{code:c#}
List<int> productIds = Context.Sql(@"select ProductId
				from Product").QueryMany<int>();
{code:c#}

{anchor:Parameters}**Parameters**
Indexed parameters:
{code:c#}
dynamic products = Context.Sql(@"select * from Product
			where ProductId = @0 or ProductId = @1", 1, 2).QueryMany<dynamic>();
{code:c#}

or:
{code:c#}
dynamic products = Context.Sql(@"select * from Product
			where ProductId = @0 or ProductId = @1")
			.Parameters(1, 2).QueryMany<dynamic>();
{code:c#}

Named parameters:
{code:c#}
dynamic products = Context.Sql(@"select * from Product
			where ProductId = @ProductId1 or ProductId = @ProductId2")
			.Parameter("ProductId1", 1)
			.Parameter("ProductId2", 2)
			.QueryMany<dynamic>();
{code:c#}

Output parameter:
{code:c#}
var command = Context.Sql(@"select @ProductName = Name from Product
			where ProductId=1")
			.ParameterOut("ProductName", DataTypes.String, 100);
command.Execute();

string productName = command.ParameterValue<string>("ProductName");
{code:c#}

List of parameters - in operator:
{code:c#}
List<int> ids = new List<int>() { 1, 2, 3, 4 };
//becareful here,don't leave any whitespace around in(...) syntax.
dynamic products = Context.Sql(@"select * from Product
			where ProductId in(@0)", ids).QueryMany<dynamic>();
{code:c#}

like operator:
{code:c#}
string cens = "%abc%";
Context.Sql("select * from Product where ProductName like @0",cens);
{code:c#}

{anchor:CodeSamplesMapping}**Mapping**
Automapping - 1:1 match between the database and the .NET object:
{code:c#}
List<Product> products = Context.Sql(@"select *
			from Product")
			.QueryMany<Product>();
{code:c#}

Automap to a custom collection:
{code:c#}
ProductionCollection products = Context.Sql("select * from Product").QueryMany<Product, ProductionCollection>();
{code:c#}

Automapping - Mismatch between the database and the .NET object, use the alias keyword in SQL:
Weakly typed:
{code:c#}
List<Product> products = Context.Sql(@"select p.*,
			c.CategoryId as Category_CategoryId,
			c.Name as Category_Name
			from Product p
			inner join Category c on p.CategoryId = c.CategoryId")
				.QueryMany<Product>();
{code:c#}
Here the p.* which is ProductId and Name would be automapped to the properties Product.Name and Product.ProductId, and {"Category_CategoryId"} and {"Category_Name"} would be automapped to Product.Category.CategoryId and Product.Category.Name.

Custom mapping using dynamic:
{code:c#}
List<Product> products = Context.Sql(@"select * from Product")
			.QueryMany<Product>(Custom_mapper_using_dynamic);

public void Custom_mapper_using_dynamic(Product product, dynamic row)
{
	product.ProductId = row.ProductId;
	product.Name = row.Name;
}
{code:c#}

Custom mapping using a datareader:
{code:c#}
List<Product> products = Context.Sql(@"select * from Product")
			.QueryMany<Product>(Custom_mapper_using_datareader);

public void Custom_mapper_using_datareader(Product product, IDataReader row)
{
	product.ProductId = row.GetInt32("ProductId");
	product.Name = row.GetString("Name");
}
{code:c#}

Or if you have a complex entity type where you need to control how it is created then the QueryComplexMany/QueryComplexSingle can be used:
{code:c#}
var products = new List<Product>();
Context.Sql("select * from Product").QueryComplexMany<Product>(products, MapComplexProduct);

private void MapComplexProduct(IList<Product> products, IDataReader reader)
{
	var product = new Product();
	product.ProductId = reader.GetInt32("ProductId");
	product.Name = reader.GetString("Name");
	products.Add(product);
}
{code:c#}

{anchor:MultiResultSets}**Multiple result sets**
FluentData supports multiple resultsets. This allows you to do multiple queries in a single database call. When this feature is used it's important to wrap the code inside a using statement as shown below in order to make sure that the database connection is closed.
{code:c#}
using (var command = Context.MultiResultSql)
{
	List<Category> categories = command.Sql(
			@"select * from Category;
			select * from Product;").QueryMany<Category>();

	List<Product> products = command.QueryMany<Product>();
}
{code:c#}
The first time the Query method is called it does a single query against the database. The second time the Query is called, FluentData already knows that it's running in a multiple result set mode, so it reuses the data retrieved from the first query.

{anchor:SelectData}**Select data and Paging**
A select builder exists to make selecting data and paging easy:
{code:c#}
List<Product> products = Context.Select<Product>("p.*, c.Name as Category_Name")
			       .From(@"Product p 
					inner join Category c on c.CategoryId = p.CategoryId")
			       .Where("p.ProductId > 0 and p.Name is not null")
			       .OrderBy("p.Name")
			       .Paging(1, 10).QueryMany();
{code:c#}
By calling Paging(1, 10) then the first 10 products will be returned.

{anchor:InsertData}**Insert data**
Using SQL:
{code:c#}
int productId = Context.Sql(@"insert into Product(Name, CategoryId)
			values(@0, @1);")
			.Parameters("The Warren Buffet Way", 1)
			.ExecuteReturnLastId<int>();
{code:c#}

Using a builder:
{code:c#}
int productId = Context.Insert("Product")
			.Column("Name", "The Warren Buffet Way")
			.Column("CategoryId", 1)
			.ExecuteReturnLastId<int>();
{code:c#}

Using a builder with automapping:
{code:c#}
Product product = new Product();
product.Name = "The Warren Buffet Way";
product.CategoryId = 1;

product.ProductId = Context.Insert<Product>("Product", product)
			.AutoMap(x => x.ProductId)
			.ExecuteReturnLastId<int>();
{code:c#}
We send in ProductId to the AutoMap method to get AutoMap to ignore and not map the ProductId since this property is an identity field where the value is generated in the database.

{anchor:UpdateData}**Update data**
Using SQL:
{code:c#}
int rowsAffected = Context.Sql(@"update Product set Name = @0
			where ProductId = @1")
			.Parameters("The Warren Buffet Way", 1)
			.Execute();
{code:c#}

Using a builder:
{code:c#}
int rowsAffected = Context.Update("Product")
			.Column("Name", "The Warren Buffet Way")
			.Where("ProductId", 1)
			.Execute();
{code:c#}

Using a builder with automapping:
{code:c#}
Product product = Context.Sql(@"select * from Product
			where ProductId = 1")
			.QuerySingle<Product>();
product.Name = "The Warren Buffet Way";

int rowsAffected = Context.Update<Product>("Product", product)
			.AutoMap(x => x.ProductId)
			.Where(x => x.ProductId)
			.Execute();
{code:c#}
We send in ProductId to the AutoMap method to get AutoMap to ignore and not map the ProductId since this is the identity field that should not get updated.


**IgnoreIfAutoMapFails**
When read from database,If some data columns not mappinged with entity class,by default ,will throw exception.

if you want ignore the exception, or the property not used for map data table,then you can use the IgnoreIfAutoMapFails(true),this will ignore the exception when read mapping error.
{code:c#}
context.IgnoreIfAutoMapFails(true);
{code:c#}
 
**Insert and update  - common Fill method**
{code:c#}
var product = new Product();
product.Name = "The Warren Buffet Way";
product.CategoryId = 1;

var insertBuilder = Context.Insert<Product>("Product", product).Fill(FillBuilder);

var updateBuilder = Context.Update<Product>("Product", product).Fill(FillBuilder);

public void FillBuilder(IInsertUpdateBuilder<Product> builder)
{
	builder.Column(x => x.Name);
	builder.Column(x => x.CategoryId);
}
{code:c#}

{anchor:DeleteData}**Delete data**
Using SQL:
{code:c#}
int rowsAffected = Context.Sql(@"delete from Product
			where ProductId = 1")
			.Execute();
{code:c#}

Using a builder:
{code:c#}
int rowsAffected = Context.Delete("Product")
			.Where("ProductId", 1)
			.Execute();
{code:c#}

{anchor:StoredProcedures}**Stored procedure**
Using SQL:
{code:c#}
var rowsAffected = Context.Sql("ProductUpdate")
			.CommandType(DbCommandTypes.StoredProcedure)
			.Parameter("ProductId", 1)
			.Parameter("Name", "The Warren Buffet Way")
			.Execute();
{code:c#}

Using a builder:
{code:c#}
var rowsAffected = Context.StoredProcedure("ProductUpdate")
			.Parameter("Name", "The Warren Buffet Way")
			.Parameter("ProductId", 1).Execute();
{code:c#}

Using a builder with automapping:
{code:c#}
var product = Context.Sql("select * from Product where ProductId = 1")
			.QuerySingle<Product>();

product.Name = "The Warren Buffet Way";

var rowsAffected = Context.StoredProcedure<Product>("ProductUpdate", product)
			.AutoMap(x => x.CategoryId).Execute();
{code:c#}

Using a builder with automapping and expressions:
{code:c#}
var product = Context.Sql("select * from Product where ProductId = 1")
			.QuerySingle<Product>();
product.Name = "The Warren Buffet Way";

var rowsAffected = Context.StoredProcedure<Product>("ProductUpdate", product)
			.Parameter(x => x.ProductId)
			.Parameter(x => x.Name).Execute();
{code:c#}

{anchor:Transactions}**Transactions**
FluentData supports transactions. When you use transactions its important to wrap the code inside a using statement to make sure that the database connection is closed. By default, if any exception occur or if Commit is not called then Rollback will automatically be called.
{code:c#}
using (var context = Context.UseTransaction(true))
{
	context.Sql("update Product set Name = @0 where ProductId = @1")
				.Parameters("The Warren Buffet Way", 1)
				.Execute();

	context.Sql("update Product set Name = @0 where ProductId = @1")
				.Parameters("Bill Gates Bio", 2)
				.Execute();

	context.Commit();
}
{code:c#}

{anchor:EntityFactory}**Entity factory**
The entity factory is responsible for creating object instances during automapping. If you have some complex business objects that require special actions during creation, you can create your own custom entity factory:
{code:c#}
List<Product> products = Context.EntityFactory(new CustomEntityFactory())
			.Sql("select * from Product")
			.QueryMany<Product>();

public class CustomEntityFactory : IEntityFactory
{
	public virtual object Resolve(Type type)
	{
		return Activator.CreateInstance(type);
	}
}
{code:c#}