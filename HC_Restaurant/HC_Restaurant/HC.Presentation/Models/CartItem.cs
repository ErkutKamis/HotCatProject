namespace HC.Presentation.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1; //When you add a product to the cart, the number must be at least 1.
        }
        public Guid ProductID { get; set; }
        public Guid EmployeeID { get; set; }
        public string AppUserID { get; set; }
        public int TableID { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? SubTotal { get => Price * Quantity; }
    }
}
