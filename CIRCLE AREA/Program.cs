// There is a length of a circle. Find the area of the circle.

using System;

namespace CIRCLE_AREA
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var length = float.Parse(Console.ReadLine());
            var r = length / (2 * Math.PI);

            Console.Write(Math.Round((Math.PI * r * r), 9));
        }
    }
}