# CQRS Minimal REST API
This code contains the REST API application that applies the concept of Command Query Segregation Responsibility (CQRS) pattern using .NET Core. Initially built using "self-rolled" code that creates a barebone structure of CQRS, later it will be swapped with library/framework called MediaR.

This project is to demonstrate my understanding of this pattern that is used in heavily-relied business applications such as eCommerce, Finance and more.

### Architecture
This branch contains Validation CQRS architecture. The architecture diagram is as below:
**NOTE: Validation is not a unique feature in CQRS architecture. Validation is a common and most important feature in any type of REST API architecture, be it, CRUD architecture, CQRS, Minimal, MVC and etc. Validation ensures that the data send over to the API to be inserted into the database is clean and has integrity. Hence, this project (especially this branch) will include validation as part of industry standards.

It uses "FluentValidator" package/library for it. You may use EntityFramework Core's validator if you want to but that's to implement constraints and validation before entering the data into the database.

![Validation CQRS Architecture Diagram](/images/Validator%20CQRS.png)


### Developer
Adrian Joseph.