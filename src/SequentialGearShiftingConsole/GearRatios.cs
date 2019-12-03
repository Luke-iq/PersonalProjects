using System;
using System.Collections;

namespace SequentialGearShiftingConsole
{
    public class GearRatios
    {
        public GearRatios(int[] chainrings, int[] cassette)
        {
            if (chainrings.Length <= 0 || cassette.Length <= 0)
                throw new InvalidInputException("Invalid input for chainrings/cassette");

            _gearRatios = new double[chainrings.Length * cassette.Length];
            _ratioCombination = new Hashtable();
            int gearCount = 0;
            
            for(int chainringPos = 0; chainringPos < chainrings.Length; chainringPos++)
            {
                for(int cassettePos = 0; cassettePos < cassette.Length; cassettePos++)
                {
                    if (!IsCrossChaining(chainrings, chainringPos, cassette, cassettePos))
                    {
                        double ratio = Math.Round((double) chainrings[chainringPos] / cassette[cassettePos], 2);
                        _gearRatios[gearCount] = ratio;
                        gearCount++;

                        int[] combination = new int[] {chainrings[chainringPos], cassette[cassettePos]};
                        _ratioCombination.Add(ratio, combination);
                    }
                }
            }
            Array.Resize(ref _gearRatios, gearCount);
            Array.Sort(_gearRatios);
        }

        public int[] GetCombinationByGearRatio(double ratio)
        {
            if (!_ratioCombination.ContainsKey(ratio))
                throw new RatioNotFoundException($"Gear ratio: {ratio} can NOT be produced by current drivetrain.");

            int[] ringCombination = (int [])_ratioCombination[ratio];
            return ringCombination;
        }

        public int[] GetCombinationByGearIndex(int gearIndex)
        {
            if (gearIndex < 0 || gearIndex >= _gearRatios.Length)
                throw new RatioNotFoundException($"Gear ratio index: {gearIndex} out of range");

            double ratio = _gearRatios[gearIndex];
            int[] ringCombination = (int[])_ratioCombination[ratio];
            return ringCombination;
        }

        //Cross Chaining (above) as the condition where the chain is running across the drivetrain centerline.
        //In truth, it’s more like running to extremes across the drivetrain centerline.
        //In general, use the biggest 1/4 of the cassette with the big ring,
        //and the smallest 1/4 of the cassette with the small ring,
        //are considered cross chaining.
        //Cross chaining does not occur when there is only single chainring or number of cassette is less than 7. 
        public bool IsCrossChaining(int[] chainrings, int chainringPos, int[] cassette, int cassettePos)
        {
            if(chainrings.Length == 1 || cassette.Length < 7)
                return false;

            if (chainringPos == 0 && cassettePos >= (cassette.Length * 3 / 4))
                return true;

            if (chainringPos == chainrings.Length - 1 && cassettePos <= (cassette.Length / 4))
                return true;

            return false;
        }

        public double[] GetAllAvailableGearRatios()
        {
            return _gearRatios;
        }

        public int NumberOfGears()
        {
            return _gearRatios.Length;
        }

        private double[] _gearRatios;
        private Hashtable _ratioCombination;
    }

    public class RatioNotFoundException : Exception
    {
        public RatioNotFoundException(string message)
           : base(message)
        {
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}
