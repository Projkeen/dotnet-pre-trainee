namespace Design_patterns.Payments
{
    public class PayPalPaymentAdapter : IPaymentStrategy
    {
        private readonly LegacyPayPalClient _legacyPayPalClient;
        public PayPalPaymentAdapter(LegacyPayPalClient client)
        {
            _legacyPayPalClient = client;
        }

        public async Task<bool> PayAsync(decimal amount)
        {
            Console.WriteLine("Waiting...");
            await Task.Delay(1500);
            bool result = _legacyPayPalClient.MakePayment((double)amount);
            if (result is false)
            {
                Console.WriteLine("Payment must not be over 1000 USD");
                return false;
            }

            Console.WriteLine($"<Legacy Library: PayPal Client>: Making payment {amount} USD");
            return true;
        }
    }
}
