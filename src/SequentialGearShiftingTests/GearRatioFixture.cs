using FluentAssertions;
using NUnit.Framework;
using SequentialGearShiftingConsole;
using System;

namespace SequentialGearShiftingTests
{
    [TestFixture]
    class GearRatioFixture
    {
        [Test]
        public void GearRatioGenerated_OnCreation()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13};
            double[] expectedRatios = new double[] { 1.85, 2.18, 2.77, 3.27 };

            GearRatio _sut = new GearRatio(chainrings, cassette);

            _sut.Should().Equal(expectedRatios);

        }

        [Test]
        public void GearRatioGenerated_IsSorted_AscendingOrder()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 22, 36, 40 };
            double[] expectedRatios = new double[] { 0.6, 0.67, 0.9, 1.0, 1.09, 1.64 };

            GearRatio _sut = new GearRatio(chainrings, cassette);
            
            _sut._gearRatios.Should().Equal(expectedRatios);

        }

        [Test]
        public void ReturnCombination_For_GivenRatio()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13 };
            GearRatio _sut = new GearRatio(chainrings, cassette);
            var expectedCombination = new int[] { chainrings[1], cassette[0] };
            double ratio = System.Math.Round((double)chainrings[1] / cassette[0], 2);

            _sut.GetCombination(ratio).Should().Equal(expectedCombination);
        }


        [Test]
        public void ThrowException_When_Ratio_NotFound()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13 };
            GearRatio _sut = new GearRatio(chainrings, cassette);
            double ratio = 3.33;

            Action act = () => _sut.GetCombination(ratio);
            act.Should().Throw<RatioNotFoundException>().WithMessage($"Gear ratio: {ratio} can NOT be produced by current drivetrain.");
        }

    }
}
