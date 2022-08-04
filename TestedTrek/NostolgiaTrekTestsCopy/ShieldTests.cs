using Microsoft.VisualStudio.TestTools.UnitTesting;
using NostalgiaTrek;
using System;

namespace NostaligaTrekTests
{
    [TestClass]
    public class ShieldTests
    {
        private Shields shield;

        [TestInitialize]
        public void Initialize()
        {
            shield = new Shields();
        }

        [TestMethod]
        public void ShieldsAreLoweredByDefault()
        {            
            Assert.IsFalse(shield.IsRaised);
        }
        
        [TestMethod]
        public void ShieldsCanBeRaised()
        {            
            shield.Raise();

            Assert.IsTrue(shield.IsRaised);
        }

        [TestMethod]
        public void ShieldsCanBeLowered()
        {            
            shield.Raise();
            shield.Lower();
            

            Assert.IsFalse(shield.IsRaised);
        }

        [TestMethod]
        public void CheckEnergy()
        {
            Assert.AreEqual(8000, shield.EnergyLevel);
        }

        [TestMethod]
        public void IncreaseShieldEnergy()
        {
            shield.ChargeShield(500);
            Assert.AreEqual(8500, shield.EnergyLevel);
        }

        [TestMethod]
        public void ChargeShieldsToMax()
        {
            shield.ChargeShield(20000);
            Assert.AreEqual(10000, shield.EnergyLevel);
        }
        [TestMethod]
        public void ReduceShields()
        {
            shield.Raise();
            shield.ReduceShield(200);

            Assert.AreEqual(7800, shield.EnergyLevel);
        }
        [TestMethod]
        public void ReduceShieldsToMinimum()
        {
            shield.Raise();

            shield.ReduceShield(12000);

            Assert.AreEqual(0, shield.EnergyLevel);
        }
        [TestMethod]
        public void CannotReduceShieldsWhenShieldsAreLowered()
        {
            shield.Lower();
            shield.ReduceShield(200);

            Assert.AreEqual(8000, shield.EnergyLevel);
        }

        [TestMethod]
        public void ShieldIsLoweredWhenFullyDamaged()
        {
            shield.Raise();
            shield.ReduceShield(shield.EnergyLevel + 1);
            
            Assert.IsFalse(shield.IsRaised);
        }
    }
}
