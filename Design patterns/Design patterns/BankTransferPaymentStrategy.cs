using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class BankTransferPaymentStrategy : IPaymentStrategy
    {
        public async Task<bool> PayAsync(decimal amount)
        {
            Console.WriteLine("Waiting...");
            await Task.Delay(1500);
            Console.WriteLine($"Creating bank transfer for: {amount}");
            return true;
        }
    }
}
