using Design_patterns.Models;

namespace Design_patterns.Services
{
    public class NotificationSubscriber
    {
        public NotificationSubscriber(CheckoutService checkoutService)
        {
            checkoutService.OrderCompleted += OnOrderCompleted;
        }

        public void OnOrderCompleted(object? sender, Order order)
        {
            Console.WriteLine($"Order confirmation sent to customer: {order.CustomerName}");
        }
    }
}
