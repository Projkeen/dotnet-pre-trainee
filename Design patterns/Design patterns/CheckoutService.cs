using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class CheckoutService
    {
        public event EventHandler<Order>? OrderCompleted;
        public async Task<bool>CheckoutAsync(Order order, IPaymentStrategy strategy)
        {
            var result = await strategy.PayAsync(order.TotalAmount);
            if(result is false)
            {
                Console.WriteLine("Payment failed, order not created");
                return false;
            }

            order.MarkCompleted();
            Console.WriteLine("Payment succeeded, order created");
            OrderCompleted?.Invoke(this, order);
            return true;
        }
    }
}
