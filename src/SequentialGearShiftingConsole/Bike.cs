using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialGearShitingConsole
{
    class Bike
    {
        public Bike()
        {
            frontShifter = new Shifter();
            rearShifter = new Shifter();
            frontShiftBiased = false;
        }

        public Bike(List<int> frontRings, List<int> rearRings)
        {
            frontShifter = new Shifter(frontRings);
            rearShifter = new Shifter(rearRings);
            frontShiftBiased = false;
        }

        public bool isFrontShiftBiased()
        {
            return frontShiftBiased;
        }

        public Shifter getFrontShifter()
        {
            return frontShifter;
        }

        public Shifter getRearShifter()
        {
            return rearShifter;
        }

        public void setFrontShifterGears(List<int> newRings)
        {
            if (newRings.Count <= 0)
            {
                Console.WriteLine("***ERROR*** TRYING TO SETUP FRONT SHIFTER WITH EMPTY GEARS");
            }

            frontShifter.SettingGears(newGears);

        }

        public void setRearShifterGears(List<int> newRings)
        {
            if (newRings.Count <= 0)
            {
                Console.WriteLine("***ERROR*** TRYING TO SETUP REAR SHIFTER WITH EMPTY GEARS");
            }

            rearShifter.SettingGears(newRings);
        }



        private Shifter frontShifter;
        private Shifter rearShifter;
        private bool frontShiftBiased;
    }
}
