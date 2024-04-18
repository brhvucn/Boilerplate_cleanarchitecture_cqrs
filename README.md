# Boilerplate Project Clean Architecture & CQRS
This is a boilerplate project to show Domain Driven Design (DDD), CQRS and clean architecture in a simple setup.

This solution uses the following technologies:
* [Dapper](https://www.nuget.org/packages/Dapper/) to access the database
* [MediatR](https://www.nuget.org/packages/MediatR/) to dispatch commands and queries
* [FluentValidation](https://www.nuget.org/packages/FluentValidation/) to ensure validation rules
* [EnsureThat](https://www.nuget.org/packages/EnsureThatCore/) to create guard clauses

## About the Project
CentiSoft is a small company that builds a CRM system and sells it to their customers. 

## Litterature
[The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

[A Template for Clean Domain Driven Design Architecture](https://blog.jacobsdata.com/2020/03/02/a-clean-domain-driven-design-architectural-template)

[A Brief Intro to Clean Architecture, Clean DDD and CQRS](https://blog.jacobsdata.com/2020/02/19/a-brief-intro-to-clean-architecture-clean-ddd-and-cqrs)

[Are CQRS Commands a part of the Domain Model](https://enterprisecraftsmanship.com/posts/cqrs-commands-part-domain-model/)

[CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

[Value Object: A Better implementation](https://enterprisecraftsmanship.com/posts/value-object-better-implementation/)

[Aggregate Root Design: Separate behavior and data for persistence](https://www.youtube.com/watch?v=GtWVGJp061A)

# Exercise - 1
The purpose of this exercise is to make yourself familiar with the structure in an application / project that is using the CQRS architecture. Look at the Command and Queries and think about why adding new files is making a more resilient application (less error prone) and how this will help in not exponentially increase the complexity / amounts of test each time a new features is added, but rather keep a liniar growth in complexity.

Next is extending the system. The end goal is to build a system that has customers, contacts, products, orders etc.

1: Modify the existing solution and add a feature that will add products to the system.
1.1: Add feature "Create Product"
1.1.1: Create a new Domain object: "Product". The properties are: Id (int), Name (string), SKU (string), Price (int)
1.1.2: Create guard clauses in the domain object controller to prevent it from creating an invalid object
1.1.3: Create a new "Input Request (dto)" that will handle the input into the controller. Use the NuGet package "FluentValidation" to validate this object: Note: do not do this in the constructor - the automatic generation of the object from JSON in the API controller will "break" if cannot convert it.
1.1.4: Create a new "Command" to represent the "Create Product" command. Make sure it cannot be constructed into an invalid object. Use validation or guard clauses.
1.1.5: Create a new "CommandHandler" to handle the "Command". Make dependency injection in this to take the ProductRepository (this does not exist, you create it)
1.1.6: Create a new "API Controller" in the API project. It should take in the "Request DTO", validate it, create a command and dispatch the command to the right CommandHandler.
1.1.7: Add tests for "Create Product". Test the Domain object, the DTO, The Commands and the CommandHandlers

2: Modify the existing solution and add a feature that will read a single product from the system.
2.1: Add feature: "Read Product" (same steps as above)
2.1.1: Add tests for "Read Product". Test the Domain Object, the DTO, the Commands and the CommandHandlers
