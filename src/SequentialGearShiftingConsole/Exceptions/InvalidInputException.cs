using System;

namespace SequentialGearShiftingConsole.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}
