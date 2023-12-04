using AdventOfCode.Jours.J4;
using System;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jour_4 jour = new Jour_4();

            Console.WriteLine("Part 1 : " + jour.Partie1().ToString().PadLeft(9));
            Console.WriteLine("Part 2 : " + jour.Partie2().ToString().PadLeft(9));
        }
    }
}
