# \# Design patterns





## \## About



Console application for processes customers orders. User enters customer name, order amount and choose the payment method (Card, PayPal, Bank, Crypto). The application tries the payment. If it succeeds, the order is marked as completed (IsCompleted = true) and an "OrderCompleted" event is executed, and subscribers (customer notification, audit log) can see that. If the payment fails, the order stays incomplete and no event is executed.





## \## Patterns used



* Factory
Class "PaymentStrategyFactory".
Problem solved: which implementation should be used after selection payment type. It only creates objects, without calculation, notifications, and console logic.
What would be worse without it: the classes "Program.cs" or "CheckoutService" would contain the construction logic, including logic how the PayPal adapter and the legacy client are worked.



* Strategy

&#x20; Interface "IPaymentStrategy" with classes "BankTransferPaymentStrategy", "CardPaymentStrategy", "CryptoPaymentStrategy" and

&#x20; "PayPalPaymentAdapter".

&#x20; Problem solved: what payment method should be used. Every payment method has its own behavior with the same
  "PayAsync(decimal amount)" method.

&#x20; What would be worse without it: payment algorithms would likely return to one growing conditional method.



* Adapter

&#x20; Classes "PayPalPaymentAdapter", "LegacyPayPalClient" and interface "IPaymentStrategy"

&#x20; Problem solved: the external api client "LegacyPayPalClient" has the method "MakePayment(double amountInUsd)". The 

&#x20; "PayPalPaymentAdapter" converts "decimal" to "double" and implement "PayAsync(decimal amount)" method from

&#x20; "IPaymentStrategy" interface.

&#x20; What would be worse without it: external PayPal details would leak into application code.



* Observer

&#x20; Classes: "CheckoutService" with "OrderCompleted" event, "NotificationSubscriber".

&#x20; Problem solved: several objects can react to changes. The event is used only after the payment is succeeded and the order

&#x20; was marked as completed, so it always shows a fact that already happened.

&#x20; What would be worse without it: Checkout would need direct knowledge of every post-checkout reaction.



* Singleton Decision

&#x20; Singleton is useful when there should logically be one shared instance of something. But Singleton can also introduce hidden

&#x20; dependencies, shared mutable state, and testing problems. Object of "CheckotService" class is created once in "Program"

&#x20; class and used by objects where it's need. Constructor injection makes the dependency visible but Singleton would hide it.

&#x20; This makes the code harder to understand and test. An external component, such as a dependency injection container, decides

&#x20; to create one instance and reuse it. The service itself can remain a normal class. This often gives you more flexibility.

&#x20; 



## \## Application Flow



* Create order: Enter customer name, enter order amount.
* Select payment method: 1. Card, 2. PayPal, 3. Bank, 4. Crypto.
* Completion: if payment successful -> order becomes completed, event is execute and subscribers was reacted (notification, audit log); if payment failed -> order was not completed, event not executed.





## \## How to Run



1. Clone the repository:



git clone https://github.com/Projkeen/dotnet-pre-trainee.git



2\. Go to the project folder, where exist file .csproj:



cd "dotnet-pre-trainee/Design patterns/Design patterns"



4\. Run the application:



dotnet run











### 

