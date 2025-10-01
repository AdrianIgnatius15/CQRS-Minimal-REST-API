# CQRS Minimal REST API
This code contains the REST API application that applies the concept of Command Query Segregation Responsibility (CQRS) pattern using .NET Core. Initially built using "self-rolled" code that creates a barebone structure of CQRS, later it will be swapped with library/framework called MediaR.

This project is to demonstrate my understanding of this pattern that is used in heavily-relied business applications such as eCommerce, Finance and more.

### Architecture
This branch contains Orders CQRS architecture. The architecture diagram is as below:

It uses "FluentValidator" package/library for it. You may use EntityFramework Core's validator if you want to but that's to implement constraints and validation before entering the data into the database.

![Orders CQRS Architecture Diagram](/images/Orders%20CQRS.png)


### Developer
Adrian Joseph.