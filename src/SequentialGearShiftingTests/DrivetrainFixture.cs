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
        public void Drivetrain_Should_Have_Highier_Gear_Ratio_After_Shift_Up()
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
        public void Drivetrain_Should_Have_Lower_Gear_Ratio_After_Shift_Down()
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
        public void Drivetrain_Should_Not_Be_Able_To_Shift_Down_When_In_Lowest_Gear()
        {
            var chainrings = new int[] { 36, 24 };
            var cassette = new int[] { 11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
            Drivetrain _sut = new Drivetrain(chainrings, cassette);
            var beforeChain = _sut.CurrentGearCombination()[0];
            var beforeCassette = _sut.CurrentGearCombination()[1];
            var beforeRatio = Math.Round((double)beforeChain / beforeCassette, 2);
            var beforeGear = _sut.CurrentGear();

            Action act = () => _sut.Shift(ShiftDirection.Down);
            act.Should().Throw<InvalidShiftOperationException>()
                .WithMessage($"Unable to shift {ShiftDirection.Down} from current gear: {_sut.CurrentGear() + 1}");

            var afterChain = _sut.CurrentGearCombination()[0];
            var afterCassette = _sut.CurrentGearCombination()[1];
            var afterRatio = Math.Round((double)afterChain / afterCassette, 2);

            afterChain.Should().Be(beforeChain);
            afterCassette.Should().Be(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear);
            afterRatio.Should().Be(beforeRatio);
        }

        [Test]
        public void Drivetrain_Should_Not_Be_Able_To_Shift_Up_When_In_Highest_Gear()
        {
            var chainrings = new int[] { 36 };
            var cassette = new int[] { 11, 13 };
            Drivetrain _sut = new Drivetrain(chainrings, cassette);

            _sut.Shift(ShiftDirection.Up);

            var beforeChain = _sut.CurrentGearCombination()[0];
            var beforeCassette = _sut.CurrentGearCombination()[1];
            var beforeRatio = Math.Round((double)beforeChain / beforeCassette, 2);
            var beforeGear = _sut.CurrentGear();

            Action act = () => _sut.Shift(ShiftDirection.Up);
            act.Should().Throw<InvalidShiftOperationException>()
                .WithMessage($"Unable to shift {ShiftDirection.Up} from current gear: {_sut.CurrentGear() + 1}");

            var afterChain = _sut.CurrentGearCombination()[0];
            var afterCassette = _sut.CurrentGearCombination()[1];
            var afterRatio = Math.Round((double)afterChain / afterCassette, 2);

            afterChain.Should().Be(beforeChain);
            afterCassette.Should().Be(beforeCassette);
            _sut.CurrentGear().Should().Be(beforeGear);
            afterRatio.Should().Be(beforeRatio);
        }
    }
}
