using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }

        public Order(int id, string customerName, decimal totalAmount)
        {
            Id = id;
            CustomerName = customerName;
            TotalAmount = totalAmount;
        }
    }
}
