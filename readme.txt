# ToDoListApp

Brief project description here.

## Project Overview

Its a ToDoList application and it has Create, Detail, Edit, Delete functionality.It has been developed in ASP.Net MVC 5 with 
Dotnet Framework 4.8.

As asked it has been developed with DotNet with Azure.

It is using Micro ORM Dapper to avoid redudent code of ADO.Net.

It is following clean architecture. It follows onion architecture with Domain driven pattern. Domain layer is the inner most layer 
and does not depend on any other layer. It has all Models and Contracts.

It is using MVC design pattern, CQRS design pattern with MediatR and Repository pattern.

Unit test are written in XUnit framework.

### Prerequisites

Its using a Azure Sql Server database so the client IP should be white listed to use this database.

## Tests

It has XUnit unit tests to cover code.

