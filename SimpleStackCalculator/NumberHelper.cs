namespace SimpleStackCalculator
{
    public class NumberHelper
    {
        internal static readonly short modulo = 1024; // 10-bit max value (1023) + 1
        internal static readonly short maxValue = 1023; // max value of a 10-bit number

        internal static short GetNormalizedNumber(short value)
        {
            if (value < 0 || value > maxValue)
            {
                return GetModulo(value);
            }

            return value;
        }

        // C#'s '%' returns a remainder, is not a modulo operator
        internal static short GetModulo(short number)
        {
            short result = (short)((number % modulo + modulo) % modulo);
            return result;
        }
    }
}
