using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    class GearRatio
    {
        public GearRatio()
        {
            _ratio = 0.0;
            _combination = new List<int[]>();
        }

        public GearRatio(int frontRingSize, int rearRingSize)
        {
            _ratio = frontRingSize / rearRingSize;
            _combination = new List<int[]>
            {
                new int[] { frontRingSize, rearRingSize}
            };
        }

        public void AddCombination(int frontRingSize, int rearRingSize)
        {
            _combination.Add(new int[] { frontRingSize, rearRingSize });
        }

        double _ratio;
        List<int[]> _combination;

    }
}
