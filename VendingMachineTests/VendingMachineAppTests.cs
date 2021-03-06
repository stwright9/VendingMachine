﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VendingMachineAppTests
    {
        VendingMachineApp vendingMachine = new VendingMachineApp();

        [TestMethod]
        public void TypeOfCoinTest()
        {
            Assert.AreEqual(0.25, vendingMachine.DetermineTypeOfCoin("Quarter"));
            Assert.AreEqual(0.10, vendingMachine.DetermineTypeOfCoin("Dime"));
            Assert.AreEqual(0.05, vendingMachine.DetermineTypeOfCoin("Nickel"));
            Assert.AreEqual(0.01, vendingMachine.DetermineTypeOfCoin("Penny"));
        }

        [TestMethod]
        public void CreateVendingProductsTest()
        {
            Assert.IsTrue(vendingMachine.CreateVendingProducts().Count > 0);
        }

        [TestMethod]
        public void VendingProductsTest()
        {
            List<Item> products = new List<Item>();
            products = vendingMachine.CreateVendingProducts();

            Assert.IsTrue(products.Any(i => i.Name.Equals("cola")));
            Assert.IsTrue(products.Where(i => i.Name.Equals("cola")).Single().Price.Equals(1.00));
            Assert.IsTrue(products.Where(i => i.Name.Equals("cola")).Single().AmountInStock.Equals("5"));

            Assert.IsTrue(products.Any(i => i.Name.Equals("chips")));
            Assert.IsTrue(products.Where(i => i.Name.Equals("chips")).Single().Price.Equals(0.65));
            Assert.IsTrue(products.Where(i => i.Name.Equals("chips")).Single().AmountInStock.Equals("3"));

            Assert.IsTrue(products.Any(i => i.Name.Equals("candy")));
            Assert.IsTrue(products.Where(i => i.Name.Equals("candy")).Single().Price.Equals(0.50));
            Assert.IsTrue(products.Where(i => i.Name.Equals("candy")).Single().AmountInStock.Equals("2"));
        }

        [TestMethod]
        public void ConsoleOuputDisplayProductsTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                vendingMachine.DisplayProducts(vendingMachine.CreateVendingProducts());
                
                Assert.IsTrue(sw.ToString().Count() > 0);
            }
        }

        [TestMethod]
        public void ConsoleOuputDisplayCoinsTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                vendingMachine.DisplayCoins();

                Assert.IsTrue(sw.ToString().Count() > 0);
            }
        }

        [TestMethod]
        public void ConsoleOuputDisplayCurrentChangeTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                vendingMachine.DisplayCurrentChange();

                Assert.IsTrue(sw.ToString().Count() > 0);
            }
        }

        [TestMethod]
        public void MakeChangeTest()
        {
            Item item = new Item(1, "test", 1.20, "5");
            double currentBalance = 4.00;

            Assert.AreEqual(2.80, vendingMachine.MakeChange(item, currentBalance)); 
        }

        [TestMethod]
        public void ReturnCoinsTest()
        {
            Assert.AreEqual(2, vendingMachine.ReturnCoins(2));
        }

        [TestMethod]
        public void UpdateItemInStockTest()
        {
            Item item = new Item(1, "test", 1.20, "5");
            Item item2 = new Item(1, "test", 1.20, "4");

            item = vendingMachine.UpdateItemInStock(item);

            Assert.AreEqual(item2.AmountInStock, item.AmountInStock);
        }

        [TestMethod]
        public void DetermineExactChangeTest()
        {
            Assert.AreEqual(4.00, vendingMachine.DetermineExactChange("4.00"));
            Assert.AreEqual(0, vendingMachine.DetermineExactChange("asdf4.00terwer"));
            Assert.AreEqual(0, vendingMachine.DetermineExactChange("-1"));
        }

        
    }
}
