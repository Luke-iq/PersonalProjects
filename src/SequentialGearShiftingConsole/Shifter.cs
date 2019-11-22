using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    public class Shifter : IShifter
    {
        public int GetRingCount()
        {
            return _rings.RingCount;
        }

        public void SettingGears(RingSet ringSet)
        {
            _curPos = 0;
            _rings = ringSet;
            
        }
        public int CurPos
        {
            get { return _curPos; }
            set { _curPos = value;  }
        }

        public RingSet Rings
        {
            get { return _rings;  }
            set { _curPos = 0; _rings = value; }
        }


        private int _curPos;
        private RingSet _rings;

    }

    public interface IShifter
    {
        RingSet Rings { get; set; }

        int CurPos { get; set; }

        int GetRingCount();

        void SettingGears(RingSet ringSet);

    }
}
