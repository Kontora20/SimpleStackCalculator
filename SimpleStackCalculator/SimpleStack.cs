using System;

namespace SimpleStackCalculator
{
    public class SimpleStack
    {
        private short[] data;
        private const int maxSize = 5;
        private int top;

        public SimpleStack()
        {
            data = new short[maxSize];
            top = 0;
        }

        internal void Push(short value)
        {
            if (top >= maxSize)
            {
                throw new InvalidOperationException("No more values can fit - would cause stack overflow");
            }
            else
            {
                short normalizedValue = NumberHelper.GetNormalizedNumber(value);
                data[top] = normalizedValue;
                top++;
            }
        }

        internal short Pop()
        {
            if (top <= 0)
            {
                throw new InvalidOperationException("Empty stack, no values to remove");
            }
            else
            {
                short value = data[--top];
                return value;
            }
        }
        internal void AddByPopping(SimpleStack stack)
        {
            if (top < 2)
            {
                throw new InvalidOperationException("Not enough values to perform an operation");
            }

            short[] values = new short[2];
            short result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = stack.Pop();
            }

            foreach (short value in values)
            {
                result += value;
            }

            Console.WriteLine("Result of sum: {0}", result);

            stack.Push(result);
        }

        internal void Subtract(SimpleStack stack)
        {
            if (top < 2)
            {
                throw new InvalidOperationException("Not enough values to perform an operation");
            }

            short[] values = new short[2];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = stack.Pop();
            }

            short result = (short)(values[0] - values[1]);

            Console.WriteLine("Result of subtraction: {0}", result);

            stack.Push(result);
        }

        internal void Print()
        {
            Console.WriteLine();

            if (top <= 0)
            {
                Console.WriteLine("No values in stack");
                return;
            }
            else
            {
                int peekingIndex = top;
                Console.WriteLine("Current values in stack:");
                while (peekingIndex != 0)
                {
                    Console.WriteLine(data[peekingIndex - 1]);
                    peekingIndex--;
                }
            }

            Console.WriteLine();
        }
    }
}
