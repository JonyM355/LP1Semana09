using System;
using System.Collections.Generic;
using System.Linq;

namespace IntCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listTest = new List<int>();
            Stack<int> stackTest = new Stack<int>();
            Queue<int> queueTest = new Queue<int>();
            HashSet<int> setTest = new HashSet<int>();

            int[] numberArray = new int[] {1, 10, -30, 10, -5};

            foreach (int n in numberArray)
            {
                listTest.Add(n);
                stackTest.Push(n);
                queueTest.Enqueue(n);
                setTest.Add(n);
            }

            Console.WriteLine(PrintCollection("List",listTest));
            Console.WriteLine(PrintCollection("Stack",stackTest));
            Console.WriteLine(PrintCollection("Queue",queueTest));
            Console.WriteLine(PrintCollection("HashSet",setTest));
        }

        private static string PrintCollection(string name, IEnumerable<int> col)
        {
            string colString = $"{name}: ";
            int indexCounter = 0;

            foreach (int i in col)
            {
                if (indexCounter < col.Count()-1) 
                    colString += $"{i}, ";
                else 
                    colString += $"{i}";
                
                indexCounter++;
            }
            
            return colString;
        }

        private static string PrintCollection(string name, Stack<int> stack)  
        {
            string colString = $"{name}: ";
            int size = stack.Count;

            for (int i = 0; i < size; i++)
            {
                colString += stack.Pop();
                
                if (i < size-1)
                    colString += ", ";
            }
            
            return colString;
        }
        
        private static string PrintCollection(string name, Queue<int> queue)
        {
            string colString = $"{name}: ";
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                colString += queue.Dequeue();
                
                if (i < size-1)
                    colString += ", ";
            }
            
            return colString;
        }
    }
}