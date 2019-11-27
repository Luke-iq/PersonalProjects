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

        public void SetDrivetrain(int[] chainrings, int[] cassette)
        {
            _chainrings = chainrings;
            _cassette = cassette;

            _gears = new GearRatio(_chainrings, _cassette);

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

        public GearRatio Gears()
        {
            return _gears;
        }

        public void Shift(ShiftDirection shiftDirection)
        {
            if (shiftDirection == ShiftDirection.Up && _currentGear < _gears.GearCount() - 1)
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
        public double CurrentRatio()
        {
            return _gears._gearRatios[_currentGear];
        }

        private GearRatio _gears;
        private int[] _chainrings;
        private int[] _cassette;
        private int _currentGear;

    }
    public enum ShiftDirection
    {
        Up,
        Down
    }
}
