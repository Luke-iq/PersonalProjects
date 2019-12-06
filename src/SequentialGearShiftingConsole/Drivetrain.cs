using SequentialGearShiftingConsole.Definitions;
using SequentialGearShiftingConsole.Exceptions;

namespace SequentialGearShiftingConsole
{
    public class Drivetrain
    {
        private GearRatios _gears;
        private int _currentGear;

        public Drivetrain(GearRatios gears)
        {
            _gears = gears;

            _currentGear = 0;
        }

        public void SetDrivetrain(GearRatios gears)
        {
            _gears = gears;

            _currentGear = 0;
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
            return _gears.GetRatioByGearIndex(_currentGear);
        }
    }
}
