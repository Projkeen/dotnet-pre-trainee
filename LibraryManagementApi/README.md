# \# Library Management API





## \## About



Library Management API is a REST API created with ASP.NET Core for managing "authors" and "books" objects. It supports full CRUD operations for both objects and keeps the relationship one to many (One Author → Many Books). This version uses "in-memory storage". Data available during running the server.





## \## Technologies



* C#
* .NET
* ASP.NET Core Web API
* Dependency Injection
* OpenAPI / Swagger
* Postman





## \## Resources



* Author

&#x20; Has fields: Id (int, unique, generate by method), Name (string), DateOfBirth (DateTime).

* Book

&#x20; Has fields: Id (int, unique, generate by method), Title (string), PublishedYear (int), AuthorId (id, foreign key for

&#x20; one-to-many relationship, every book belongs to one author and author can not be deleted while he has books).





## \## API Endpoints



* Authors

&#x20; - Method GET: /api/authors

&#x20;   Get all author from list. Successful response: 200 OK

&#x20; - Method GET: /api/authors/{id}

&#x20;   Get author by id. Successful response: 200 OK

&#x20; - Method POST: /api/authors

&#x20;   Create author. Successful response: 201 Created

&#x20; - Method PUT: /api/authors/{id}

&#x20;   Update author by id. Successful response: 204 No Content

&#x20; - Method DELETE /api/authors/{id}

&#x20;   Delete author by id. Successful response: 204 No Content



* Books

&#x20; - Method GET: /api/books

&#x20;   Get all books from list. Successful response: 200 OK

&#x20;   Has optional parameters such as "searchByTitle" (returns books matching the entered title) and "authorId" (returns

&#x20;   books belong to author with entered id)

&#x20; - Method GET: /api/books/{id}

&#x20;   Get book by id. Successful response: 200 OK

&#x20; - Method POST: /api/books

&#x20;   Create book. Successful response: 201 Created

&#x20; - Method PUT: /api/books/{id}

&#x20;   Update book by id. Successful response: 204 No Content

&#x20; - Method DELETE /api/books/{id}

&#x20;   Delete book by id. Successful response: 204 No Content



Other responses: 400 Bad Request (invalid input), 404 Not Found (author or book does not exist), 409 Conflict (deleting an author who still has books).





## \## Validation Rules



* Author

&#x20; Name: required, cannot be empty or contain only whitespace, maximum length 50 characters.

&#x20; DateOfBirth: required, must be a valid date and must not be in the future.

* Book

&#x20; Title: required, cannot be empty or contain only whitespace, maximum length 100 characters.

&#x20; PublishedYear: must be in range (from 1 to 2222).

&#x20; AuthorId: must be greater than zero and reference an existing author. Otherwise the API returns "400 Bad Request"

&#x20; and the book is not created or updated.

&#x20; Author deletion conflict: an author who still has books cannot be deleted. The API returns "409 Conflict" with a

&#x20; message "Author with id {id} has books. Delete his books".





## \## Architecture



* Controller: handles HTTP (routes, request bodies, query parameters and status codes). Controllers stay thin and call services.
* Service: "AuthorService", "BookService" (handles application logic: searching, creating, updating, deleting and filtering). Services are injected into controllers through interfaces ("IAuthorService", "IBookService") and registered in Program.cs to container as "Scoped".
* LibraryStore: data is stored in memory and is lost when the application restarts (lists of authors and books). Registered as "Singleton" in Program.cs, so all requests work with the same data while the application is running.
* Middleware: handles request timing (logs the HTTP method, path, response status code and elapsed time). Provides by class "RequestTimingMiddleware".





## \## How to Run



1. Clone the repository:



git clone https://github.com/Projkeen/dotnet-pre-trainee.git



2\. Go to the project folder, where exist file .csproj ("\\dotnet-pre-trainee\\LibraryManagementApi\\LibraryManagementApi")



cd "dotnet-pre-trainee/LibraryManagementApi/LibraryManagementApi"



3\. Run the application:



dotnet run



4\. After building and starting program, console shows the address the application is listening on



Now listening on: https://localhost:7259

Now listening on: http://localhost:5099



5\. After number a port write "/swagger" to open the API documentation



https://localhost:7259/swagger

http://localhost:5099/swagger



You can also find "applicationUrl" in "launchSettings.json" file.



6\. Send requests by



using Swagger UI: Select endpoint, push "Try it out" then "Execute";

using Postman: import "LibraryManagementApi" to postman collections. Paste "https://localhost:7259/openapi/v1.json" or "http://localhost:5099/openapi/v1.json", then send requests.



7\. You can also run the project through visual studio, by pressing F5 (to debug) or Ctrl+F5 (to run without debugging).





### 

