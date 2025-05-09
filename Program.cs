﻿namespace StackQueueFilesExersices
{
    
    internal class Program
    {
        static Stack<string> PostfixExp = new Stack<string>();
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter an Expression: ");
            //string input = Console.ReadLine();
            ////Console.WriteLine("Postfix Expression: " + PostFixExpression(input));
            //Console.WriteLine("Reversed String: " + ReverseString(input));
            //BrowserHistory();
            //Console.WriteLine("Enter a string with HTML/XML tags: ");
            //string tagInput = Console.ReadLine();
            //if (ValidateTags(tagInput))
            //{
            //    Console.WriteLine("Tags are valid.");
            //}
            //else
            //{
            //    Console.WriteLine("Tags are invalid.");
            //}
            /////////////////////////////////////////
            Console.WriteLine("Enter How many number in the queue: ");
            int count = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter a number {i+1}: ");
                int number = int.Parse(Console.ReadLine());
                queue.Enqueue(number);
            }
            //Console.WriteLine("Enter K: ");
            //int K = int.Parse(Console.ReadLine());
            //Queue<int> rotatedQueue = RotateQueueElements(queue, K);
            //Console.WriteLine($"Rotated Queue {string.Join(", ", rotatedQueue)}");
            Queue<int> sortedQueue = SortQueue(queue);
            Console.WriteLine($"Sorted list {string.Join(", ", sortedQueue)}");
        }
        // postfix using stack
        public static int PostFixExpression(string input)
        {
            string[] tokens = input.Split(' ');//split input and store in array
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))// 
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
        // browser history navigation using stack
        public static void BrowserHistory()
        {
            Stack<string> backStack = new Stack<string>();
            Stack<string> forwardStack = new Stack<string>();
            string currentPage = "Home";
            while (true)
            {
                Console.WriteLine($"Current Page: {currentPage}");
                Console.WriteLine("Enter 'b' for back, 'f' for forward, 'v' for visit a new page, or 'q' to quit:");
                string input = Console.ReadLine();
                if (input == "b")
                {
                    if (backStack.Count > 0)
                    {
                        forwardStack.Push(currentPage);
                        currentPage = backStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No pages in back stack.");
                    }
                }
                else if (input == "f")
                {
                    if (forwardStack.Count > 0)
                    {
                        backStack.Push(currentPage);
                        currentPage = forwardStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No pages in forward stack.");
                    }
                }
                else if (input == "v")
                {
                    Console.Write("Enter the URL of the page to visit: ");
                    string url = Console.ReadLine();
                    backStack.Push(currentPage);
                    currentPage = url;
                    forwardStack.Clear(); // Clear forward stack when visiting a new page
                }
                else if (input == "q")
                {
                    break;
                }
            }
        }
        //XML/HTML tag validation using stack
        public static bool ValidateTags(string input)
        {
            Stack<string> stack = new Stack<string>();
            string[] tokens = input.Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                if (token.StartsWith("/"))
                {
                    if (stack.Count == 0 || stack.Pop() != token.Substring(1))
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(token);
                }
            }
            return stack.Count == 0;
        }
        //Rotate queue elements by K
        public static Queue<int> RotateQueueElements(Queue<int> queue,  int K)
        {
            int n =queue.Count;
            if(K<=0 || n==0)
            {
                return queue;
            }
            K = K % n;
            
            for (int i = 0; i < K; i++)
            {
                int item = queue.Dequeue();
                queue.Enqueue(item);
            }
            return queue;
        }
        // sort a queue using only queue operations
        public static Queue<int> SortQueue(Queue<int> queue)
        {
            int count = queue.Count;
            int min = queue.Min();
            Queue<int> sortedQueue = new Queue<int>();
            bool flag = false;
            while(count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    
                    int item = queue.Dequeue();
                    
                    if (item == min)
                    {
                        
                        min = queue.Min();
                        sortedQueue.Enqueue(item);
                    }
                    else
                    {
                        
                        queue.Enqueue(item);

                    }
                }
                count--;
            }
            
            return sortedQueue;
        }
    }
}
