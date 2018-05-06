using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void DetermineTypeOfCoinTest()
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
        public void VerifyVendingProductsTest()
        {
            List<Item> products = new List<Item>();
            products = vendingMachine.CreateVendingProducts();

            Assert.IsTrue(products.Any(i => i.Name.Equals("cola")));
            Assert.IsTrue(products.Where(i => i.Name.Equals("cola")).Single().Price.Equals(1.00));
            Assert.IsTrue(products.Where(i => i.Name.Equals("cola")).Single().AmountInStock.Equals(5));

            Assert.IsTrue(products.Any(i => i.Name.Equals("chips")));
            Assert.IsTrue(products.Where(i => i.Name.Equals("chips")).Single().Price.Equals(0.65));
            Assert.IsTrue(products.Where(i => i.Name.Equals("chips")).Single().AmountInStock.Equals(3));

            Assert.IsTrue(products.Any(i => i.Name.Equals("candy")));
            Assert.IsTrue(products.Where(i => i.Name.Equals("candy")).Single().Price.Equals(0.50));
            Assert.IsTrue(products.Where(i => i.Name.Equals("candy")).Single().AmountInStock.Equals(2));
        }

        [TestMethod]
        public void VerifyConsoleOuputDisplayProductsTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                vendingMachine.DisplayProducts();
                
                Assert.IsTrue(sw.ToString().Count() > 0);
            }
        }

        [TestMethod]
        public void VerifyConsoleOuputDisplayCoinsTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                vendingMachine.DisplayCoins();

                Assert.IsTrue(sw.ToString().Count() > 0);
            }
        }
    }
}
