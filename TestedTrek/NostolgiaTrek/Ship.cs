using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostalgiaTrek
{
    public class Ship
    {
        private Shields _shields;
        public Shields ShieldSystem
        {
            get
            {
                return _shields;
            }
        }

        public Ship()
        {
            _shields = new Shields();
        }

        public void TakeDamage(int damageAmount)
        {
            _shields.ReduceShield(damageAmount);
        }
    }
}
