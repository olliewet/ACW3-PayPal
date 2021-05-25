using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypalACW3.Models
{
    public class Invoice
    {
        public string Name { get; set; }
        public string PayPalOrderID { get; set; }
        public string PayerID { get; set; }
        public string invoiceNumber { get; set; }
        public string amountPayed { get; set; }
    }
}
