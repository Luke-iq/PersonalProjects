using System;
using System.Collections;

namespace SequentialGearShiftingConsole
{
    public class GearRatio : IEnumerator, IEnumerable
    {
        // Should add validation and make sure all values in chainring and cassette are geater than 0
        // May or may not need a upper bound check as well
        public GearRatio(int[] chainring, int[] cassette)
        {
            _gearRatios = new double[chainring.Length * cassette.Length];
            int gearCount = 0;
            
            for(int chainringPos = 0; chainringPos < chainring.Length; chainringPos++)
            {
                for(int cassettePos = 0; cassettePos < cassette.Length; cassettePos++)
                {
                    double ratio = Math.Round((double)chainring[chainringPos] / cassette[cassettePos] , 2);
                    _gearRatios[gearCount] = ratio;
                    int[] combination = new int[] { chainring[chainringPos], cassette[cassettePos] };
                    _ratioCombination.Add(ratio, combination);
                    gearCount++;
                }
            }
            Array.Sort(_gearRatios);
        }

        public int[] GetCombination(double ratio)
        {
            if (!_ratioCombination.ContainsKey(ratio))
                throw new RatioNotFoundException($"Gear ratio: {ratio} can NOT be produced by current drivetrain.");

            int[] ringCombination = (int [])_ratioCombination[ratio];
            return ringCombination;
        }

        public int[] GetCombinationByIndex(int gearIndex)
        {
            if (gearIndex < 0 || gearIndex >= _gearRatios.Length)
                throw new RatioNotFoundException($"Gear ratio index: {gearIndex} out of range");

            double ratio = _gearRatios[gearIndex];
            int[] ringCombination = (int[])_ratioCombination[ratio];
            return ringCombination;
        }

        public int GearCount()
        {
            return _gearRatios.Length;
        }

        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _gearRatios.Length);
        }

        //IEnumerable
        public void Reset()
        { position = -1; }

        //IEnumerable
        public object Current => _gearRatios[position];
        public double[] _gearRatios { get; }

        private Hashtable _ratioCombination = new Hashtable();
        private int position = -1;
    }

    public class RatioNotFoundException : Exception
    {
        public RatioNotFoundException(string message)
           : base(message)
        {
        }
    }
}
