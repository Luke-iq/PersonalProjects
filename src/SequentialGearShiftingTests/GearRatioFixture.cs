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
        public void Gear_Ratio_Generated_OnCreation()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13};
            double[] expectedRatios = new double[] { 1.85, 2.18, 2.77, 3.27 };

            GearRatios _sut = new GearRatios(chainrings, cassette);

            _sut.GetAllAvailableGearRatios().Should().Equal(expectedRatios);

        }

        [Test]
        public void Gear_Ratio_Generated_Is_Sorted_Ascending_Order()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 22, 36, 40 };
            double[] expectedRatios = new double[] { 0.6, 0.67, 0.9, 1.0, 1.09, 1.64 };

            GearRatios _sut = new GearRatios(chainrings, cassette);
            
            _sut.GetAllAvailableGearRatios().Should().Equal(expectedRatios);

        }

        [Test]
        public void Return_Combination_For_Given_Ratio()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13 };
            GearRatios _sut = new GearRatios(chainrings, cassette);
            var expectedCombination = new int[] { chainrings[1], cassette[0] };
            double ratio = System.Math.Round((double)chainrings[1] / cassette[0], 2);

            _sut.GetCombinationByGearRatio(ratio).Should().Equal(expectedCombination);
        }

        [Test]
        public void Cross_Chainint_Check_Return_True_When_Cross_Chaining_Occurs_On_Largest_Chainring()
        {
            var chainrings = new int[] { 50, 30 };
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            _sut.IsCrossChaining(chainrings, 0, cassette, 7).Should().BeTrue();
        }

        [Test]
        public void Cross_Chainint_Check_Return_True_When_Cross_Chaining_Occurs_On_Smallest_Chainring()
        {
            var chainrings = new int[] { 50, 30 };
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            _sut.IsCrossChaining(chainrings, 1, cassette, 2).Should().BeTrue();
        }

        [Test]
        public void Cross_Chainint_Check_Return_False_When_Only_One_Chainring_Installed()
        {
            var chainrings = new int[] { 50};
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            _sut.IsCrossChaining(chainrings,0, cassette, 7).Should().BeFalse();
        }

        [Test]
        public void Cross_Chaining_Combination_Does_Not_Occurs_In_Gear_Ratios()
        {
            var chainrings = new int[] { 50, 30 };
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            var crossChainingRatio = Math.Round((double)chainrings[1] / cassette[2], 2);
            _sut.GetAllAvailableGearRatios().Should().NotContain(crossChainingRatio);
            Action act = () => _sut.GetCombinationByGearRatio(crossChainingRatio);
            act.Should()
                .Throw<RatioNotFoundException>($"Gear ratio: {crossChainingRatio} can NOT be produced by current drivetrain.");
        }

        [Test]
        public void Throw_Exception_When_Ratio_Not_Found()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13 };
            GearRatios _sut = new GearRatios(chainrings, cassette);
            double ratio = 3.33;

            Action act = () => _sut.GetCombinationByGearRatio(ratio);
            act.Should().Throw<RatioNotFoundException>().WithMessage($"Gear ratio: {ratio} can NOT be produced by current drivetrain.");
        }

    }
}
