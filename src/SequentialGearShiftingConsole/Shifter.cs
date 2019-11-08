using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShitingConsole
{
    class Shifter
    {
        public Shifter()
        {
            curGear = -1;
            gears = new RingSet();

        }

        public Shifter(List<int> newRings)
        {
            curGear = -1;
            rings = new RingSet(newRings);
        }

        public int getCurGear()
        {
            return curPos;
        }

        public RingSet getRingSet()
        {
            return rings;
        }

        public int getRingCount()
        {
            return rings.GetRingSet().Count;
        }

        public void SettingGears(List<int> newRings)
        {
            curPos = 0;
            rings = new RingSet(newRings);
            
        }
        public void setCurGear(int newPos)
        {
            curPos = newPos;
        }

        private int curPos;
        private RingSet rings;

    }
}
