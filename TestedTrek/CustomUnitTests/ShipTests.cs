using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NostalgiaTrek;

namespace CustomUnitTests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void IsResting()
        {
            Assert.IsTrue(Ship.IsResting());
        }
    }
}
