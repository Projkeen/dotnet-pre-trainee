using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class CardPaymentStrategy : IPaymentStrategy
    {
        public async Task<bool> PayAsync(decimal amount)
        {            
            Console.WriteLine("Waiting...");
            await Task.Delay(1500);
            if(amount <= 1500)
            {
                Console.WriteLine($"Processing card payment: {amount} ");
                return true;
            } 
            Console.WriteLine("Payment must not be over 1500");            
            return false;
        }
    }
}
