namespace SequentialGearShiftingConsole
{
    public class Drivetrain
    {
        public Drivetrain(int[] chainrings, int[] cassette)
        {
            _chainrings = chainrings;
            _cassette = cassette;

            _gears = new GearRatio(_chainrings, _cassette);

            _currentGear = 0;
        }

        public void Shift(ShiftDirection shiftDirection)
        {
            if (shiftDirection == ShiftDirection.Up && _currentGear < _gears.GearCount() - 2)
                _currentGear++;
            else if (shiftDirection == ShiftDirection.Down && _currentGear > 0)
                _currentGear--;
        }


        public int[] CurrentGearCombination()
        {
            return _gears.GetCombinationByIndex(_currentGear);
        }

        public int CurrentGear()
        {
            return _currentGear;
        }

        public int[] _chainrings { get; }
        public int[] _cassette { get; }

        public GearRatio _gears { get; }

        private int _currentGear;

    }
    public enum ShiftDirection
    {
        Up,
        Down
    }
}
