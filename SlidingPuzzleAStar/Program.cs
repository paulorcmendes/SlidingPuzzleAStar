using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingPuzzleAStar
{
    class Program
    {
        
        public static int GetExpectation(int[] init, int[] final) {
            int expec = 0;
            for (int i = 0; i < 9; i++)
            {
                if (init[i] == 0) continue;
                expec += Math.Abs(i / 3 - Array.IndexOf(final, init[i]) / 3); //i/3 = line
                expec += Math.Abs(i % 3 - Array.IndexOf(final, init[i]) % 3); //i%3 = column
            }
            return expec;
        } 
        static void Main(string[] args)
        {
            int[] init = {7, 5, 0,
                          1, 8, 3,
                          4, 2, 6};
            int[] final = {0, 1, 2,
                           3, 4, 5,
                           6, 7, 8};
            Node n1 = new Node(init, GetExpectation(init, final));
            Node n2 = new Node(final, 0);

            Path path = GraphSearch.AStarSearch(n1, n2);
            if (path != null)
            {
                Console.Write(path);
            }
            else
            {
                Console.WriteLine("Path not found :(");
            }
            Console.ReadKey();
        }        
    }
}
