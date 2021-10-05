using System;
// There is a sequence of numbers. Print all its items without duplicates.
//     Input:
//
// 1. An array of positive integers.
//
// 2. Termination number -1

using System.Linq;

namespace SEQUENCE_WITHOUT_REPETITIONS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (var i = 0; i < numbers.Length; i++)
            {
                int j;
                for (j = 0; j < i; j++)
                    if (numbers[i] == numbers[j])
                        break;

                if (numbers[i] == -1)
                {
                    break;
                }

                if (i == j)
                    Console.Write(numbers[i] + " ");
            }
            
            Console.Write(-1);
        }
    }
}