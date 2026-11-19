namespace Design_patterns.Payments
{
    public class LegacyPayPalClient
    {
        public bool MakePayment(double amountInUsd)
        {
            if (amountInUsd <= 1000)   
                return true;
            return false;            
        }
    }
}
