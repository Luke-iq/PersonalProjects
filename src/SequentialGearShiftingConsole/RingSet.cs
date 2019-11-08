using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShitingConsole
{
    class RingSet
    {
        public RingSet()
        {
            rings = new List<int>();
        }
        public RingSet(List<int> newRings)
        {
            rings = newRings;
        }

        public List<int> GetRingSet()
        {
            return rings;
        }

        public void SetRings(List<int> newRings)
        {
            rings = newRings;
        }

        private List<int> rings;
    }
}
