using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShiftingConsole
{
    class Bike
    {
        public Bike(IRingSet frontRings, IRingSet rearRings)
        {
            _frontShifter = new Shifter(frontRings);
            _rearShifter = new Shifter(rearRings);
            _gearBox = new GearBox(_frontShifter.Rings, _rearShifter.Rings);
            _frontShiftBiased = false;
        }

        public bool IsFrontShiftBiased()
        {
            return _frontShiftBiased;
        }

        public IGearBox GetGearBox()
        {
            return _gearBox;
        }

        public Shifter GetShifter(string shifterType)
        {
            switch(shifterType.ToLower())
            {
                case "front":
                    return _frontShifter;
                    

                case "rear":
                    return _rearShifter;
                    

                default:
                    Console.WriteLine($"***ERROR*** TRYING TO GET UNKNOWN SHIFTER TYPE {shifterType}");
                    return null;
            }
        }

        public void SetShifterRings(string shifterType, IRingSet rings)
        {
            if (rings.RingCount <= 0)
            {
                Console.WriteLine("***ERROR*** TRYING TO SETUP FRONT SHIFTER WITH EMPTY GEARS");
            }

            switch (shifterType.ToLower())
            {
                case "front":   
                    _frontShifter.SettingGears(rings);
                    break;

                case "rear":
                    _rearShifter.SettingGears(rings);
                    break;

                default:
                    Console.WriteLine($"***ERROR*** TRYING TO SETUP UNKNOWN SHIFTER TYPE {shifterType}");
                    break;
            }
            _gearBox.SetGearBox(_frontShifter.Rings, _rearShifter.Rings);
        }

        // Probably should just use array of shifter and use some global const to differentiate front and rear
        private Shifter _frontShifter;
        private Shifter _rearShifter;

        // flag for picking shiting priority when same ratio can be produced by different combination
        private bool _frontShiftBiased;


        private IGearBox _gearBox;
    }
}
