using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaypalACW3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace PaypalACW3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public HomeController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public ShoppingCart _SC = new ShoppingCart();
        
        private static readonly List<Product> ItemList = new List<Product>{
            new Product() { Id = "1" , Name = "Plain Cheese Burger", Price = 5, Image = "Assets/BurgerPlain.jpg"},
            new Product() { Id = "2" , Name = "Coffee", Price = 1, Image = "Assets/Coffee.jpg"},
            new Product() { Id = "3" , Name = "Cup Cakes", Price = 1.50, Image = "Assets/CupCakes.jpg"}
        };


        public IActionResult Index()
        {
            return View(ItemList);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> AddToCart(string id, string name, double price, string image)
        {
            Product prod = new Product()
            {
                Id = id,
                Name = name,
                Price = price,
                Image = image
                
            };
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ShoppingCart cart = user.GetShoppingCart(); 
            cart.addProd(prod);
            user.SetShoppingCart(cart);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Invoice(string orderId, string name, string totalprice)
        {
            if (orderId == " ")
            {
                orderId = "Payed In Cash";
            }
            Models.Invoice inv = new Invoice()
            {
                PayPalOrderID = orderId,
                Name = name,
                invoiceNumber = GetUniqueKeyOriginal_BIASED(32),
                amountPayed = totalprice
            };
            return View(inv);
        }

        
        public static string GetUniqueKeyOriginal_BIASED(int size)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        [Authorize]
        public async Task<IActionResult> RemoveAllFromCart()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            user._ShoppingCart = "";
            await _userManager.UpdateAsync(user);
            return RedirectToAction("ShoppingCart");
        }


        [Authorize]
        public async Task<IActionResult> RemoveItemFromCart(string productID)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ShoppingCart cart = user.GetShoppingCart();
            cart.removeProd(productID);
            user.SetShoppingCart(cart);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("ShoppingCart");
        }


        public async Task<ShoppingCart> GetShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            cart = user.GetShoppingCart();
            await _userManager.UpdateAsync(user);
            return cart;
        }

        public async Task<double> GetShoppingCartTotal()
        {
            
            var user = await _userManager.GetUserAsync(HttpContext.User);
            double cartTotal = user.ShoppingCartGetTotal();
            await _userManager.UpdateAsync(user);
            return cartTotal;
        }

        [Authorize]
        public async Task<IActionResult> ShoppingCart()
        {
            //Shopping Cart Related Stuff this Does Work 
            ShoppingCart cart;
            cart = await GetShoppingCart();


            //Paypal Stuff not sure 
            ViewBag.ClientId = PayPal.PayPalClient.SandboxClientId;
            ViewBag.CurrencyCode = "GBP"; // Get from a data store
            ViewBag.CurrencySign = "£";   // Get from a data store
            

            return View(cart);
        }


        //################# Paypal Related Stuff ###############//

        /// <summary>
        /// This action is called when the user clicks on the PayPal button.
        /// </summary>
        /// <returns></returns>
        [Route("api/paypal/checkout/order/create")]
        public async Task<PayPal.SmartButtonHttpResponse> Create()
        {
            ShoppingCart cart;
            cart = await GetShoppingCart();
            var request = new PayPalCheckoutSdk.Orders.OrdersCreateRequest();

            request.Prefer("return=representation");
            request.RequestBody(PayPal.OrderBuilder.Build(cart, await GetShoppingCartTotal()));

            //
            // Call PayPal to set up a transaction
            var response = await PayPal.PayPalClient.Client().Execute(request);
           


            // Create a response, with an order id.
            var result = response.Result<PayPalCheckoutSdk.Orders.Order>();
            var payPalHttpResponse = new PayPal.SmartButtonHttpResponse(response)
            {
                orderID = result.Id
            };
            return payPalHttpResponse;
        }


        /// <summary>
        /// This action is called once the PayPal transaction is approved
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("api/paypal/checkout/order/approved/{orderId}")]
        public IActionResult Approved(string orderId)
        {
            return Ok();
        }

        /// <summary>
        /// This action is called once the PayPal transaction is complete
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("api/paypal/checkout/order/complete/{orderId}")]
        public IActionResult Complete(string orderId)
        {
            // 1. Update the database.
            // 2. Complete the order process. Create and send invoices etc.
            // 3. Complete the shipping process.
            return Ok();
        }

        /// <summary>
        /// This action is called once the PayPal transaction is complete
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("api/paypal/checkout/order/cancel/{orderId}")]
        public IActionResult Cancel(string orderId)
        {
            // 1. Remove the orderId from the database.
            return Ok();
        }

        /// <summary>
        /// This action is called once the PayPal transaction is complete
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("api/paypal/checkout/order/error/{orderId}/{error}")]
        public IActionResult Error(string orderId,
            string error)
        {
            // Log the error.
            // Notify the user.
            return NoContent();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
