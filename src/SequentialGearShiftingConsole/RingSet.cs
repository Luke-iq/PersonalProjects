using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    class RingSet
    {
        public RingSet()
        {
            this._rings = new List<int>();
        }
        public RingSet(List<int> rings)
        {
            this._rings = rings;
        }

        public List<int> GetRingSet()
        {
            return this._rings;
        }

        public void SetRings(List<int> rings)
        {
            this._rings = rings;
        }

        private List<int> _rings;
    }
}
