﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VendingMachineApp
    {        
        static void Main()
        {
            ConsoleKeyInfo input;

            Console.WriteLine("Do you want exact change mode? (Y/N)");
            input = Console.ReadKey();

            if (input.Key.Equals(ConsoleKey.Y))
                exactChange = true;

            List<Item> products = new List<Item>();
            products = app.CreateVendingProducts();
            do
            {
                Console.Clear();
                                
                app.DisplayCurrentChange();

                if (!exactChange)
                    app.DisplayCoins();
                else
                    app.DisplayExactChange();

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
                changeInCoinReturn += DetermineTypeOfCoin("Penny");             
            else if (input.Key == ConsoleKey.D5)
            {
                Console.Clear();
                DisplayCurrentChange();
                DisplayProducts(products);
                ProcessProductInput(products);
            }
            else if (input.Key == ConsoleKey.D6)
                ReturnCoins(changeInserted);
            else if (input.Key == ConsoleKey.D7 && exactChange)
            {
                Console.Clear();
                Console.WriteLine("Enter the amount of change you want to add to your balance:");
                changeInserted += DetermineExactChange(Console.ReadLine());
            }
                
            else
                Console.Clear();
        }

        public void DisplayCurrentChange()
        {
            if(purchasedItem)
            {
                Console.WriteLine("Current Change: " + changeInserted + "\t" + "Coin Return: " + changeInCoinReturn + "\n");
                Console.WriteLine("THANK YOU FOR YOUR PURCHASE" + "\n");
            }                
            else
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

        public void DisplayExactChange()
        {
            Console.WriteLine("EXACT CHANGE ONLY" + "\n");
            Console.WriteLine("Id" + "\t" + "Coin");            
            Console.WriteLine("5:" + "\t" + "Show Products");
            Console.WriteLine("6:" + "\t" + "Return Coins");
            Console.WriteLine("7:" + "\t" + "Enter Change");
            Console.WriteLine("0:" + "\t" + "Exit Application");
            Console.Write("\n" + "Please select an Id:");
        }

        //Invalid amounts will return 0
        public double DetermineExactChange(string amount)
        {            
            Console.WriteLine("Enter the amount of change you want to add to your balance:");
            Double.TryParse(amount, out double parsedAmount);
            if (parsedAmount < 0)
                parsedAmount = 0;
            return parsedAmount;
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

        //I am assuming your taking the change out of the coin return every time you return coins
        public double ReturnCoins(double coinsToReturn)
        {
            changeInCoinReturn = coinsToReturn;
            changeInserted = 0;
            return coinsToReturn;
        }

        public void DisplayProducts(List<Item> products)
        {
            Console.Write("Id" + "\t" + "Name" + "\t" + "Amount" + "\t" + "Stock" + "\n");
            foreach(Item i in products)
            {
                Console.Write(i.Id + ": " + "\t" + i.Name + "\t" + "$" + i.Price + "\t" + i.AmountInStock + "\n");                
            }
            if(!exactChange)
                Console.WriteLine("0:" + "\t" + "Insert Coins");
            else
                Console.WriteLine("0:" + "\t" + "Insert Exact Change");
            Console.Write("\n" + "Please select an Id:");
        }
                
        public void ProcessProductInput(List<Item> products)
        {
            ConsoleKeyInfo productInput;
            VendingMachineApp productApp = new VendingMachineApp();
            
            Console.Clear();
            DisplayCurrentChange();

            productApp.DisplayProducts(products);
            productInput = Console.ReadKey();
                
            if (products.Any(i => i.Id == ConvertInputToKey(productInput)))
            {
                Item selectedProduct = products.Where(i => i.Id.Equals(ConvertInputToKey(productInput))).Single();
                
                if (changeInserted >= selectedProduct.Price)
                    selectedProduct = UpdateItemInStock(selectedProduct);
                MakeChange(selectedProduct, changeInserted);                
            }
        }

        public Item UpdateItemInStock(Item product)
        {
            if (Int32.TryParse(product.AmountInStock, out int stock))
                if (stock == 1)
                    product.AmountInStock = "SOLD OUT";
                else
                {
                    stock = stock - 1;
                    product.AmountInStock = stock.ToString();
                    purchasedItem = true;
                }                    

            return product;
        }
        
        //I am assuming your taking the change out of the coin return every time you try to buy another item
        public double MakeChange(Item selectedProduct, double currentBalance)
        {
            if (currentBalance >= selectedProduct.Price)
                changeInCoinReturn = currentBalance - selectedProduct.Price;
            else if (changeInCoinReturn == 0)
                changeInCoinReturn = currentBalance;

            changeInserted = 0;
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
            Item cola = new Item(1, "cola", 1.00, "5");
            Item chips = new Item(2, "chips", 0.65, "3");
            Item candy = new Item(3, "candy", 0.50, "2");
            products.Add(cola);
            products.Add(chips);
            products.Add(candy);
            return products;
        }

        private static VendingMachineApp app = new VendingMachineApp();
        private static double changeInserted = 0;
        private static double changeInCoinReturn = 0;
        private static bool exactChange = false;
        private static bool purchasedItem = false;
    }

    public class Item
    {
        public int Id;
        public string Name;
        public double Price;
        public string AmountInStock;

        public Item(int id, string name, double price, string amountInStock)
        {
            Id = id;
            Name = name;
            Price = price;
            AmountInStock = amountInStock;
        }
    }
}
