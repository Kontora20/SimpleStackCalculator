using System;

namespace SimpleStackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleStack stack = new SimpleStack();

            ConsoleKeyInfo cki;
            do
            {
                ConsoleHelper.DisplayMenu();
                cki = Console.ReadKey(true);
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        var pushAction = new ParameterizedStackAction(Push);
                        ExecuteStackActionWithParam(pushAction, stack);
                        break;
                    case "2":
                        var popAction = new ParameterlessStackAction(Pop);
                        ExecuteStackAction(popAction, stack);
                        break;
                    case "3":
                        var addAction = new ParameterlessStackAction(Add);
                        ExecuteStackAction(addAction, stack);
                        break;
                    case "4":
                        var subAction = new ParameterlessStackAction(Subtract);
                        ExecuteStackAction(subAction, stack);
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }

        internal delegate void ParameterlessStackAction(SimpleStack stack);

        internal delegate void ParameterizedStackAction(SimpleStack stack, short parameter);

        internal static void Push(SimpleStack stack, short value) => stack.Push(value);

        internal static void Pop(SimpleStack stack) => stack.Pop();

        internal static void Add(SimpleStack stack) => stack.AddByPopping(stack);

        internal static void Subtract(SimpleStack stack) => stack.Subtract(stack);

        internal static void ExecuteStackAction(ParameterlessStackAction action, SimpleStack stack)
        {
            try
            {
                action.Invoke(stack);
            }
            catch (InvalidOperationException ex)
            {
                HandleException(ex);
            }

            stack.Print();
        }

        internal static void ExecuteStackActionWithParam(ParameterizedStackAction action, SimpleStack stack)
        {
            try
            {
                short value = ConsoleHelper.GetRequiredInput();
                action.Invoke(stack, value);
            }
            catch (InvalidOperationException ex)
            {
                HandleException(ex);
            }

            stack.Print();
        }

        internal static void HandleException(Exception ex)
        {
            Console.WriteLine();
            ConsoleHelper.WriteError(ex.Message);
            Console.WriteLine();
        }
    }
}
