using Microsoft.VisualStudio.TestTools.UnitTesting;
using NostalgiaTrek;
using System;

namespace NostaligaTrekTests
{
    [TestClass]
    public class ShieldTests
    {
        [TestMethod]
        public void ShieldsAreRaisedByDefault()
        {
            var shield = new Shields();

            Assert.IsTrue(shield.IsUp());
        }
        
        [TestMethod]
        public void ShieldsCanBeLowered()
        {
            var shield = new Shields();
            
            shield.Lower();

            Assert.IsFalse(shield.IsUp());
        }

    }
}
