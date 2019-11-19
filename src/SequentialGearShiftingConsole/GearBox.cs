using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    class GearBox : IGearBox
    {
        public GearBox(IRingSet frontRings, IRingSet rearRings)
        {
            SetGearBox(frontRings, rearRings);
        }

        public void SetGearBox(IRingSet frontRings, IRingSet rearRings)
        {
            Dictionary<double, List<int[]>> newGearBox = new Dictionary<double, List<int[]>>();
            List<int[]> combination = new List<int[]>();

            int debugGearCount = 0;
            for (int frontRingPos = 0; frontRingPos < frontRings.RingCount; frontRingPos++)
            {
                for (int rearRingPos = 0; rearRingPos < rearRings.RingCount; rearRingPos++)
                {
                    double ratio = Math.Round((double)rearRings.Rings[rearRingPos] / frontRings.Rings[frontRingPos], 2);
                    int[] newCombination = { frontRingPos, rearRingPos };

                    if (newGearBox.ContainsKey(ratio))
                    {
                        newGearBox[ratio].Add(newCombination);
                    }
                    else
                    {
                        List<int[]> newCombinations = new List<int[]> { newCombination };
                        newGearBox.Add(ratio, newCombinations);
                        debugGearCount++;
                    }
                }
            }

            _gearBox = new IGearRatio[newGearBox.Count];

            int curGear = 0;
            foreach (KeyValuePair<double, List<int[]>> gear in newGearBox)
            {
                _gearBox[curGear] = new GearRatio(gear.Key, gear.Value);
                curGear++;
            }
        }

        public IGearRatio[] Gears
        {
            get { return _gearBox; }
        }

        private IGearRatio[] _gearBox;
    }

    internal interface IGearBox
    {
        void SetGearBox(IRingSet frontShifter, IRingSet rearShifter);
        IGearRatio[] Gears { get; }


    }
}
