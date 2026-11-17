// See https://aka.ms/new-console-template for more information
using Design_patterns;

Console.WriteLine("Hello, World!");

CardPaymentStrategy strategy = new CardPaymentStrategy();
await strategy.PayAsync(150.00m);
