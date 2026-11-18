using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class NotificationSubscriber
    {
        public NotificationSubscriber(CheckoutService checkoutService)
        {
            checkoutService.OrderCompleted += OnOrderCompleted;
        }

        public void OnOrderCompleted(object? sender, Order order)
        {
            Console.WriteLine($"Confirmation to: {order.CustomerName}");
        }
    }
}
