using FluentAssertions;
using NUnit.Framework;
using SequentialGearShiftingConsole;
using System;
using SequentialGearShiftingConsole.Exceptions;

namespace SequentialGearShiftingTests
{
    [TestFixture]
    class GearRatioFixture
    {
        [Test]
        public void Should_Generate_Correct_Ratios_On_Creation()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13};
            double[] expectedRatios = new double[] { 1.85, 2.18, 2.77, 3.27 };

            GearRatios _sut = new GearRatios(chainrings, cassette);

            _sut.GetAllAvailableGearRatios().Should().Equal(expectedRatios);
        }

        [Test]
        public void Should_Generate_Ascending_Order_Ratios()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 22, 36, 40 };
            double[] expectedRatios = new double[] { 0.6, 0.67, 0.9, 1.0, 1.09, 1.64 };

            GearRatios _sut = new GearRatios(chainrings, cassette);
            
            _sut.GetAllAvailableGearRatios().Should().Equal(expectedRatios);
        }

        [Test]
        public void Should_Return_Correct_Combination_For_Given_Ratio()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13 };
            GearRatios _sut = new GearRatios(chainrings, cassette);
            var expectedCombination = new int[] { chainrings[1], cassette[0] };
            double ratio = System.Math.Round((double)chainrings[1] / cassette[0], 2);

            var actualCombination = _sut.GetCombinationByGearRatio(ratio);
                
            actualCombination.Should().Equal(expectedCombination);
        }

        [Test]
        public void Should_Return_True_When_Cross_Chaining_Occurs_On_Largest_Chainring()
        {
            var chainrings = new int[] { 50, 30 };
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            var isCrossChaining = _sut.IsCrossChaining(chainrings, 0, cassette, 7);

            isCrossChaining.Should().BeTrue();
        }

        [Test]
        public void Should_Return_True_When_Cross_Chaining_Occurs_On_Smallest_Chainring()
        {
            var chainrings = new int[] { 50, 30 };
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            var isCrossChaining = _sut.IsCrossChaining(chainrings, 1, cassette, 2);

            isCrossChaining.Should().BeTrue();
        }

        [Test]
        public void Should_Return_False_When_Only_One_Chainring_Installed()
        {
            var chainrings = new int[] { 50};
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            GearRatios _sut = new GearRatios(chainrings, cassette);

            var isCrossChaining = _sut.IsCrossChaining(chainrings,0, cassette, 7);

            isCrossChaining.Should().BeFalse();
        }

        [Test]
        public void Should_Not_Contain_Cross_Chaining_Ratio()
        {
            var chainrings = new int[] { 50, 30 };
            var cassette = new int[] { 11, 12, 13, 14, 15, 17, 19, 21, 23 };
            var crossChainingRatio = Math.Round((double)chainrings[1] / cassette[2], 2);
            GearRatios _sut = new GearRatios(chainrings, cassette);

            var allRatios = _sut.GetAllAvailableGearRatios();

            allRatios.Should().NotContain(crossChainingRatio);
        }

        [Test]
        public void Should_Throw_Exception_When_Ratio_Not_Found()
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
