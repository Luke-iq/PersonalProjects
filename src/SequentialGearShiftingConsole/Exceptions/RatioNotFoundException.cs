using System;

namespace SequentialGearShiftingConsole.Exceptions
{
    public class RatioNotFoundException : Exception
    {
        public RatioNotFoundException(string message)
            : base(message)
        {
        }
    }
}
