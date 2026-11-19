namespace Design_patterns.Payments
{
    public interface IPaymentStrategy
    {
        Task<bool> PayAsync(decimal amount);
    }
}
