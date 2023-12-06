using AdventOfCode.Jours.J5;
using AdventOfCode.Jours.J6;
using System;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Jour_5 jour = new Jour_5();
            Jour_6 jour = new Jour_6();

            Console.WriteLine("Part 1 : " + jour.Partie1().ToString().PadLeft(9));
            Console.WriteLine("Part 2 : " + jour.Partie2().ToString().PadLeft(9));
        }
    }
}
