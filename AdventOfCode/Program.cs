// See https://aka.ms/new-console-template for more information

using AdventOfCode.Jours;
using AdventOfCode;

Jour_abs jour = new Jour_23();

Console.WriteLine("Part 1 : " + jour.Partie1().ToString().PadLeft(15));
Console.WriteLine("Part 2 : " + jour.Partie2().ToString().PadLeft(15));