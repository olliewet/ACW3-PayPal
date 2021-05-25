using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PaypalACW3.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string _ShoppingCart { get; set; }

        public ShoppingCart GetShoppingCart()
        {
            
            ShoppingCart cart = new ShoppingCart()
            {
                _ShoppingCartList = ShoppingCart.ConvertStringToProduct(_ShoppingCart)
            };
            return cart;
        }

        public void SetShoppingCart(ShoppingCart cart)
        {
            _ShoppingCart = cart.ToString();
        }

        public int GetShoppingCartCount()
        {
            ShoppingCart cart = new ShoppingCart()
            {
                _ShoppingCartList = ShoppingCart.ConvertStringToProduct(_ShoppingCart)
            };
            return cart.GetListCount();
        }

        public double ShoppingCartGetTotal()
        {
            ShoppingCart cart = new ShoppingCart()
            {
                _ShoppingCartList = ShoppingCart.ConvertStringToProduct(_ShoppingCart)
            };
            return cart.ShoppingCartGetTotal();
        }


    }
}
