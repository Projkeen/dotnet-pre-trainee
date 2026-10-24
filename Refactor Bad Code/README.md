# Refactor Bad Code

## About

Object-oriented console application on C# language. Demonstrate the main Clean Code Principles such as:

* SOLID
* DRY
* KIS
* YAGNI

## Problems Found

1. Problem: class UserService did validation, stored, calculated the discount, and sent notifications.

Principle: SRP.

Solution: Create class for validation (UserValidation). Keep users in class UserRepository. Create class NotificationSender, class Logging for implement ILogging.


2. Problem: Email validation was duplicated in multiple methods.

Principle: DRY.

Solution: Moved email validation into a reusable validator, created methods CheckRegisterValidation() and CheckEmailValidation() in UserValidation class.


3. Problem: RegisterUser method was long and has a Business rule.

Principle: KISS.

Solution: Created method for Business rule.


4. Problem: For a new notification type, you need to edit the registration method.

Principle: OCP.

Solution: Created interface INotificationSender with a separate implementation for each type of notification. The service finds the sender by type.


5. Problem: UserService depends on List<User> so the way data is stored cannot be replaced.

Principle: DIP.

Solution: Dependencies are entered through the constructor as abstractions (IUserRepository, INotificationSender, ILogging).


6. Problem: Method GenerateAdvancedAnalyticsReport() added "for the future".

Principle: YAGNI.

Solution: Method has been removed. If there is a real need, it will be added in another class.


## How to Run

1. Clone the repository:

git clone https://github.com/Projkeen/dotnet-pre-trainee.git

2. Go to the project folder, where exist file .csproj:

cd dotnet-pre-trainee/Refactor Bad Code/Refactor Bad Code

3. Run the application:

dotnet run









