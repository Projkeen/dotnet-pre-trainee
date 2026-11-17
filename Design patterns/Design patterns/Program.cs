// See https://aka.ms/new-console-template for more information
using Design_patterns;

Console.WriteLine("Hello, World!");

CardPaymentStrategy cardStrategy = new CardPaymentStrategy();
BankTransferPaymentStrategy bankStrategy = new BankTransferPaymentStrategy();
LegacyPayPalClient legacyPayPalClient = new LegacyPayPalClient();
PayPalPaymentAdapter payPalPaymentAdapter = new PayPalPaymentAdapter(legacyPayPalClient);

await cardStrategy.PayAsync(150.00m);
await bankStrategy.PayAsync(125.00m);
legacyPayPalClient.MakePayment(100);
await payPalPaymentAdapter.PayAsync(150);
