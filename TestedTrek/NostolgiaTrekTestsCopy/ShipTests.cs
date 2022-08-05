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
        public void ShipHasEnergy()
        {
            Assert.AreEqual(20000, ship.EnergyLevel);
        }

        [TestMethod]
        public void ShipTransfersEnergyToShield()
        {
            ship.TranserEnergyToShield(2000);
            Assert.AreEqual(Ship.STARTINGENERGY -2000, ship.EnergyLevel);
            Assert.AreEqual(Shields.STARTINGENERGY +2000, ship.ShieldSystem.EnergyLevel);
        }
        [TestMethod]
        public void TransferMoreThanShieldCanHOld()
        {
            ship.TranserEnergyToShield(Shields.MAXENERGY +1);

            Assert.AreEqual(Ship.STARTINGENERGY - (Shields.MAXENERGY - Shields.STARTINGENERGY), ship.EnergyLevel);
            Assert.AreEqual(Shields.MAXENERGY, ship.ShieldSystem.EnergyLevel);
            
        }

        [TestMethod]
        public void TransferToShieldMoreEnergyThanShipHasWhileAt0()
        {
            ship.EnergyLevel = Ship.MINIMUMENERGY;
            ship.TranserEnergyToShield(Ship.MINIMUMENERGY +1);
            Assert.AreEqual(Ship.MINIMUMENERGY, ship.EnergyLevel);
            Assert.AreEqual(Shields.STARTINGENERGY, ship.ShieldSystem.EnergyLevel);

        }

        [TestMethod]
        public void TransferToShieldMoreEnergyThanShipHas()
        {
            ship.EnergyLevel = 1000;
            ship.TranserEnergyToShield(ship.EnergyLevel +1);
            Assert.AreEqual(Ship.MINIMUMENERGY, ship.EnergyLevel);
            Assert.AreEqual(Shields.STARTINGENERGY + 1000, ship.ShieldSystem.EnergyLevel);

        }

        [TestMethod]
        public void EnemyDamagesShipShieldWhileShieldIsRaised()
        {
            ship.ShieldSystem.Raise();
            ship.TakeDamage(1000);
            Assert.AreEqual(7000,ship.ShieldSystem.EnergyLevel);
        }

        [TestMethod]
        public void EnemyDamgesShipWhileShieldIsLowered()
        {
            ship.TakeDamage(1000);
            Assert.AreEqual(Shields.STARTINGENERGY, ship.ShieldSystem.EnergyLevel);
        }

        [TestMethod]
        public void EnergyDamageShieldMoreThanShieldCanTake()
        {

        }
    }
}
