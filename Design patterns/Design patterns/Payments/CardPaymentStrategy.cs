namespace Design_patterns.Payments
{
    public class CardPaymentStrategy : IPaymentStrategy
    {
        public async Task<bool> PayAsync(decimal amount)
        {            
            Console.WriteLine("Waiting...");
            await Task.Delay(1500);
            if(amount <= 1500)
            {
                Console.WriteLine($"Processing card payment: {amount} USD");
                return true;
            } 
            Console.WriteLine("Payment must not be over 1500 USD");            
            return false;
        }
    }
}
