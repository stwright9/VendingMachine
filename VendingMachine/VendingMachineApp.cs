using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VendingMachineApp
    {        
        static void Main()
        {
            ConsoleKeyInfo input;
            do
            {
                Console.Clear();

                List<Item> products = new List<Item>();
                products = app.CreateVendingProducts();

                app.DisplayCurrentChange();
                app.DisplayCoins();

                input = Console.ReadKey();

                app.ProcessKeyInput(input, products);

            } while (input.Key != ConsoleKey.D0);
        }

        public void ProcessKeyInput(ConsoleKeyInfo input, List<Item> products)
        {
            if (input.Key == ConsoleKey.D1)
                changeInserted += DetermineTypeOfCoin("Quarter");
            else if (input.Key == ConsoleKey.D2)
                changeInserted += DetermineTypeOfCoin("Dime");
            else if (input.Key == ConsoleKey.D3)
                changeInserted += DetermineTypeOfCoin("Nickel");
            else if (input.Key == ConsoleKey.D4)
                changeInserted += DetermineTypeOfCoin("Penny");
            else if (input.Key == ConsoleKey.D5)
            {
                Console.Clear();
                DisplayCurrentChange();
                DisplayProducts(products);
                ProcessProductInput(products);
            }
            else if (input.Key == ConsoleKey.D6)
                ReturnCoins(changeInserted);
            else
                Console.Clear();
        }

        public void DisplayCurrentChange()
        {
            Console.WriteLine("Current Change: " + changeInserted + "\t" + "Coin Return: " + changeInCoinReturn + "\n");
        }

        public void DisplayCoins()
        {
            Console.WriteLine("INSERT COIN" + "\n");
            Console.WriteLine("Id" + "\t" + "Coin");
            Console.WriteLine("1:" + "\t" + "Quarter");
            Console.WriteLine("2:" + "\t" + "Dime");
            Console.WriteLine("3:" + "\t" + "Nickel");
            Console.WriteLine("4:" + "\t" + "Penny");
            Console.WriteLine("5:" + "\t" + "Show Products");
            Console.WriteLine("6:" + "\t" + "Return Coins");
            Console.WriteLine("0:" + "\t" + "Exit Application");
            Console.Write("\n" + "Please select an Id:");
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
                return 0;
            else
                return 0;
        }

        public double ReturnCoins(double coinsToReturn)
        {
            changeInCoinReturn += coinsToReturn;
            changeInserted = 0;
            return changeInCoinReturn;
        }

        public void DisplayProducts(List<Item> products)
        {
            Console.Write("Id" + "\t" + "Name" + "\t" + "Amount" + "\t" + "Stock" + "\n");
            foreach(Item i in products)
            {
                Console.Write(i.Id + ": " + "\t" + i.Name + "\t" + "$" + i.Price + "\t" + i.AmountInStock + "\n");                
            }
            Console.WriteLine("0:" + "\t" + "Insert Coins");
            Console.Write("\n" + "Please select an Id:");

        }

        public void ProcessProductInput(List<Item> products)
        {
            bool insufficientFunds = false;
            ConsoleKeyInfo productInput;
            VendingMachineApp productApp = new VendingMachineApp();

            do
            {
                Console.Clear();
                DisplayCurrentChange();

                if(insufficientFunds)
                    Console.WriteLine("Insufficient Funds for selected item");

                productApp.DisplayProducts(products);
                productInput = Console.ReadKey();
                
                if (products.Any(i => i.Id == ConvertInputToKey(productInput)))
                {
                    Item selectedProduct = products.Where(i => i.Id.Equals(ConvertInputToKey(productInput))).Single();
                    if (selectedProduct.Price <= changeInserted)
                        MakeChange(selectedProduct, changeInserted);
                    else
                        insufficientFunds = true;
                }

            } while (productInput.Key != ConsoleKey.D0);
        }

        //Assumes enough change is met for the select item from ProcessProductInput logic
        public double MakeChange(Item selectedProduct, double currentBalance)
        {
            currentBalance -= selectedProduct.Price;            
            changeInCoinReturn += currentBalance;
            changeInserted = currentBalance;
            return changeInCoinReturn;
        }

        //This is only for ProcessProductInput for converting the keyinput to a int Id to find the selected product
        private static int ConvertInputToKey(ConsoleKeyInfo input)
        {            
            if (char.IsDigit(input.KeyChar))
                return int.Parse(input.KeyChar.ToString());
            else
                return -1;
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

        private static VendingMachineApp app = new VendingMachineApp();
        private static double changeInserted = 0;
        private static double changeInCoinReturn = 0;
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
