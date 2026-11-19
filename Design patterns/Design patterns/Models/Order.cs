namespace Design_patterns.Models
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
        public void MarkCompleted()
        {
            IsCompleted = true;
        }
    }
}
