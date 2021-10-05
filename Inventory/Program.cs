using System;
using System.Linq;

namespace Inventory
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var array = new int[Array.IndexOf(numbers, -1)];
            var array1 = new int[numbers.Length - Array.IndexOf(numbers, -1)];
            
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = numbers[i];
            }
            
            for (var i = 0; i < array1.Length; i++)
            {
                array1[i] = numbers[Array.IndexOf(numbers, -1) + i + 1];
                if(array1[i] == -1)
                    break;
                
            }
            
            var soldier = new[,] {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};
            var strength = 0;
            var agility = 0;
            var intelligence = 0;

            var array2d = new int[array.Length / 4, 4];
            for (var i = 0; i < array.Length; i++)
            {
                array2d[i / array2d.GetLength(1), i % array2d.GetLength(1)] = array[i];
            }
            
            for (var i = 0; i < soldier.GetLength(0); i++)
            {
                for (var j = 0; j < soldier.GetLength(1); j++)
                {
                    soldier[i, j] = array2d[array1[i + 1] - 1, j];
                }
            }

            for (var i = 0; i < soldier.GetLength(0); i++)
            {
                if (soldier[i, 0] == array2d[i + 1, 0])
                {
                    for (var j = 0; j < soldier.GetLength(1); j++)
                    {
                        soldier[i, j] = 0;
                    }
                }
            }

            // for (var i = 0; i < soldier.GetLength(0); i++)
            // {
            //     for (var j = 0; j < soldier.GetLength(1); j++)
            //     {
            //         Console.Write(soldier[i, j] + " ");
            //     }
            // }
            
            for (var i = 0; i < soldier.GetLength(0); i++)
            {
                strength += soldier[i, 1];
                agility += soldier[i, 2];
                intelligence += soldier[i, 3];
            }
            
            Console.WriteLine(strength + " " + agility + " " + intelligence);
        }
    }
}