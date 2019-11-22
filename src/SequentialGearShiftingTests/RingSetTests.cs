using System;
using NUnit.Framework;
using SequentialGearShiftingConsole;

namespace SequentialGearShiftingTests
{
    public class RingSetTests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CreateRings()
        {
            int[] rings = new[] { 0 };
            IRingSet newRingSet = new RingSet(rings);
            Assert.That(newRingSet.Rings, Is.EqualTo(rings));
            Assert.That(newRingSet.RingCount, Is.EqualTo(rings.Length));
        }

        [Test]
        public void SetRingsMethod()
        {
            int[] rings = new[] { 0 };
            IRingSet newRingSet = new RingSet(rings);
            int[] newRing = new[] {32, 22};
            newRingSet.SetRings(newRing);
            Assert.That(newRingSet.Rings, Is.EqualTo(newRing));
            Assert.That(newRingSet.RingCount, Is.EqualTo(newRing.Length));
        }

        [Test]
        public void SetRings()
        {
            int[] rings = new[] { 0 };
            IRingSet newRingSet = new RingSet(rings);
            int[] newRing = new[] { 32, 22 };
            newRingSet.Rings = newRing;
            Assert.That(newRingSet.Rings, Is.EqualTo(newRing));
            Assert.That(newRingSet.RingCount, Is.EqualTo(newRing.Length));
        }
    }
}