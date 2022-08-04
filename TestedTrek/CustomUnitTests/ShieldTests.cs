using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomUnitTests
{
    [TestClass]
    public class ShieldTests
    {
        [TestMethod]
        public void ShieldsAreUpByDefault()
        {
            var shield = new Shield();

            Assert.IsTrue(shield.IsUp());
        }
    }
}
