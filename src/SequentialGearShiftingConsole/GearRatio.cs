using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SequentialGearShiftingConsole
{
    public class GearRatio : IGearRatio
    {
        public GearRatio(double ratio, List<int[]> combinations)
        {
            _ratio = ratio;
            _combinations = combinations;
        }

        public void SetGearRatio(double ratio, int[] combination)
        {
            _ratio = ratio;
            _combinations = new List<int[]> {combination};
        }

        public void AddCombination(int[] combination)
        {
            _combinations.Add(combination);
        }

        public double Ratio
        {
            get { return _ratio; }
        }
        public List<int[]> Combinations
        {
            get { return _combinations; }
        }

        double _ratio;
        List<int[]> _combinations;

    }
    public interface IGearRatio
    {
        void SetGearRatio(double ratio, int[] combination);

        void AddCombination(int[] combination);

        double Ratio
        {
            get;
        }

        List<int[]> Combinations
        {
            get;
        }
    }
}
