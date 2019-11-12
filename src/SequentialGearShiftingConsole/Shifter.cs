using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    class Shifter
    {
        public Shifter()
        {
            this._curPos = -1;
            this._rings = new RingSet();

        }

        public Shifter(List<int> rings)
        {
            this._curPos = -1;
            this._rings = new RingSet(rings);
        }

        public int GetCurGear()
        {
            return _curPos;
        }

        public RingSet GetRingSet()
        {
            return _rings;
        }

        public int GetRingCount()
        {
            return _rings.GetRingSet().Count;
        }

        public void SettingGears(List<int> rings)
        {
            this._curPos = 0;
            this._rings = new RingSet(rings);
            
        }
        public void SetCurGear(int newPos)
        {
            this._curPos = newPos;
        }

        private int _curPos;
        private RingSet _rings;

    }
}
