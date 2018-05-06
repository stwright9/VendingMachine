using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VendingMachineAppTests
    {
        
        [TestMethod]
        public void DetermineTypeOfCoinTest()
        {            
            VendingMachineApp vendingMachine = new VendingMachineApp();
            
            Assert.AreEqual(0.25, vendingMachine.DetermineTypeOfCoin("Quarter"));
            Assert.AreEqual(0.10, vendingMachine.DetermineTypeOfCoin("Dime"));
            Assert.AreEqual(0.05, vendingMachine.DetermineTypeOfCoin("Nickel"));
            Assert.AreEqual(0.01, vendingMachine.DetermineTypeOfCoin("Penny"));
        }
    }
}
