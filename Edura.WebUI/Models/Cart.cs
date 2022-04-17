using Edura.WebUI.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Edura.WebUI.Models
{
    public class Cart
    {
        private List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;

        public void AddProduct(Product product, int quantity)
        {
            var prd = products.Where(x => x.Product.Id == product.Id).FirstOrDefault();
            if (prd == null)
            {
                products.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                prd.Quantity += quantity;
            }
        }

        public void RemoveProduct(Product product)
        {
            products.RemoveAll(x => x.Product.Id == product.Id);
        }

        public double TotalPrice()
        {
            return products.Sum(x => x.Product.Price * x.Quantity);
        }

        public void ClearAll()
        {
            products.Clear();
        }
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}