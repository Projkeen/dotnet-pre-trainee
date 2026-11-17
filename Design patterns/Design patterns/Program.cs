// See https://aka.ms/new-console-template for more information
using Design_patterns;

Console.WriteLine("Hello, World!");

CardPaymentStrategy cardStrategy = new CardPaymentStrategy();
BankTransferPaymentStrategy bankStrategy = new BankTransferPaymentStrategy();
LegacyPayPalClient legacyPayPalClient = new LegacyPayPalClient();
PayPalPaymentAdapter payPalPaymentAdapter = new PayPalPaymentAdapter(legacyPayPalClient);
PaymentStrategyFactory paymentStrategyFactory = new PaymentStrategyFactory();

await cardStrategy.PayAsync(150.00m);
await bankStrategy.PayAsync(125.00m);
legacyPayPalClient.MakePayment(100);
await payPalPaymentAdapter.PayAsync(150);


Console.WriteLine("Select payment: 1. Card, 2. PayPal, 3. Bank transfer");
int type = SetNumber();

IPaymentStrategy strategy = paymentStrategyFactory.Select(type);
await strategy.PayAsync(255.15m);


int SetNumber()
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            return number;
        }
        else
        {
            Console.Write("Error! Enter an integer!: ");
        }
    }
}