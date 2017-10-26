using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingPuzzleAStar
{
    //Developed by Paulo Renato Conceição Mendes
    //Based on professor Bruno Feres' slides
    //more info: https://github.com/paulorcmendes/SlidingPuzzleAStar
    //based also on my implementation of the Romanian cities: https://github.com/paulorcmendes/GraphSearchAlgorithms
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
        public static int[] ReadMatrix() {
            int[] matrix;
            matrix = new int[9];
            matrix = matrix.Select(i => Int32.MinValue).ToArray();
            for (int i = 0; i < 9; i++)
            {                
                int aux;
                Console.Write("Position({0}, {1}): ", i / 3, i % 3);
                aux = Convert.ToInt32(Console.ReadLine());
                while (matrix.Contains(aux) || aux < 0 || aux > 8) {
                    Console.Beep();
                    Console.WriteLine("Invalid value, try again!!");
                    Console.Write("Position({0}, {1}): ", i / 3, i % 3);
                    aux = Convert.ToInt32(Console.ReadLine());
                }
                matrix[i] = aux;
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Use 0 for the blank space\n\nInsert values for the initial state: ");
            int[] init = ReadMatrix();
            Console.WriteLine("Insert values for goal state: ");
            int[] final = ReadMatrix();
            //Console.Clear();
            Console.WriteLine("\n######### Result ##########");
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
