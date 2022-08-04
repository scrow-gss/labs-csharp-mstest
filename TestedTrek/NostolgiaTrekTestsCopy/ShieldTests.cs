using Microsoft.VisualStudio.TestTools.UnitTesting;
using NostalgiaTrek;
using System;

namespace NostaligaTrekTests
{
    [TestClass]
    public class ShieldTests
    {
        [TestMethod]
        public void ShieldsAreUpByDefault()
        {
            var shield = new Shields();

            Assert.IsTrue(shield.IsUp());
        }
    }
}
