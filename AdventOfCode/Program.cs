using AdventOfCode.Template;
using System;

namespace AdventOfCode.Jours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jour_abs jour = new J09.Jour_9();

            Console.WriteLine("Part 1 : " + jour.Partie1().ToString().PadLeft(15));
            Console.WriteLine("Part 2 : " + jour.Partie2().ToString().PadLeft(15));
        }
    }
}
