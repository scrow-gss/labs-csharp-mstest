﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostalgiaTrek
{
    public class Shields
    {
        private const int MAXENERGY = 10000;
        private const int MINIMUMENERGY = 0;
        private const int STARTINGENERGY = 8000;
        
        public bool IsRaised { get; private set; }

        public Shields()
        {
            IsRaised = false;
            EnergyLevel = STARTINGENERGY;
        }

        public void Lower()
        {
            IsRaised = false;
        }

        public void Raise()
        {
            IsRaised = true;
        }

        public int EnergyLevel { get; private set; }

        public void ChargeShield(int chargeAmount)
        {
            EnergyLevel += chargeAmount;

            if (EnergyLevel > MAXENERGY)
                EnergyLevel = MAXENERGY;
        }

        public void ReduceShield(int reductionAmount)
        {
            if (!IsRaised)
                return;

            EnergyLevel -= reductionAmount;

            if (EnergyLevel < MINIMUMENERGY)
            {
                EnergyLevel = MINIMUMENERGY;
                this.Lower();
            }
        }
    }
}
