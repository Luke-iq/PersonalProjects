using System;
using NUnit.Framework;
using SequentialGearShiftingConsole;

namespace SequentialGearShiftingTests
{
    class ShifterTests
    {

        [Test]
        public void CreateShifter()
        {
            int[] rings = {32, 22};
            RingSet newRingSet = new RingSet(rings);
            Shifter newShifter = new Shifter(newRingSet);

            Assert.That(newShifter.Rings, Is.EqualTo(newRingSet));
            Assert.That(newShifter.GetRingCount(), Is.EqualTo(newRingSet.RingCount));
            Assert.That(newShifter.CurPos, Is.EqualTo(0));

        }

        [Test]
        public void SetCurPos()
        {
            int[] rings = {32, 22};
            RingSet newRingSet = new RingSet(rings);
            Shifter newShifter = new Shifter(newRingSet);

            Assert.That(newShifter.Rings, Is.EqualTo(newRingSet));
            Assert.That(newShifter.GetRingCount(), Is.EqualTo(newRingSet.RingCount));
            Assert.That(newShifter.CurPos, Is.EqualTo(0));

            int[] newRings = {11, 22, 33};
            newRingSet.SetRings(newRings);
            newShifter.SettingGears(newRingSet);
            Assert.That(newShifter.Rings, Is.EqualTo(newRingSet));
            Assert.That(newShifter.GetRingCount(), Is.EqualTo(newRingSet.RingCount));
            Assert.That(newShifter.CurPos, Is.EqualTo(0));

        }


        [Test]
        public void SettingGears()
        {
            int[] rings = {32, 22};
            RingSet newRingSet = new RingSet(rings);
            Shifter newShifter = new Shifter(newRingSet);

            Assert.That(newShifter.Rings, Is.EqualTo(newRingSet));
            Assert.That(newShifter.GetRingCount(), Is.EqualTo(newRingSet.RingCount));
            Assert.That(newShifter.CurPos, Is.EqualTo(0));

        }
    }

}