﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NostalgiaTrek
{
    public class Shields
    {
        private bool isRaised = true;

        public bool IsUp()
        {
            return isRaised;
        }

        public void Lower()
        {
            isRaised = false;
        }
    }
}
