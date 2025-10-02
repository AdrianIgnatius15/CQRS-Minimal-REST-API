# CQRS Minimal REST API
This code contains the REST API application that applies the concept of Command Query Segregation Responsibility (CQRS) pattern using .NET Core. Initially built using "self-rolled" code that creates a barebone structure of CQRS, later it will be swapped with library/framework called MediaR.

This project is to demonstrate my understanding of this pattern that is used in heavily-relied business applications such as eCommerce, Finance and more.

### Architecture
This branch contains no CQRS architecture. The architecture diagram is as below:
![No CQRS Architecture Diagram](/images/No%20CQRS.drawio.png)

#### Branches in this code.
This repository is my exploration, my learning and my proof of understanding of this architecture. Here are the list of branches that builds up to the industry standard code architecture which works.

    1. main --> The basic REST API which is the minimal API that performs only "Create, Delete, Update and Delete" operation. No CQRS
    2. simple-cqrs --> The basic REST API which implements CQRS architecture but it deals with one database.
    3. evolving-CQRS-REST-API --> The basic REST API which implements CQRS architecture but uses DTO (Data Transfer Objects) data models
    4. validator-CQRS-REST-API --> The basic REST API which implements CQRS architecture but it deals with one database and it does data validation before insertion of data into the database.
    5. orders-CQRS-REST-API --> The basic REST API which implements CQRS architecture but it deals with one database and it does data validation before insertion of data into the database. It also returns all "orders".
    6. events-CQRS-REST-API --> The branch uses a build-from-scratch events publisher when an "order" is created but still maintains one database. The event is then displayed on the console terminal to simulate the phenomena called "Event Sourcing".
    7. split-database-CQRS-REST-API --> The code now splits the database into 2 which is "Read" and "Write" database and it uses event sourcing concept still from the previous branch.
    8. split-database-event-CQRS-REST-API --> The code is now implements a build-from-scratch industry code to handle events and publishing events.
    9. mediatr-CQRS-REST-API --> The code this time subsitute the build-from-scratch industry code to handle events and publishing events to using the library called "Mediatr" library.

All branches will have README.md files and it will contain a detailed explanation and the architecture image to show you how it has been constructed.

### Developer
Adrian Joseph.

### Credits
[Les Jackson](https://www.youtube.com/@binarythistle)