using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachineApp
    {        
        static void Main()
        {            
            VendingMachineApp app = new VendingMachineApp();
            app.DisplayCoins();
            Console.ReadLine();
        }

        public void DisplayCoins()
        {
            Console.WriteLine("INSERT COIN" + "\n");
            Console.WriteLine("Id" + "\t" + "Coin");
            Console.WriteLine("1:" + "\t" + "Quarter");
            Console.WriteLine("2:" + "\t" + "Dime");
            Console.WriteLine("3:" + "\t" + "Nickel");
            Console.WriteLine("4:" + "\t" + "Penny");
            Console.Write("\n" + "Please select a coin Id:");
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

        public void DisplayProducts()
        {
            List<Item> products = new List<Item>();
            products = CreateVendingProducts();           

            Console.Write("\t" + "Name" + "\t" + "Amount" + "\t" + "Stock" + "\n");
            foreach(Item i in products)
            {
                Console.Write(i.Id + ": " + "\t" + i.Name + "\t" + "$" + i.Price + "\t" + i.AmountInStock + "\n");                
            }
        }

        public List<Item> CreateVendingProducts()
        {
            List<Item> products = new List<Item>();
            Item cola = new Item(1, "cola", 1.00, 5);
            Item chips = new Item(2, "chips", 0.65, 3);
            Item candy = new Item(3, "candy", 0.50, 2);
            products.Add(cola);
            products.Add(chips);
            products.Add(candy);
            return products;
        }
        
        public double changeInserted { get => changeInserted; set => changeInserted = value; }
    }

    public struct Item
    {
        public int Id;
        public string Name;
        public double Price;
        public int AmountInStock;

        public Item(int id, string name, double price, int amountInStock)
        {
            Id = id;
            Name = name;
            Price = price;
            AmountInStock = amountInStock;
        }
    }
}
