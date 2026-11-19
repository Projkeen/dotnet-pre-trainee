namespace Design_patterns.Payments
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
                case 4:
                    return new CryptoPaymentStrategy();
                default:
                    throw new ArgumentException("Unknown payment type, select from 1 to 4");
            }
        }
    }
}
