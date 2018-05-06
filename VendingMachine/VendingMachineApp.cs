using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachineApp
    {
        static void Main()
        {

        }

        public double DetermineTypeOfCoin(string coin)
        {
            if (coin.Equals("Quarter"))
                return 0.25;
            else if (coin.Equals("Dime"))
                return 0.10;
            else if (coin.Equals("Nickel"))
                return 0.05;
            else if (coin.Equals("Penny"))
                return 0.01;
            else
                return 0;
        }

        public List<Item> CreateVendingProducts()
        {
            List<Item> products = new List<Item>();
            Item cola = new Item("cola", 1.00, 5);
            products.Add(cola);
            return products;
        }
    }

    public struct Item
    {
        public string Name;
        public double Price;
        public int AmountInStock;

        public Item(string name, double price, int amountInStock)
        {
            Name = name;
            Price = price;
            AmountInStock = amountInStock;
        }
    }
}
