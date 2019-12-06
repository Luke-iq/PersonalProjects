using System;
using System.Collections;
using System.Collections.Generic;
using SequentialGearShiftingConsole.Exceptions;

namespace SequentialGearShiftingConsole
{
    public class GearRatios
    {
        private double[] _gearRatios;
        private Hashtable _ratioCombination;

        public GearRatios(int[] chainrings, int[] cassette)
        {
            if (chainrings.Length <= 0 || cassette.Length <= 0)
                throw new InvalidInputException("Invalid input for chainrings/cassette");

            List<double> gearList = new List<double>();

            _ratioCombination = new Hashtable();
            
            for(int chainringPos = 0; chainringPos < chainrings.Length; chainringPos++)
            {
                for(int cassettePos = 0; cassettePos < cassette.Length; cassettePos++)
                {
                    if (!IsCrossChaining(chainrings, chainringPos, cassette, cassettePos))
                    {
                        double ratio = Math.Round((double) chainrings[chainringPos] / cassette[cassettePos], 2);
                        gearList.Add(ratio);
                        
                        int[] combination = new int[] {chainrings[chainringPos], cassette[cassettePos]};
                        _ratioCombination.Add(ratio, combination);
                    }
                }
            }

            _gearRatios = gearList.ToArray();
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

        public double GetRatioByGearIndex(int gearIndex)
        {
            if (gearIndex < 0 || gearIndex >= _gearRatios.Length)
                throw new RatioNotFoundException($"Gear ratio index: {gearIndex} out of range");

            return _gearRatios[gearIndex];
        }

        public bool IsCrossChaining(int[] chainrings, int chainringPos, int[] cassette, int cassettePos)
        {
            var minimumNumberOfChainForCrossChainingToOccur = 2;
            var minimumNumberOfCassetteRingsForCrossChainingToOccur = 7;
            var lowestChainring = 0;
            var highestChainring = chainrings.Length - 1;
            var crossChainingCassetRingCountForLowestChainring = (cassette.Length * 3 / 4);
            var crossChainingCassetRingCountForHighestChainring = (cassette.Length / 4);


            if (chainrings.Length < minimumNumberOfChainForCrossChainingToOccur || cassette.Length < minimumNumberOfCassetteRingsForCrossChainingToOccur)
                return false;

            if (chainringPos == lowestChainring && cassettePos >= crossChainingCassetRingCountForLowestChainring)
                return true;

            if (chainringPos == highestChainring && cassettePos <= crossChainingCassetRingCountForHighestChainring)
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
    }
}
