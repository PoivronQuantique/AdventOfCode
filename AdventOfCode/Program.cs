using AdventOfCode.Template;
using System;

namespace AdventOfCode.Jours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jour_abs jour = new J01.Jour_1();

            Console.WriteLine("Part 1 : " + jour.Partie1().ToString().PadLeft(9));
            Console.WriteLine("Part 2 : " + jour.Partie2().ToString().PadLeft(9));
        }
    }
}
