using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
