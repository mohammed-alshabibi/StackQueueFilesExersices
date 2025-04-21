namespace StackQueueFilesExersices
{
    
    internal class Program
    {
        static Stack<string> PostfixExp = new Stack<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an Expression: ");
            string input = Console.ReadLine();
            //Console.WriteLine("Postfix Expression: " + PostFixExpression(input));
            Console.WriteLine("Reversed String: " + ReverseString(input));
        }
        // postfix using stack
        public static int PostFixExpression(string input)
        {
            string[] tokens = input.Split(' ');
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    int b = stack.Pop();
                    int a = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                    }
                }
            }
            return stack.Pop();
        }
        // Reverse a string using stack
        public static string ReverseString(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in input)
            {
                stack.Push(c);
            }
            char[] reversed = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                reversed[i] = stack.Pop();
            }
            return new string(reversed);
        }
    }
}
