using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTrek
{
    public class RandomGenerator
    {
        // note we made generator public in order to mock it
        // it's ugly, but it's telling us something about our *design!* ;-)
        private  Random generator = new Random();
        public  int Rnd(int maximum)
        {
            return generator.Next(maximum);
        }

        public void setRandom(Random random)
        {
            generator = random;
        }
    }
}
