using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class PaymentStrategyFactory
    {
        public IPaymentStrategy Select(int type)
        {
            switch (type)
            {
                case 1:
                    return new CardPaymentStrategy();
                case 2:
                    LegacyPayPalClient legacyClient = new LegacyPayPalClient();
                    PayPalPaymentAdapter adapter = new PayPalPaymentAdapter(legacyClient);
                    return adapter;
                case 3:
                    return new BankTransferPaymentStrategy();
                default:
                    throw new ArgumentException("Unknown payment type");
            }
        }
    }
}
