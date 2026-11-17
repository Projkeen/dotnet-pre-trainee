using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class LegacyPayPalClient
    {
        public void MakePayment(double amountInUsd)
        {
            Console.WriteLine($"<Legacy Library: PayPal Client>: Making payment {amountInUsd} USD");
        }
    }
}
