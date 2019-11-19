using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    class Shifter : IShifter
    {
        public Shifter(IRingSet ringSet)
        {
            this._curPos = -1;
            this._rings = ringSet;
        }

        public int GetRingCount()
        {
            return _rings.RingCount;
        }

        public void SettingGears(IRingSet ringSet)
        {
            _curPos = 0;
            _rings = ringSet;
            
        }
        public int CurPos
        {
            get { return _curPos; }
            set { _curPos = value;  }
        }

        public IRingSet Rings
        {
            get { return _rings;  }
        }


        private int _curPos;
        private IRingSet _rings;

    }

    internal interface IShifter
    {
        IRingSet Rings { get; }

        int CurPos { get; set; }

        int GetRingCount();

        void SettingGears(IRingSet ringSet);

    }
}
