# ToDoApi

This project is a ToDo API developed in C# using the Domain-Driven Design (DDD) architecture. 
The objective is to make an simple Todo Api but using more complex architecture to represent a more enterprise api. 

## Project Structure

The solution is divided into the following projects:

    1.  Api: This project contains the API controllers and related classes responsible for handling HTTP requests and responses. It serves as the entry point for the ToDoApi.

    2.  Application: This project houses the application layer, which contains the application services and business logic. It acts as the intermediary between the API and the domain layer, orchestrating the flow of data and operations.

    3.  Domain: The domain layer is where the core business logic and domain models reside. It encapsulates the business rules and entities related to the ToDo domain. This layer focuses on modeling the problem domain and does not depend on any other layer.

    4.  Infrastructure: The infrastructure layer provides implementations for data persistence, external services, and other infrastructure-related concerns. In this project, Entity Framework is utilized to interact with the underlying database for storing and retrieving ToDo items.

    5. Tests: The tests project contains all tests using xUnit.

## Dependencies

The following dependencies are used in the project:

- Entity Framework Core: Used for object-relational mapping and interacting with the database.
- ASP.NET Core: Provides the framework for building the API and handling HTTP requests.
- Newtonsoft.Json: Used for JSON serialization and deserialization.
- Microsoft.Extensions.DependencyInjection: Used for dependency injection and managing dependencies between components.
- Mapster: For map responses.
- FluentValidations: For request validations.

## Getting Started

To get started with the ToDoApi project, follow these steps:

    1.  Clone the repository: `git clone https://github.com/your-username/ToDoApi.git`

    2.  Open the solution file (`ToDoApi.sln`) in your preferred IDE.

    3.  Make sure you have the necessary dependencies installed. You can use NuGet Package Manager to restore the packages if they are not automatically restored.

    4.  Configure the database connection in the `appsettings.json` file under the `Infrastructure` project. Update the connection string according to your database settings.

    5.  Build the solution to ensure that there are no build errors.

    6.  Run the migrations to create the database schema. Open the Package Manager Console, select the `Infrastructure` project, and run the following command: `Update-Database`.

    7.  Set the API project (ToDoApi) as the startup project and run the application.

    8.  The API should now be running on `http://localhost:5000`. You can use tools like Postman or curl to interact with the API endpoints.

## API Endpoints

The ToDoApi provides the following endpoints for managing ToDo items:

Todo
- POST /api/todo: Creates a new ToDo item.
- PUT /api/todo: Updates an existing ToDo item.
- DELETE /api/todo/{id}: Deletes a ToDo item.

TodoList
- POST /api/todo-list: Creates a new ToDoList item.
- PUT /api/todo-list: Updates an existing ToDoList item.
- DELETE /api/todo-list/{id}: Deletes a ToDoList item with all associated Todos. 
- GET /api/todo-list: Get all ToDolists and Todos associated.
- GET /api/todo-list/{id}: Get ToDolist by Id and Todos associated.
- GET /api/todo-list/paginated: Get all ToDolists and Todos associated with pagination.


For detailed information on request and response formats, please refer to the API documentation or explore the API using a tool like Swagger.

