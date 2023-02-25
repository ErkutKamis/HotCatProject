namespace HC.Presentation.Models
{
    public class Cart
    {
        Dictionary<Guid, CartItem> _myCart = new Dictionary<Guid, CartItem>();

        public List<CartItem> myCart { get => _myCart.Values.ToList(); }

        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ProductID))
            {
                _myCart[cartItem.ProductID].Quantity += cartItem.Quantity;
                return;
            }
            _myCart.Add(cartItem.ProductID, cartItem);
        }
    }
}
