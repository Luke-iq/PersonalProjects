using System;

namespace SequentialGearShiftingConsole
{
    public class Drivetrain
    {
        public Drivetrain(int[] chainrings, int[] cassette)
        {
            _chainrings = chainrings;
            _cassette = cassette;

            _gears = new GearRatios(chainrings, cassette);

            _currentGear = 0;
        }

        public void SetDrivetrain(int[] chainrings, int[] cassette)
        {
            _chainrings = chainrings;
            _cassette = cassette;

            _gears = new GearRatios(_chainrings, _cassette);

            _currentGear = 0;
        }

        public int[] Chainrings()
        {
            return _chainrings;
        }

        public int[] Cassette()
        {
            return _cassette;
        }

        public GearRatios Gears()
        {
            return _gears;
        }


        public void Shift(ShiftDirection shiftDirection)
        {
            bool canShiftUp = _currentGear < _gears.NumberOfGears() - 1;
            bool canShiftDown = _currentGear > 0;

            if (shiftDirection == ShiftDirection.Up && canShiftUp)
                _currentGear++;
            else if (shiftDirection == ShiftDirection.Down && canShiftDown)
                _currentGear--;
            else
            {
                throw new InvalidShiftOperationException($"Unable to shift {shiftDirection} from current gear: {_currentGear+1}");
            }
        }
        public int[] CurrentGearCombination()
        {
            return _gears.GetCombinationByGearIndex(_currentGear);
        }
        public int CurrentGear()
        {
            return _currentGear;
        }
        public double CurrentRatio()
        {
            return _gears.GetAllAvailableGearRatios()[_currentGear];
        }

        private GearRatios _gears;
        private int[] _chainrings;
        private int[] _cassette;
        private int _currentGear;

    }
    public enum ShiftDirection
    {
        Up,
        Down
    }

    public class InvalidShiftOperationException : Exception
    {
        public InvalidShiftOperationException(string message)
            : base(message)
        {
        }
    }
}
