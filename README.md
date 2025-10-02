# CQRS Minimal REST API
This code contains the REST API application that applies the concept of Command Query Segregation Responsibility (CQRS) pattern using .NET Core. Initially built using "self-rolled" code that creates a barebone structure of CQRS, later it will be swapped with library/framework called MediaR.

This project is to demonstrate my understanding of this pattern that is used in heavily-relied business applications such as eCommerce, Finance and more.

### Architecture
This branch contains Split Database CQRS architecture. The architecture diagram is as below:

It uses "FluentValidator" package/library for it. You may use EntityFramework Core's validator if you want to but that's to implement constraints and validation before entering the data into the database.

This is an example of how events are used to emit when an "order" is created. This branch also splits the database which is crucial in CQRS architecture which is "Read" database & "Write" database.

![Split Database CQRS Architecture Diagram](/images/Split%20of%20Databases%20CQRS.png)

##### Creating Migrations Using EntityFramework Core
Since the database is split into 2, meaning it should have a "Read" database and "Write" database. In this case, when creating migrations using EntityFramework Core library to create database, use this command below.

```console
dotnet ef migrations add ReadDbMigrations --context ReadDbContext --output-dir Migrations/Read
```

```console
dotnet ef migrations add WriteDbMigrations --context WriteDbContext --output-dir Migrations/Write
```

This will create the migrations to be applied on the database in the Migrations>Read/Write folders separately. Then, to apply them type and execute the following command line.

```console
dotnet ef database update --context WriteDbContext
```

```console
dotnet ef database update --context ReadDbContext
```

This will apply the migrations into their specific database context which is coded inside "Data" folder


### Developer
Adrian Joseph.