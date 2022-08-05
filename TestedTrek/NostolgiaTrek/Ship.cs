using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostalgiaTrek
{
    public class Ship
    {        
        public const int MINIMUMENERGY = 0;
        public const int STARTINGENERGY = 20000;
        private Shields _shields;
        public Shields ShieldSystem
        {
            get
            {
                return _shields;
            }
        }

        public int EnergyLevel { get; set; }

        public Ship()
        {
            _shields = new Shields();
            EnergyLevel = STARTINGENERGY;
        }

        public void TakeDamage(int damageAmount)
        {
            
            _shields.ReduceShield(damageAmount);
        }

        public void TranserEnergyToShield(int energyToTransfer)
        {
            energyToTransfer = GetEnergyToTransfer(energyToTransfer);
            EnergyLevel -= energyToTransfer;
            ShieldSystem.ChargeShield(energyToTransfer);
        }

        private int GetEnergyToTransfer(int energyToTransfer)
        {
            if (energyToTransfer > EnergyLevel)
            {
                energyToTransfer = EnergyLevel;
            }
            if (ShieldSystem.EnergyLevel + energyToTransfer > Shields.MAXENERGY)
            {
                energyToTransfer = Shields.MAXENERGY - ShieldSystem.EnergyLevel;
            }

            return energyToTransfer;
        }
    }
}
