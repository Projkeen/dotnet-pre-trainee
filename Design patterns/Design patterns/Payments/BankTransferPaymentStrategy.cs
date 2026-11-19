namespace Design_patterns.Payments
{
    public class BankTransferPaymentStrategy : IPaymentStrategy
    {
        public async Task<bool> PayAsync(decimal amount)
        {
            Console.WriteLine("Waiting...");
            await Task.Delay(1500);
            if(amount <= 3000)
            {
                Console.WriteLine($"Creating bank transfer for: {amount} USD");
                return true;
            }                
            Console.WriteLine("Payment must not be over 3000 USD");
            return false;
            
        }
    }
}
