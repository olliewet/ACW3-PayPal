using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypalACW3.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return string.Format("ProductID={0}, Name={1}, Price={2}, Image={3}", Id, Name, Price, Image);
        }

        public static Product ConvertStringToCartItem(string item)
        {
            string[] itemSplit = item.Split(',');

            Product cItem = new Product
            {
                Id = itemSplit[0].Split('=')[1],
                Name = itemSplit[1].Split('=')[1],
                Price = Convert.ToDouble(itemSplit[2].Split('=')[1]),
                Image = itemSplit[3].Split('=')[1]
            };
            return cItem;
        }
    }

}
