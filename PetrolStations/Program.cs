// Suppose there is a long straight road between cities A and B with nonnegative integer coordinates c_A and c_B, respectively. There are several petrol stations on the road. The location of each station is described by its nonnegative integer coordinate s_i.
// Note: Two stations can have the same coordinates.
// We are going to drive from city A to city B. Our car’s tank can hold petrol for k miles. At the beginning of the trip, the tank is full. During the route, we can stop at stations to refill the petrol. The goal is to minimize the number of stops along the route.

using System;
using System.Linq;

namespace PetrolStations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var numbers = line.Split(' ').Select(x => int.Parse(x)).ToArray();
            var c_A = numbers[0];
            var c_B = numbers[1];
            var k = numbers[2];
            var n = numbers[3];
            
            var s_i = new int[n];
            for (var i = 0; i < s_i.Length; i++)
            {
                s_i[i] = numbers[4 + i];
            }

            int temp;
            for (int i = 0; i < s_i.Length-1; i++)
            {
                for (int j = i + 1; j < s_i.Length; j++)
                {
                    if (s_i[i] > s_i[j])
                    {
                        temp = s_i[i];
                        s_i[i] = s_i[j];
                        s_i[j] = temp;
                    }
                }
            }
            
            var stops = 0;
            
            var destinationAandB = c_B - c_A;

            if (destinationAandB <= k)
            {
                stops = 0;
            }
            else
            {
                var destBetweenAandFs = s_i[0] - c_A;

                if (destBetweenAandFs == k)
                {
                    stops += 1;

                    for (var i = 1; i < s_i.Length; i++)
                    {
                        var destBetweenPs = s_i[i] - s_i[i - 1];

                        if (k == destBetweenPs)
                        {
                            stops += 1;
                        }

                        if (k > destBetweenPs)
                        {
                            var destBetweenBandPs = c_B - s_i[i];

                            if (destBetweenBandPs > k)
                            {
                                stops += 1;
                            }
                        }

                        if (k < destBetweenPs)
                        {
                            stops = -1;
                        }
                    }
                }

                if (destBetweenAandFs > k)
                {
                    stops = -1;
                }

                if (k > destBetweenAandFs)
                {
                    for (int i = 1; i < s_i.Length; i++)
                    {
                        var destBetweenPs = s_i[i] - s_i[i - 1];

                        if (k == destBetweenPs)
                        {
                            stops += 1;
                        }

                        if (k > destBetweenPs)
                        {
                            var destBetweenBandPs = c_B - s_i[i];

                            if (destBetweenBandPs > k)
                            {
                                stops += 1;
                            }
                        }
                        
                        if (k < destBetweenPs)
                        {
                            stops = -1;
                        }
                    }
                }
            }
            Console.Write(stops);
        }
    }
}