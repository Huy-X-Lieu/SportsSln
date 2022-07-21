namespace SportsStore.Models
{
    /// <summary>
    /// This class represent a shopping cart
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// List of product and their quantities in the shopping cart
        /// </summary>
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        /// <summary>
        /// Add a specific amount of a product into the shopping cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if(line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Remove a product from shopping cart
        /// </summary>
        /// <param name="product"></param>
        public void RemoveLine(Product product)
        {
            Lines.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        /// <summary>
        /// Calculate the total price of all items in the shopping cart
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue() =>
            Lines.Sum(p => p.Product.Price * p.Quantity);

        /// <summary>
        /// Clear/Remove all items from the shopping cart
        /// </summary>
        public void Clear() => Lines.Clear();
    }

    /// <summary>
    /// This class represent a selected product by the user and its quantity in the shopping cart
    /// </summary>
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
