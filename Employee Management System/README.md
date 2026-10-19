# \#Employee Management System Project



## \## About



Object-oriented console application on C# language. Demonstrate the main OOP concepts such as:

* classes and objects;
* encapsulation;
* inheritance;
* polymorphism;
* abstraction;
* interfaces;
* events and lambda expressions.



## \## Features



* Show information about employees
* Make all employees work
* Change employees salary (with validation)
* Notification when a salary changes
* Generate reports by classes which implement interface IReportable



Implemented Employee Types:

* All employees have Id, Name and Salary property, which inherit from the abstract base class "Employee"
* All employees have an additional property (for Developer - ProgrammingLanguage, for Designer - DesignTool, for Manager - TeamSize).
* All employees have implement their own behavior.



## \## OOP Concepts Used



Encapsulation:

There is no way to change the value directly because Fields Salary and Name have private setters.

The Salary field can only be changed by method SetSalary(decimal salary) where checking negative values.



Inheritance:

Developer, Manager and Designer classes inherit from Employee class and reuse property Id, Name, Salary, constructor and method for salary change.



Polymorphism:

MakeAllEmployeesWork() method call abstract method Work() on every employee in one foreach loop.

PrintInfo() method is virtual in Employee class. And other classes is override it with their own details.



Abstraction:

Abstract class Employee can not create your own object.

Abstract class Employee declare an abstract method Work(), which implemented in every employee type.



Interfaces:

Interface IReportable declares the GenerateReport() method.

Developer and Manager classes are implement it (with their own properties).



Events:

Employee declares the event EventHandler? SalaryChanged.

The event is working only after a successful salary change.



Lambda Expressions:

Method public void SubToSalaryChanging(Employee employee) with a lambda expression to print message.

Search employee by Id uses a lambda \_employees.FirstOrDefault(x => x.GetId() == id).



## \## How to Run



1. Clone the repository:



git clone https://github.com/Projkeen/dotnet-pre-trainee.git



2. Go to the project folder, where exist file .csproj:



cd dotnet-pre-trainee/Employee Management System/Employee Management System



3. Run the application:



dotnet run











### 

