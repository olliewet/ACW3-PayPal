using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypalACW3.Models
{
    public class ShoppingCart
    { 
         public List<Product> _ShoppingCartList = new List<Product>();
         public List<Product> _ShoppingCartListGuest = new List<Product>();

         


        

        public override string ToString()
        {
            List<string> cart = new List<string>();
            foreach (Product product in _ShoppingCartList)
            {
                cart.Add(product.ToString());
            }
            return string.Join('|', cart);
        }

        public List<Product> GetShoppingCart()
        {
            return _ShoppingCartListGuest;
        }

        public static List<Product> ConvertStringToProduct(string items)
        {
            if (!String.IsNullOrWhiteSpace(items))
            {
                List<Product> ListOfProducts = new List<Product>();
                if (items.Contains("|"))
                {
                    foreach (string item in items.Split('|'))
                    {
                        ListOfProducts.Add(Product.ConvertStringToCartItem(item));
                    }
                }
                else
                {
                    ListOfProducts.Add(Product.ConvertStringToCartItem(items));
                }
                return ListOfProducts;
            }
            return new List<Product>();
        }


        public bool RemoveItemFromCart(string ProductID)
        {
            Product currentCartItem = _ShoppingCartList.First(i => i.Id == ProductID);
            if (currentCartItem != null)
            {
                _ShoppingCartList.Remove(currentCartItem);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Adding a Product to the Shopping Cart List 
        /// </summary>
        /// <param name="product"></param>
        public void addProd(Product product)
        {
            try
            {
                _ShoppingCartList.Add(product);
                //Do Some Checking for Multiple Items Later 
            }
            catch
            {
                _ShoppingCartList.Add(product);
            }
        }

        public void removeProd(string productID)
        {
            try
            {
                if (_ShoppingCartList.First(i => i.Id == productID) != null)
                {
                    _ShoppingCartList.Remove(_ShoppingCartList.First(i => i.Id == productID));
                }
            }
            catch
            {
                _ShoppingCartList.Remove(_ShoppingCartList.First(i => i.Id == productID));
            }
        }

        public int GetListCount()
        {
            return _ShoppingCartList.Count;
        }

        public double ShoppingCartGetTotal()
        {
            double shoppingCartTotal = 0;
            foreach (Product product in _ShoppingCartList)
            {
                shoppingCartTotal += product.Price;
            }
            return shoppingCartTotal;
        }

        /// <summary>
        /// Returns the Product as List 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProd()
        {
            return _ShoppingCartList;
        }


     

    }
}
