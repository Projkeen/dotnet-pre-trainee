using Design_patterns.Models;
using Design_patterns.Payments;
using Design_patterns.Services;

PaymentStrategyFactory paymentStrategyFactory = new PaymentStrategyFactory();
CheckoutService checkoutService = new CheckoutService();
NotificationSubscriber sub = new NotificationSubscriber(checkoutService);
checkoutService.OrderCompleted += (sub, order) => Console.WriteLine($"Audit: Order {order.Id} completed and added to audit log");
int orderId = 1;
bool askToContinue;

do
{
    try
    {
        Console.Write("Enter customer name: ");
        string name = SetCustomerName();
        Console.Write("Enter order amount: ");
        decimal totalAmount = SetAmount();
        Console.WriteLine("Select payment: \n 1. Card (Limit 1500 USD per operation) \n 2. PayPal (Limit 1000 USD per operation)" +
            " \n 3. Bank transfer (Limit 3000 USD per operation) \n 4. Crypto (Limit 500 ETH per operation)");
        int type = SetSelection();
        IPaymentStrategy strategy = paymentStrategyFactory.Select(type);
        Order order = new Order(orderId++, name, totalAmount);
        await checkoutService.CheckoutAsync(order, strategy);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

} while (askToContinue = AskToContinue());

int SetSelection()
{
    while (true)
    {
        Console.Write("Select: ");
        if (int.TryParse(Console.ReadLine(), out int number))
            return number;
        Console.Write("Unknown payment type! Select from 1 to 3: ");
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
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            return amount;
        Console.Write("Error! Enter a positive number: ");
    }
}
bool AskToContinue()
{
    while (true)
    {
        Console.Write("Do you want to repeat? (y/n): ");
        string? answer = Console.ReadLine();
        if (answer != null && answer.ToLower() == "y")
        {
            return true;
        }
        if (answer != null && answer.ToLower() == "n")
        {
            Console.WriteLine("Exit");
            return false;
        }

        Console.WriteLine("Please enter 'y' or 'n': ");
    }
}
