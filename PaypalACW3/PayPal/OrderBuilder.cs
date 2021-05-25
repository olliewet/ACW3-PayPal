using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaypalACW3.Models;
using PayPalCheckoutSdk.Orders;

namespace PaypalACW3.PayPal
{
    public static class OrderBuilder
    {
        public static OrderRequest Build(ShoppingCart cart, double total)
        {
            if (cart == null)
            {
                return null;
            }

            

            OrderRequest orderRequest = new OrderRequest()
            {
                
                CheckoutPaymentIntent = PayPal.Values.CheckoutPaymentIntent.CAPTURE,
                ApplicationContext = new ApplicationContext
                {
                    BrandName = "University.Cafe",
                    LandingPage = PayPal.Values.LandingPage.LOGIN,
                    UserAction = PayPal.Values.UserAction.PAY_NOW,
                    ShippingPreference = PayPal.Values.ShippingPreference.NO_SHIPPING,
                    Locale = "en-GB"
                    
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        ReferenceId = "NRNJFCHJ2LVLU", // [required] The merchant ID for the purchase unit.

                        //Description = "Software published by Delaneys.space",
                        //SoftDescriptor = "Delaneys.space",
                        CustomId = "CUST-Cafe",

                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = PayPal.Values.CurrencyCode.GBP,
                            Value = total.ToString(),
                            AmountBreakdown = new AmountBreakdown
                            {
                                ItemTotal = new Money
                                {
                                    CurrencyCode = PayPal.Values.CurrencyCode.GBP, //Orginally was basket.CurrencyCode
                                    Value = total.ToString() // Orginally basket.SubTotal.ToString()
                                } 
                                /*
                            Discount = new Money
                            {
                                CurrencyCode = basket.CurrencyCode,
                                Value = basket.Discount.ToString()
                            }
                            */
                            }
                        },
                        Items = new List<Item>()
                    }
                }
            };

            foreach (var product in cart._ShoppingCartList)
            {
                orderRequest.PurchaseUnits[0]
                    .Items
                    .Add(new Item
                    {
                        Name = product.Name,
                        UnitAmount = new Money
                        {
                            CurrencyCode = PayPal.Values.CurrencyCode.GBP,
                            Value = product.Price.ToString()
                        },
                        Category = PayPal.Values.Item.Category.PHYSICAL_GOODS
                    });
            }
            //Come Back to Order Request 
            return orderRequest;
        }

    }
}
