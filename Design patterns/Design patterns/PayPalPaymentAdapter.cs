using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
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
            _legacyPayPalClient.MakePayment((double)amount);
            return true;
        }
    }
}
