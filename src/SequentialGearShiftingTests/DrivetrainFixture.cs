using System;
using NUnit.Framework;
using FluentAssertions;
using SequentialGearShiftingConsole;
using SequentialGearShiftingConsole.Definitions;
using SequentialGearShiftingConsole.Exceptions;

namespace SequentialGearShiftingTests
{
    [TestFixture]
    class DrivetrainFixture
    {

        [Test]
        public void Should_Have_Highier_Gear_Ratio_After_Shift_Up()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            GearRatios gears = new GearRatios(chainrings, cassette);
            Drivetrain _sut = new Drivetrain(gears);
            var beforeChain = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring];
            var beforeCassette = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette];
            var beforeRatio = Math.Round((double)_sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring] / _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette], 2);
            var beforeGear = _sut.CurrentGear();

            _sut.Shift(ShiftDirection.Up);

            var afterRatio = Math.Round((double)_sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring] / _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette], 2);
            var afterChain = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring];
            var afterCassette = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette];
            afterChain.Should().Be(beforeChain);
            afterCassette.Should().NotBe(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear + 1);
            afterRatio.Should().BeGreaterThan(beforeRatio);
        }

        [Test]
        public void Should_Have_Lower_Gear_Ratio_After_Shift_Down()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            GearRatios gears = new GearRatios(chainrings, cassette);
            Drivetrain _sut = new Drivetrain(gears);

            _sut.Shift(ShiftDirection.Up);
            _sut.Shift(ShiftDirection.Up);
            var beforeChain = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring];
            var beforeCassette = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette];
            var beforeRatio = Math.Round((double)_sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring] / _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette], 2);
            var beforeGear = _sut.CurrentGear();

            _sut.Shift(ShiftDirection.Down);

            var afterRatio = Math.Round((double)_sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring] / _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette], 2);
            var afterChain = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring];
            var afterCassette = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette];
            afterChain.Should().Be(beforeChain);
            afterCassette.Should().NotBe(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear - 1);
            afterRatio.Should().BeLessThan(beforeRatio);
        }

        [Test]
        public void Should_Throw_Exception_When_Shift_Down_From_Lowest_Gear()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            GearRatios gears = new GearRatios(chainrings, cassette);
            Drivetrain _sut = new Drivetrain(gears);
            var beforeChain = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring];
            var beforeCassette = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette];
            var beforeRatio = Math.Round((double)beforeChain / beforeCassette, 2);
            var beforeGear = _sut.CurrentGear();

            Action act = () => _sut.Shift(ShiftDirection.Down);

            act.Should().Throw<InvalidShiftOperationException>()
                .WithMessage($"Unable to shift {ShiftDirection.Down} from current gear: {_sut.CurrentGear() + 1}");

        }

        [Test]
        public void Should_Throw_Exception_When_Shift_Up_From_Highest_Gear()
        {
            var chainrings = new int[] { 36 };
            var cassette = new int[] { 11, 13 };
            GearRatios gears = new GearRatios(chainrings, cassette);
            Drivetrain _sut = new Drivetrain(gears);
            _sut.Shift(ShiftDirection.Up);
            var beforeChain = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Chainring];
            var beforeCassette = _sut.CurrentGearCombination()[(int)DrivetrainComponent.Cassette];
            var beforeRatio = Math.Round((double)beforeChain / beforeCassette, 2);
            var beforeGear = _sut.CurrentGear();

            Action act = () => _sut.Shift(ShiftDirection.Up);

            act.Should().Throw<InvalidShiftOperationException>()
                .WithMessage($"Unable to shift {ShiftDirection.Up} from current gear: {_sut.CurrentGear() + 1}");
        }
    }
}
