using AdventOfCode.Jours;
using System;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jour_3 jour = new Jour_3();

            Console.WriteLine("Part 1 : " + jour.Partie1().ToString().PadLeft(9));
            Console.WriteLine("Part 2 : " + jour.Partie2().ToString().PadLeft(9));
        }
    }
}
