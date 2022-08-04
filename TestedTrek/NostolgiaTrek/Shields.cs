using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostalgiaTrek
{
    public class Shields
    {
        private bool isRaised;

        public Shields()
        {
            isRaised = true;
        }

        public bool IsRaised()
        {
            return isRaised;
        }

        public void Lower()
        {
            isRaised = false;
        }

        public void Raise()
        {
            isRaised = true;
        }
    }
}
