using Microsoft.VisualStudio.TestTools.UnitTesting;
using NostalgiaTrek;
using System;

namespace NostaligaTrekTests
{
    [TestClass]
    public class ShipTests
    {
        private Ship ship;

        [TestInitialize]
        public void InitShipTests()
        {
            ship = new Ship();
        }

        [TestMethod]
        public void ShipHasShield()
        {
            Assert.IsNotNull(ship.ShieldSystem);
        }

        [TestMethod]
        public void EnemyDamagesShipWhileShieldIsRaised()
        {
            ship.ShieldSystem.Raise();
            ship.TakeDamage(1000);
            Assert.AreEqual(7000,ship.ShieldSystem.EnergyLevel);
        }

    }
}
