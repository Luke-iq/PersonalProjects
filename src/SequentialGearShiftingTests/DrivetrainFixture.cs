using System;
using NUnit.Framework;
using FluentAssertions;
using SequentialGearShiftingConsole;

namespace SequentialGearShiftingTests
{
    [TestFixture]
    class DrivetrainFixture
    {
        [Test]
        public void Drivetrain_ShouldHave_HighierGearRatio_After_ShiftUp()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            Drivetrain _sut = new Drivetrain(chainrings, cassette);
            var beforeChain = _sut.CurrentGearCombination()[0];
            var beforeCassette = _sut.CurrentGearCombination()[1];
            var beforeRatio = Math.Round((double)_sut.CurrentGearCombination()[0] / _sut.CurrentGearCombination()[1], 2);
            var beforeGear = _sut.CurrentGear();

            _sut.Shift(ShiftDirection.Up);
            var afterRatio = Math.Round((double)_sut.CurrentGearCombination()[0] / _sut.CurrentGearCombination()[1], 2);
            var afterChain = _sut.CurrentGearCombination()[0];
            var afterCassette = _sut.CurrentGearCombination()[1];

            afterChain.Should().Be(beforeChain);
            afterCassette.Should().NotBe(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear + 1);
            afterRatio.Should().BeGreaterThan(beforeRatio);
        }

        [Test]
        public void Drivetrain_ShouldHave_LowerGearRatio_After_ShiftDown()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            Drivetrain _sut = new Drivetrain(chainrings, cassette);

            _sut.Shift(ShiftDirection.Up);
            _sut.Shift(ShiftDirection.Up);
            var beforeChain = _sut.CurrentGearCombination()[0];
            var beforeCassette = _sut.CurrentGearCombination()[1];
            var beforeRatio = Math.Round((double)_sut.CurrentGearCombination()[0] / _sut.CurrentGearCombination()[1], 2);
            var beforeGear = _sut.CurrentGear();

            _sut.Shift(ShiftDirection.Down);
            var afterRatio = Math.Round((double)_sut.CurrentGearCombination()[0] / _sut.CurrentGearCombination()[1], 2);
            var afterChain = _sut.CurrentGearCombination()[0];
            var afterCassette = _sut.CurrentGearCombination()[1];

            afterChain.Should().Be(beforeChain);
            afterCassette.Should().NotBe(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear - 1);
            afterRatio.Should().BeLessThan(beforeRatio);
        }

        [Test]
        public void Drivetrain_ShouldNotBeAbleTo_ShiftUp_When_InHighestGear()
        {
            var chainrings = new int[] { 36 };
            var cassette = new int[] { 11, 13 };
            Drivetrain _sut = new Drivetrain(chainrings, cassette);

            _sut.Shift(ShiftDirection.Up);

            var beforeChain = _sut.CurrentGearCombination()[0];
            var beforeCassette = _sut.CurrentGearCombination()[1];
            var beforeRatio = Math.Round((double)_sut.CurrentGearCombination()[0] / _sut.CurrentGearCombination()[1], 2);
            var beforeGear = _sut.CurrentGear();

            _sut.Shift(ShiftDirection.Up);
            var afterRatio = Math.Round((double)_sut.CurrentGearCombination()[0] / _sut.CurrentGearCombination()[1], 2);
            var afterChain = _sut.CurrentGearCombination()[0];
            var afterCassette = _sut.CurrentGearCombination()[1];

            afterChain.Should().Be(beforeChain);
            afterCassette.Should().Be(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear);
            afterRatio.Should().Be(beforeRatio);
        }

        [Test]
        public void Drivetrain_ShouldNotBeAbleTo_ShiftDown_When_InLowestGear()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            Drivetrain _sut = new Drivetrain(chainrings, cassette);
            var beforeRatio = _sut.CurrentGearCombination()[1] / _sut.CurrentGearCombination()[0];
            var beforeGear = _sut.CurrentGear();

            _sut.Shift(ShiftDirection.Down);
            var afterRatio = _sut.CurrentGearCombination()[1] / _sut.CurrentGearCombination()[0];

            _sut.CurrentGear().Should().Equals(beforeGear);
            afterRatio.Should().Equals(beforeRatio);
        }
    }
}
