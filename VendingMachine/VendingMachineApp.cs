using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachineApp
    {        
        static void Main()
        {
            VendingMachineApp app = new VendingMachineApp();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                app.DisplayProducts();

                if(sw.ToString().Count() > 0);
            }

            ////VendingMachineApp app = new VendingMachineApp();
            //app.DisplayProducts();
            //Console.ReadLine();


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
