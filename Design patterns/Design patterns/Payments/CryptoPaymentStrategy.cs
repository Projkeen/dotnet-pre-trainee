namespace Design_patterns.Payments
{
    public class CryptoPaymentStrategy : IPaymentStrategy
    {
        public async Task<bool> PayAsync(decimal amount)
        {
            Console.WriteLine("Waiting...");
            await Task.Delay(1500);
            if (amount <= 500)
            {
                Console.WriteLine($"Creating crypto transfer for: {amount} Ethereum (ETH)");
                return true;
            }
            Console.WriteLine("Payment must not be over 500 Ethereum (ETH)");
            return false;

        }
    }
}
