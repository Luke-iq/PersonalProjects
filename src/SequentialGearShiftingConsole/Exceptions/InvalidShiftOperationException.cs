using System;

namespace SequentialGearShiftingConsole.Exceptions
{
    public class InvalidShiftOperationException : Exception
    {
        public InvalidShiftOperationException(string message)
            : base(message)
        {
        }
    }
}
