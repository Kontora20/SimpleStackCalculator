using System;

namespace SimpleStackCalculator
{
    public class ConsoleHelper
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Push a new value to the stack");
            Console.WriteLine("2. Pop a value from the stack");
            Console.WriteLine("3. Add top two values from the stack, pushes result back");
            Console.WriteLine("4. Subtract second top value from the top value, pushes result back");
        }

        internal static short GetRequiredInput()
        {
            Console.WriteLine();
            Console.WriteLine("Enter value to push: ");
            string input = Console.ReadLine();

            bool isNumeric = short.TryParse(input, out short value);
            if (!isNumeric)
            {
                throw new InvalidOperationException("Wrong input - it must be an integer (non-decimal)");
            }
            else
            {
                return value;
            }
        }

        internal static void WriteError(string message)
        {
            Console.WriteLine("Error: {0}", message);
        }
    }
}
