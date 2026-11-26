# \# Library Management API with EF Core





## \## About



Library Management API with EF Core is a REST API created with ASP.NET Core and EF Core for managing "authors" and "books" objects. It supports full CRUD operations for both objects and keeps the relationship one to many (One Author → Many Books). This version uses a relational database for store data. Data survive after application restarts.





## \## Technologies



* C#
* ASP.NET Core Web API
* Entity Framework Core, EF Core Migrations
* LINQ
* SQL server / localDB
* EF Core Migrations
* OpenAPI / Swagger
* Postman





## \## Database Setup



1. Clone the repository:



git clone https://github.com/Projkeen/dotnet-pre-trainee.git



2\. Open folder with project "LibraryManagementAPIwithEFCore";

3\. Open .sln file in IDE;

4\. Configure of connection string stored in "appsettings.json" file;

5\. Restore packages:



Open folder in console



"\\dotnet-pre-trainee\\LibraryManagementAPIwithEFCore\\LibraryManagementAPIwithEFCore"



Eenter "dotnet restore"



6\. Apply migrations:



In Package Manager Console (Visual Studio) enter "Update-Database"



7\. Run the API:



Press Ctrl+F5 (to run without debugging) or F5 (to debug)



Open swagger to try the endpoints



https://localhost:7042/swagger/



You can also find "applicationUrl" in "launchSettings.json" file.





## \## Entity Relationship



* Author

&#x20; Has fields: Id (int, unique, generate by SQL server (or method to seeding data after apply migrations)), Name (string), DateOfBirth (DateTime), Books (ICollection<Book>).

* Book

&#x20; Has fields: Id (int, unique, generate by SQL server (or method to seeding data after apply migrations)), Title (string), PublishedYear (int), AuthorId (id, foreign key for one-to-many relationship, every book belongs to one author and author can not be deleted while he has books), Author (Author, navigation property).





## \## Migrations



A migration is a versioned description of a database schema change. EF Core creates a special table commonly known as \_\_EFMigrationsHistory. This table stores information about migrations that have already been applied. After changes in database schema, "database update" command EF Core applies the missing migrations.





## \## LINQ Examples



All queries are created as "IQueryable", filtered and sorted in database before materialization.



* Books after 2015:

var books = \_libraryContext.Books.AsNoTracking().Where(b => b.PublishedYear > 2015);

* Authors with Book counts:

IQueryable<Author> authors = \_libraryContext.Authors.AsNoTracking();

var response = authors.OrderBy(a => a.Name).Select(a => new AuthorResponse

{

&#x20;   Id = a.Id,

&#x20;   Name = a.Name,

&#x20;   DateOfBirth = a.DateOfBirth,

&#x20;   Books = a.Books,

&#x20;   BookCount = a.Books.Count()

});

* Author search:

authors = authors.Where(a=>a.Name.Contains(searchByName));

* Books filtered by Author:

books = books.Where(b => b.AuthorId == authorId.Value);

* Book search:

books = books.Where(b => b.Title.Contains(searchByTitle));





## \## Persistence



Data is now stored in the database and survive after application restarts. No "List<T>" storage anymore, the database is the single source of data.







### 

