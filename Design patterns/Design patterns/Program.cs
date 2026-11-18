using Design_patterns;

//CardPaymentStrategy cardStrategy = new CardPaymentStrategy();
//BankTransferPaymentStrategy bankStrategy = new BankTransferPaymentStrategy();
//LegacyPayPalClient legacyPayPalClient = new LegacyPayPalClient();
//PayPalPaymentAdapter payPalPaymentAdapter = new PayPalPaymentAdapter(legacyPayPalClient);
PaymentStrategyFactory paymentStrategyFactory = new PaymentStrategyFactory();
CheckoutService checkoutService = new CheckoutService();
NotificationSubscriber sub = new NotificationSubscriber(checkoutService);
checkoutService.OrderCompleted += (sub, order) => Console.WriteLine($"Audit: Order {order.Id} completed and added to audit log");
int orderId = 1;
//await cardStrategy.PayAsync(150.00m);
//await bankStrategy.PayAsync(125.00m);
//legacyPayPalClient.MakePayment(100);
//await payPalPaymentAdapter.PayAsync(150);


//Console.WriteLine("Select payment: 1. Card, 2. PayPal, 3. Bank transfer");
//int type = SetNumber();

//IPaymentStrategy strategy = paymentStrategyFactory.Select(type);
//await strategy.PayAsync(255.15m);
//Console.WriteLine("Enter customer: ");
//string name = SetCustomerName();
//Console.WriteLine("Enter order amount: ");
//decimal totalAmount = SetAmount();
//Order order = new Order(orderId, name, totalAmount);


while (true)
{
    Console.Write("Enter customer name: ");
    string name = SetCustomerName();
    Console.Write("Enter order amount: ");
    decimal totalAmount = SetAmount();    
    Console.WriteLine("Select payment: \n 1. Card, \n 2. PayPal, \n 3. Bank transfer");
    int type = SetSelection();
    IPaymentStrategy strategy = paymentStrategyFactory.Select(type);
    Order order = new Order(orderId++, name, totalAmount);
    await checkoutService.CheckoutAsync(order, strategy);
}

int SetSelection()
{
    while (true)
    {
        Console.Write("Select: ");
        if (int.TryParse(Console.ReadLine(), out int number)  && number >= 1 && number <= 3)
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
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            return amount;
        Console.Write("Error! Enter a number: ");
    }
}
