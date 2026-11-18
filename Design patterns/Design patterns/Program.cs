// See https://aka.ms/new-console-template for more information
using Design_patterns;

Console.WriteLine("Hello, World!");

CardPaymentStrategy cardStrategy = new CardPaymentStrategy();
BankTransferPaymentStrategy bankStrategy = new BankTransferPaymentStrategy();
LegacyPayPalClient legacyPayPalClient = new LegacyPayPalClient();
PayPalPaymentAdapter payPalPaymentAdapter = new PayPalPaymentAdapter(legacyPayPalClient);
PaymentStrategyFactory paymentStrategyFactory = new PaymentStrategyFactory();
CheckoutService checkoutService = new CheckoutService();

NotificationSubscriber sub = new NotificationSubscriber(checkoutService);


await cardStrategy.PayAsync(150.00m);
await bankStrategy.PayAsync(125.00m);
legacyPayPalClient.MakePayment(100);
await payPalPaymentAdapter.PayAsync(150);


Console.WriteLine("Select payment: 1. Card, 2. PayPal, 3. Bank transfer");
int type = SetNumber();
int orderId = 1;
IPaymentStrategy strategy = paymentStrategyFactory.Select(type);
await strategy.PayAsync(255.15m);
Console.WriteLine("Enter customer: ");
string name = SetCustomerName();
Console.WriteLine("Enter order amount: ");
decimal totalAmount = SetAmount();
Order order = new Order(orderId, name, totalAmount);
checkoutService.OrderCompleted += (sub, order) => Console.WriteLine($"Audit: Order {order.Id} completed and added to audit log");
await checkoutService.CheckoutAsync(order, strategy);




int SetNumber()
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int number))
            return number;
        Console.Write("Error! Enter an integer!: ");
    }
}

string SetCustomerName()
{
    while (true)
    {
        string? name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            return name;
        Console.WriteLine("Name can not be empty");
    }
}
decimal SetAmount()
{
    while (true)
    {
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            return amount;
        Console.WriteLine("Error! Enter a number");
    }
}