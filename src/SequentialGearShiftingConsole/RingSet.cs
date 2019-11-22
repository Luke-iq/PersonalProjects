using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    public class RingSet : IRingSet
    {
        public int[] Rings
        {
            get { return _rings; }
            set
            {
                _rings = value;
                _ringCount = _rings.Length;
            }
        }

        public int RingCount
        {
            get { return _ringCount; }
        }

        public void SetRings(int[] rings)
        {
            this._rings = rings;
            this._ringCount = rings.Length;
        }

        private int[] _rings;
        private int _ringCount;
    }

    public interface IRingSet
    {
        int[] Rings { get; set; }

        int RingCount { get; }

        void SetRings(int[] rings);
    }
}
