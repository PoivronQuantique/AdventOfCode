
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Jours
{
    public class Jour_13 : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Propriétés
        private List<Grid> Grids { get; set; } = new List<Grid>();
        #endregion

        #region Constructeur
        public Jour_13(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "######..#....#.\r\n######.#.#.####\r\n##..###.##.#..#\r\n......######.#.\r\n#....###...##.#\r\n.#..#.###.#.##.\r\n.#..#..##.#.##.\r\n\r\n#.#....##....#.#.\r\n#.#....##....#.#.\r\n##.##.####.##.###\r\n.....#....#......\r\n#####.####.######\r\n.###...##...###.#\r\n..####....####...\r\n.#####....#####.#\r\n.##...#..##..##..\r\n#.####....####.#.\r\n.#....####....#.#\r\n..##........##...\r\n.#.###....###.#.#\r\n\r\n#########..##\r\n.####..#.##.#\r\n.#..#....##..\r\n..##..#.#..#.\r\n.......#.##.#\r\n.####.#.#..#.\r\n..##...#....#\r\n......#..##..\r\n#...###..##..\r\n\r\n#..#..#.###\r\n###....####\r\n##..##.#.#.\r\n##..##.#.#.\r\n###....####\r\n#..#..#.###\r\n##.##..##.#\r\n#...#.....#\r\n...##.###.#\r\n####.#.##..\r\n.#.###.#...\r\n####..#...#\r\n#.#.#####..\r\n#.#.#####..\r\n####..#....\r\n.#.###.#...\r\n####.#.##..\r\n\r\n####....####.#...\r\n#.#.#..#.#.#.#...\r\n...#....#....#.##\r\n.#.#.####.#.###..\r\n#.##.##.##.##.#..\r\n####....#######..\r\n.##########.##...\r\n...##..##....####\r\n##...##...##.####\r\n.##########..####\r\n.#.##..##.#..#.##\r\n.#........#.#.###\r\n.##.####.##.#..##\r\n\r\n####..##..#####\r\n#.#..#..#..#.##\r\n.##..#..#..##..\r\n.#..#....#..#..\r\n..#.#.##.#.#...\r\n..#.#.##.#.#...\r\n.##..#..##.##..\r\n\r\n#....##....##..\r\n##..#..#..####.\r\n##........####.\r\n...##..##......\r\n###..##..######\r\n..##.##.##....#\r\n###..##..######\r\n.##########..##\r\n##..####..####.\r\n..###..###....#\r\n..########....#\r\n..#............\r\n#.#..##..#.##.#\r\n####....#######\r\n....####.......\r\n\r\n##.##.###########\r\n#..#..###.#..#.##\r\n##..#.##...##.#.#\r\n..##.###...##...#\r\n#.###.#..######..\r\n##.##...#.####.#.\r\n##.##...#.####.#.\r\n#.###.#..######..\r\n..##.###...##...#\r\n\r\n#..##..##..##\r\n#..##..#..##.\r\n#.#..#.#.##..\r\n#......##.##.\r\n#......##.##.\r\n#.#..#.#.##..\r\n#..##..#..#..\r\n#..##..##..##\r\n.#....#.#..#.\r\n\r\n.##..####.###.##.\r\n#..######.##...##\r\n#..#.##.#..##.#.#\r\n####...####.#..##\r\n####.#...##.####.\r\n#..#.#.#......##.\r\n#####.###.##..#.#\r\n#####.###.##..#.#\r\n#..#.#.#......##.\r\n####.#...##.####.\r\n####...####.#..##\r\n#..#.##.#..##.#.#\r\n#..######.##...##\r\n.##..####.###.##.\r\n.##.##.##..##.###\r\n.......#.#....#.#\r\n#...#....##..#...\r\n\r\n.##.#.##.\r\n.##.#.##.\r\n##.....##\r\n..###...#\r\n###.##.#.\r\n.#...##..\r\n.#...#...\r\n\r\n...#.....\r\n........#\r\n#..##..##\r\n###..###.\r\n###..###.\r\n#..##..##\r\n........#\r\n\r\n..####.....######\r\n#.####.######.##.\r\n###..####...#.##.\r\n..#..#..#.#######\r\n...##......######\r\n..#..#...#####..#\r\n#.####.####.#....\r\n.##..##..###..##.\r\n#########.##.###.\r\n##....##.########\r\n..#..#...#...####\r\n\r\n########..#.#\r\n....#.##...#.\r\n.##.....#..##\r\n.##....#.#.#.\r\n####.###.#.#.\r\n####..###.#..\r\n#..#.#.#...##\r\n.##..#.#.#..#\r\n#..#.##..##..\r\n#..#.#.#...#.\r\n#..#.##..#..#\r\n....##.....#.\r\n....####.###.\r\n....####.#.#.\r\n....##.....#.\r\n#..#.##..#..#\r\n#..#.#.#...#.\r\n\r\n#.##..##.###...\r\n.###..###.##.##\r\n###.##.###.#...\r\n#.#....#.####..\r\n#...##...###..#\r\n#...##...###...\r\n#.#....#.####..\r\n###.##.###.#...\r\n.###..###.##.##\r\n#.##..##.###...\r\n#.##..##.#.####\r\n.#.####.#.#....\r\n###....######.#\r\n\r\n.####.##.##\r\n#.#..#..#..\r\n#.#..#..#..\r\n.####.##.##\r\n...#.......\r\n##.#......#\r\n.##.######.\r\n\r\n.#..##...###..#\r\n.########..#.#.\r\n###.##....##.##\r\n...#####...##.#\r\n.#.#.#.#.#..##.\r\n.#.#.#.#.#..##.\r\n...#####...##.#\r\n###.##....##.##\r\n.########..#...\r\n.#..##...###..#\r\n..##..#...###.#\r\n..##..#...###.#\r\n.#..##...###..#\r\n\r\n...#.#.\r\n...#..#\r\n.#..##.\r\n##.#.#.\r\n####..#\r\n.###..#\r\n.##...#\r\n####..#\r\n##.#.#.\r\n.#..##.\r\n...#..#\r\n...#.#.\r\n####...\r\n####...\r\n...#.#.\r\n...#..#\r\n.#..##.\r\n\r\n#.###..#..#..###.\r\n...#.###..###.#..\r\n..#..#.#..#.#..#.\r\n...##.#.##.#.##..\r\n...##.#.##.#.##..\r\n..#..#.#..#.#..#.\r\n...#.###..###.#..\r\n#.###..#..#..###.\r\n..##.#..##..#.##.\r\n.##.#.#....#.#.##\r\n.####.##..##..###\r\n#.#.#...##...#.#.\r\n#...#.##..##.#...\r\n.##...#....#...##\r\n.#...#..##..#...#\r\n.#.#...####...#.#\r\n##.#....##....#.#\r\n\r\n.###..#....#..##.\r\n.###..#....#..##.\r\n#.##..##...##.###\r\n#...##..##..##.##\r\n###..#.#..##.#.##\r\n#.#.#.##.........\r\n.###.#.##.....##.\r\n.###.#.##.....##.\r\n#.#.#.##.........\r\n.##..#.#..##.#.##\r\n#...##..##..##.##\r\n\r\n...##....#.......\r\n#..##...###..##..\r\n.##..##.#..##..##\r\n#..#.##...##....#\r\n#.##...####.#..#.\r\n#...#......######\r\n##.#...##.#.#..#.\r\n#...#.#..####..##\r\n#.#.#..##..######\r\n####....#.###..##\r\n.####..#.##......\r\n.####..#.##......\r\n####....#.###..##\r\n#...#..##..######\r\n#...#.#..####..##\r\n\r\n##...#......#..\r\n##...#......#..\r\n...#.########.#\r\n#.#..##.##.##..\r\n..###.##..##.#.\r\n.#..#..#..#..#.\r\n###.##.####.##.\r\n#...#...##...#.\r\n..###.#....#.##\r\n\r\n#.#####\r\n..#####\r\n#.###.#\r\n#..###.\r\n#..##.#\r\n.##..#.\r\n..#...#\r\n.....##\r\n.....##\r\n\r\n.#.#.##..##.#.#\r\n...#........#..\r\n##...#.##.#...#\r\n.###..#..#..###\r\n##..##....##..#\r\n.#...#....#...#\r\n...####..##.#..\r\n###..######..##\r\n#...#.####.#...\r\n.#.##.#..#.##.#\r\n#.#.###..###.#.\r\n.#..#......#..#\r\n######.##.#####\r\n######.##.#####\r\n.#..#......#..#\r\n#.#.###..###.#.\r\n.#.##.#..#.##.#\r\n\r\n..#....######...#\r\n..####...##..#..#\r\n.##.###.##.###...\r\n#.#.....#....#.#.\r\n.#.#..###...###..\r\n.#....###...###..\r\n#.#.....#....#.#.\r\n.##.###.##.###...\r\n..####...##..#..#\r\n..#....######...#\r\n.#.###.###..#####\r\n.#.###.###..#####\r\n..#....######...#\r\n..####...##..#..#\r\n.##.###.##.###...\r\n\r\n##.###..#.##.\r\n##..#.#...#.#\r\n##..#.##..#.#\r\n##.###..#.##.\r\n#####.##.#.##\r\n###....##.#.#\r\n.......#...##\r\n##.##.#######\r\n###..#...#.##\r\n.......##.##.\r\n..#.##.##..#.\r\n\r\n#.###..#..#.####.\r\n......#.##.#....#\r\n.##..#..#.......#\r\n.#######...#....#\r\n##.....#..##..##.\r\n#..#....#######.#\r\n##..#.....###...#\r\n##..#.....###...#\r\n#..#....#######.#\r\n##.....#..##..##.\r\n.#######...#....#\r\n.##..#..#...#...#\r\n......#.##.#....#\r\n#.###..#..#.####.\r\n#.###..#..#.####.\r\n......#.##.#....#\r\n.##..#..#...#...#\r\n\r\n###.#.#\r\n...####\r\n##....#\r\n##...##\r\n...#...\r\n...#..#\r\n#..####\r\n..##.##\r\n###.#..\r\n..#.#.#\r\n...##..\r\n####.#.\r\n..#.##.\r\n..#.#.#\r\n..#.#.#\r\n\r\n##.#.###..##...#.\r\n.#..##...#..##...\r\n.###...##.#.####.\r\n#.#.##.#..###..##\r\n.###.#...##..###.\r\n.###.#...##..###.\r\n#.#.##.#..###..##\r\n.###...##.#.####.\r\n.#..##...#..##...\r\n##.#.###..##...#.\r\n.#..#....#...####\r\n###..####.#.#...#\r\n.###.##.#..######\r\n#..##...#####.###\r\n#..##...#####.#.#\r\n\r\n#....##..####.##.\r\n#....##..####.##.\r\n.#...#.....#.#..#\r\n...#...#####.##.#\r\n..##..##.###..##.\r\n#...###..##..####\r\n#...###..##..####\r\n..##..##.###..##.\r\n...#...#####.##.#\r\n.#...#....##.#..#\r\n#....##..####.##.\r\n\r\n#####..##.###\r\n#####..##.###\r\n###...##.#.#.\r\n#..##..#..#..\r\n##.#.#..#####\r\n##.###...#.##\r\n..#..###.##..\r\n..#.#...#####\r\n#########...#\r\n..##..##..#..\r\n..###.##.#..#\r\n\r\n..#####.##.\r\n.###.######\r\n..#..#..##.\r\n#####.#####\r\n#####.#####\r\n..#..#..##.\r\n.###.######\r\n..##.##.##.\r\n##.###.....\r\n#.#####.##.\r\n#.#........\r\n\r\n...#####.....\r\n...#####.....\r\n#....#.###..#\r\n#######...##.\r\n..##.#..##..#\r\n###......####\r\n..#.##.##..#.\r\n.##..###..#..\r\n.##..###..#..\r\n..#.##.###.#.\r\n###......####\r\n\r\n.###....###..\r\n...#.##.#...#\r\n##..#..#..###\r\n##..#..#..###\r\n...#.##.#...#\r\n.###....###..\r\n..###..###...\r\n##.######.###\r\n##...##...##.\r\n#...####...#.\r\n..#......#...\r\n##.####.#.##.\r\n##.##..##.###\r\n\r\n##..##.#.##..\r\n.#..#.#...#.#\r\n..##..#######\r\n..##..#######\r\n.#..#.#...#.#\r\n##..##.#..#..\r\n..##..#.#.###\r\n.####.##.#.##\r\n#....######..\r\n......###.#..\r\n.####.##..#..\r\n.####.....###\r\n#.##.#...#.#.\r\n#.##.####..#.\r\n#....##.#.#..\r\n######..####.\r\n.####....####\r\n\r\n##..####..##.#..#\r\n.####.#.###..####\r\n.#..#.##....##..#\r\n.####..#...###..#\r\n..##..#....#..##.\r\n..##..##.#.##.##.\r\n#....##...#..#..#\r\n..#....#.#....##.\r\n..##..#....######\r\n########.#..#####\r\n#######.##.###..#\r\n..##..#...#..####\r\n##..###.#..#..##.\r\n\r\n......##.....\r\n......##.....\r\n####.##.#.#.#\r\n.......#.####\r\n.##.##..#.###\r\n.#....###....\r\n#####.##.#.##\r\n###.#.##.#.##\r\n.#....###....\r\n.##.##..#.###\r\n.......#.####\r\n####.##.#.#.#\r\n......##.....\r\n\r\n..#..#..#..#...\r\n.##.##..##.##..\r\n##.##....##.###\r\n....#....#.....\r\n#............##\r\n...###...##....\r\n####......#####\r\n#...#....#...##\r\n...########....\r\n#.##.####.##.##\r\n##.#.####.#.###\r\n\r\n.#..######..#..##\r\n##..##..##..###..\r\n##..##..##..###..\r\n.#..######..#..##\r\n..#........#..#.#\r\n#.###.##.###.#..#\r\n#.#.######.###...\r\n\r\n###.#######....##\r\n######.#...####..\r\n##...#..#.#.##...\r\n####.#.##########\r\n##.####....#..#..\r\n##.....##.#.##.#.\r\n.######..##.##.##\r\n...####.###....##\r\n...#.##..........\r\n##..#....#.#..#.#\r\n##..#....#.#..#.#\r\n...#.##..........\r\n...####.###....##\r\n.######..##.##.##\r\n##.....##.#.##.#.\r\n##.####....#..#..\r\n####.#.##########\r\n\r\n.#...####...#.#.#\r\n##..#.##.#..##.#.\r\n.##...##...##.#..\r\n..###....###..#..\r\n#.#........#.#.##\r\n..#..####..#..#..\r\n..............###\r\n..............###\r\n..#..####..#..##.\r\n#.#........#.#.##\r\n..###....###..#..\r\n.##...##...##.#..\r\n##..#.##.#..##.#.\r\n\r\n..##.#..#\r\n###...##.\r\n..#.#####\r\n.##.##..#\r\n#........\r\n##..#.##.\r\n#........\r\n##..#.##.\r\n#...#.##.\r\n\r\n..#.##..###\r\n#.##.#.##..\r\n...##.#....\r\n...####....\r\n#.##.#.##..\r\n..#.##..###\r\n#..##.##.##\r\n.#.#...#.##\r\n##.##.#....\r\n#..#...#...\r\n##.#..#.#..\r\n..#.#..#.##\r\n##.#.##.#..\r\n\r\n#.....#\r\n#...#..\r\n#...#..\r\n#.....#\r\n.##.###\r\n.####..\r\n#.##.#.\r\n##..##.\r\n##..##.\r\n####.#.\r\n.####..\r\n.##.###\r\n#.....#\r\n\r\n........###..\r\n#..##..#.##..\r\n.######....##\r\n......#..##..\r\n#..##..#.#...\r\n###..####....\r\n#.#..#.##..##\r\n#.####.#.####\r\n##.##.##.##..\r\n.##..##...###\r\n##.##.##.#...\r\n###..####.#..\r\n.##..##.#....\r\n\r\n.####.#######\r\n..##..#.##...\r\n##..##.......\r\n##..##..#.#..\r\n.####..##....\r\n.####.##.##..\r\n.####.##.....\r\n#....##...#..\r\n#....#.##.#..\r\n...#..#.#....\r\n#.##.###.#.##\r\n\r\n#......##\r\n.#....#.#\r\n#.#....##\r\n..#..#...\r\n..####...\r\n..####...\r\n.#.##.#.#\r\n.#.##.#.#\r\n..####...\r\n\r\n##.#..##.\r\n..###.##.\r\n..###.##.\r\n##.#..##.\r\n..#...##.\r\n#...##..#\r\n#.#.##.##\r\n\r\n..##..##.#.###.\r\n.###..##.#.###.\r\n###...#.###..##\r\n#######.#...##.\r\n######.......##\r\n#..######...###\r\n.#..###.###.#..\r\n..#.##.##.#.##.\r\n.###.##..##.###\r\n.####.######..#\r\n.####.######..#\r\n.###.##..##.###\r\n..#.##.##.#.##.\r\n\r\n#.#...##..##...#.\r\n.....##.##.##....\r\n.##...######...##\r\n.##...######...##\r\n.....##.##.##....\r\n#.#...##..##...#.\r\n#####..#..#..####\r\n.....#.####.#....\r\n..##..#.##.#..##.\r\n####.########.###\r\n###.##......##..#\r\n...##..#..#..##..\r\n#.#.###....###.#.\r\n.##.###....###.##\r\n.##.#.##..##.#.##\r\n.#.#..#....#..#.#\r\n....#.#.##.#.#...\r\n\r\n#.##.#...#.##..##\r\n.....######....##\r\n#.##.###....##.##\r\n###...##.##.##.##\r\n.#...##..#.....#.\r\n#####.#.##.#..###\r\n#.#####.#..#.#.##\r\n#.....##..####...\r\n..#.###.....#####\r\n#.....#.#####....\r\n#.#.##.#.###.#.##\r\n#.#.##.#.###.#.##\r\n#.....#.#####....\r\n..#.###.....#####\r\n#.....##..####...\r\n#.#####.#..#.#.##\r\n#####.#.##.#..###\r\n\r\n###.#..###.#...#.\r\n##.#.#...####...#\r\n##.#.#...####...#\r\n###.#..###.#.#.#.\r\n.####.##..#.##.#.\r\n#.##.###..#.#####\r\n..#..########..##\r\n#.####.....#.##.#\r\n...###..##.####..\r\n..#...#....#...##\r\n..#####...#####..\r\n..#####...#####..\r\n..#...#....#...##\r\n...###..##.####..\r\n#.####.....#.##.#\r\n\r\n#..............\r\n#...##......##.\r\n..###..#..#.###\r\n##...##....##..\r\n.#.#...#..#...#\r\n.####.######.##\r\n..#...##..##...\r\n..#.##.#..#.##.\r\n#..##..####..##\r\n#..##..####..##\r\n..#.##.#..#.##.\r\n..#...##..##...\r\n.####.######.##\r\n\r\n#..###.#.#..#\r\n####.##.####.\r\n#..######.###\r\n#####...#..#.\r\n..#..#...#.##\r\n.......#####.\r\n######..#...#\r\n#..###.##.#..\r\n######.######\r\n....##..#.##.\r\n....##..#.##.\r\n######.######\r\n#..###.##.#..\r\n######..#...#\r\n.......#####.\r\n\r\n.###.##..#.\r\n.###.##..##\r\n.#...##...#\r\n.##.###....\r\n.##.###....\r\n.#...##...#\r\n.###.##..##\r\n.###.##..#.\r\n#....#..###\r\n#.#.##..#..\r\n.##.#......\r\n#...#...###\r\n###..###..#\r\n....###.##.\r\n.#..##.##.#\r\n\r\n#.#....##..#.#.\r\n#.#....##..#.#.\r\n#...#######...#\r\n##.##........#.\r\n...#.###...#.##\r\n####.....#.#.#.\r\n..#####.##..#..\r\n..#####.##..#..\r\n####.....#.###.\r\n...#.###...#.##\r\n##.##........#.\r\n#...#######...#\r\n#.#....##..#.#.\r\n\r\n...##.###..\r\n##....#.#.#\r\n...#.#.#.#.\r\n.#.##.##...\r\n#..##.#..#.\r\n######.#.##\r\n######.#.##\r\n#.###.#..#.\r\n.#.##.##...\r\n...#.#.#.#.\r\n##....#.#.#\r\n...##.###..\r\n#.###..#.#.\r\n..#..###.#.\r\n#..#..###..\r\n#..#..###..\r\n..#..###.#.\r\n\r\n.##.#..#.\r\n.#.##..#.\r\n..##....#\r\n##.#####.\r\n.#.....#.\r\n#.###.#.#\r\n#.###.#.#\r\n.#.....#.\r\n##.#####.\r\n..##....#\r\n.#.#...#.\r\n.##.#..#.\r\n..####.#.\r\n.#.#.##.#\r\n.#.#.##.#\r\n\r\n####...#....#...#\r\n.##..####..####..\r\n####....#.......#\r\n....##..####..##.\r\n....###......###.\r\n#..##..#.##.#..##\r\n....#.#......#.#.\r\n#..#.#.##..##.#.#\r\n.....##.#..#.##..\r\n\r\n..##.#......#.##.\r\n...#.#.#..#.#.#..\r\n###....#..#....##\r\n##.#.#......#.#.#\r\n#####...##...####\r\n##.#..#.##.#..#.#\r\n..#..##....##..#.\r\n###.#.######.#.##\r\n..###.######.###.\r\n..###.######.###.\r\n...#...#..#...#..\r\n###..#......#...#\r\n..#####....#####.\r\n##....#.##.#....#\r\n...#..######..#..\r\n..#.##......##.#.\r\n##.#####..#####.#\r\n\r\n####..#......#.#.\r\n#..#...#...#..#..\r\n....##..#.###.###\r\n......#..###.#..#\r\n#####.....##....#\r\n#..#..#.####.#.#.\r\n#..###...#.....#.\r\n#..##.#.#.#..####\r\n#..##.#.#.#..####\r\n#..###...##....#.\r\n#..#..#.####.#.#.\r\n\r\n#.##.#....#..#...\r\n###....###.######\r\n..###....######..\r\n.#.#..#.#......#.\r\n..########.##.###\r\n..########.##.###\r\n.#.#..#.#......#.\r\n\r\n..####...#......#\r\n...##....#...####\r\n#.#..#.#.##..####\r\n...##.....##.#...\r\n...##...#.#.#....\r\n##########..#....\r\n#..##..##.#...###\r\n.#....#.##...##..\r\n##....##...#.##..\r\n\r\n....#####.#.##.#.\r\n#....##.#.#.##..#\r\n##...#.....##..#.\r\n#..##..###...#..#\r\n#..##..###...#..#\r\n##...#.....##..#.\r\n#....##.#.#.##..#\r\n....#####.#.##.#.\r\n#..#.#..#..#.#.#.\r\n.#.#.....#.#..###\r\n#.#.#.#####.##.#.\r\n#.#.#.#####.##.#.\r\n.#.#.....#.#..###\r\n#..#.#..#..#.#.#.\r\n....#####.#.#..#.\r\n\r\n#####.#..##\r\n..###.#..##\r\n..###.#..##\r\n#####.#..##\r\n##..#......\r\n..###..#..#\r\n##.#.#..#.#\r\n#...##.##.#\r\n..####.#.#.\r\n###...#.#.#\r\n..#..##....\r\n##...##..#.\r\n..#.####...\r\n##..#.#.###\r\n..#.#.##...\r\n\r\n####.#.#.###.#.\r\n....#.#.######.\r\n....#.#.######.\r\n####.#.#.###.#.\r\n##.##..###.#...\r\n#..#.###.....#.\r\n#.#######..####\r\n.#.##.#...#..#.\r\n#..####.......#\r\n.##############\r\n#.#....#.###.#.\r\n#.#....#.###.#.\r\n.#########.####\r\n#..####.......#\r\n.#.##.#...#..#.\r\n\r\n.#.....#..#..\r\n#.#.#.#..##..\r\n.#####.#..###\r\n#.#....#.#...\r\n#.##...###...\r\n#.##...###...\r\n#.#......#...\r\n\r\n#.#..#......##..#\r\n..#..#..#..#..##.\r\n#.......#.###....\r\n##.###.###...#..#\r\n####..###.####..#\r\n...###.......####\r\n###..#..#...#####\r\n###..#..#...#####\r\n...###.......####\r\n####..###.####..#\r\n##.##..###...#..#\r\n\r\n...#..##.#.\r\n...#..##.#.\r\n#..#.#..#..\r\n...#.###.##\r\n##..#...##.\r\n###....#...\r\n#.#.#..###.\r\n.#..###....\r\n.#..###....\r\n#.#.#..###.\r\n###....#...\r\n##..#...##.\r\n...#.###.#.\r\n#..#.#..#..\r\n...#..##.#.\r\n\r\n...#####.##.#\r\n#.##.........\r\n#.##.........\r\n...#####.##.#\r\n.#######....#\r\n##.#..#..##..\r\n....##...##..\r\n..#.##..#..#.\r\n.###.##......\r\n.#..###......\r\n...#.#.##...#\r\n\r\n.#..#...#.##.\r\n...#####.#..#\r\n...#####.#..#\r\n.#..#...#.##.\r\n#...####.####\r\n......#..#.##\r\n.##..#.#..##.\r\n#.#.#.##..#..\r\n#.#.#.##..#..\r\n.##..#.#..##.\r\n......#..#.##\r\n#...####.####\r\n....#...#.##.\r\n\r\n##....#.##.#.\r\n.........#.##\r\n##.#...#....#\r\n##.#...#....#\r\n.........####\r\n##....#.##.#.\r\n####.##...#.#\r\n...#.....###.\r\n..#######.#..\r\n\r\n#.###.##.###.##\r\n###...##...#.##\r\n.....#..#......\r\n#..#......#..##\r\n##.########.###\r\n#...#.##.#...##\r\n##.###..###.###\r\n.##.##..##.##..\r\n###.#....#.####\r\n\r\n..###.##.##..\r\n..#........#.\r\n##...####...#\r\n...#.####.#..\r\n....##..##...\r\n..##.####.##.\r\n...#..##..#..\r\n##...#..#...#\r\n##.#......#.#\r\n\r\n......#\r\n..#..#.\r\n####...\r\n###.###\r\n..##.##\r\n..#..#.\r\n..###.#\r\n##..###\r\n##..###\r\n..###.#\r\n..##.#.\r\n\r\n...##....##..\r\n...##....##..\r\n..####..####.\r\n####......###\r\n#..#.#..#.#..\r\n#.#.##..##.#.\r\n.############\r\n###...##..###\r\n##.########.#\r\n#.#..#..#..#.\r\n#.####..####.\r\n#.#.######.#.\r\n.#.##.##.##.#\r\n.#...####...#\r\n##..##..##..#\r\n\r\n###....\r\n###....\r\n#.###.#\r\n###....\r\n..##..#\r\n.######\r\n#.#.##.\r\n##..##.\r\n.#.....\r\n\r\n####..#\r\n####..#\r\n...####\r\n....##.\r\n...#..#\r\n.##....\r\n.#.....\r\n#.##..#\r\n##.#..#\r\n.#.####\r\n.##..#.\r\n##.....\r\n.#..##.\r\n#.##..#\r\n.##....\r\n##.....\r\n..#####\r\n\r\n##....##.#.###.\r\n....##.##.#..##\r\n.#.######..#...\r\n...#.#.#.##.#..\r\n###.#..#.#..##.\r\n##.###.....#.##\r\n##.###.....#.##\r\n###.#..#.#..##.\r\n...#.#.#.##.#..\r\n\r\n...#.#..#\r\n###.#.#.#\r\n###.####.\r\n.....##.#\r\n.#.###...\r\n.#.###..#\r\n.....##.#\r\n###.####.\r\n###.#.#.#\r\n...#.#..#\r\n.##..#.#.\r\n.##..#.#.\r\n...#.#..#\r\n\r\n.#.#.##.#....\r\n###..##..#.##\r\n#.....###....\r\n#..##..#.....\r\n#..####.##...\r\n###..####.#..\r\n###..####.#..\r\n#..####.##...\r\n#.###..#.....\r\n\r\n#######..#..##.#.\r\n#####.#..#..##.#.\r\n##...####...###..\r\n..####.#.#..##...\r\n###.#######....##\r\n..#.###.#.#.#..#.\r\n...#.###.####.#..\r\n\r\n#.######.##\r\n.#......#.#\r\n.#......#.#\r\n#.######.##\r\n#.##..##.#.\r\n.##.##.##..\r\n#######.##.\r\n..######..#\r\n##..##..###\r\n.########..\r\n#.######.##\r\n##.####.##.\r\n...#..#....\r\n#.######.#.\r\n..##..##...\r\n\r\n#........##\r\n.#.#.#.....\r\n.#...#.....\r\n#........##\r\n##.##..##..\r\n.#..#..##..\r\n##.#.#...##\r\n#.#..###...\r\n#.#.#.##...\r\n\r\n.##...#.###..\r\n.#..###...#..\r\n..##.#.##....\r\n.#..#.##.####\r\n...#...#.#.##\r\n.#.##.###.###\r\n#.###......##\r\n#...###..#.##\r\n.###.##.##.##\r\n#.###.#.#..##\r\n#.###.#.#..##\r\n.###.##.##.##\r\n#...###.##.##\r\n\r\n####..###.#\r\n......###.#\r\n.....#.....\r\n.....#..#.#\r\n....#####..\r\n.##...##.##\r\n....######.\r\n####.##.#..\r\n#######...#\r\n.##.###..##\r\n.##.####.##\r\n.......#.##\r\n#####...###\r\n#######..##\r\n#####..#.##\r\n####..#...#\r\n####..#..##\r\n\r\n.....#.####.#\r\n#.###..#..#..\r\n##.#.#..##..#\r\n#.#.##.#..#.#\r\n.....###..##.\r\n####..#.##.#.\r\n.##..########\r\n.##..########\r\n####..#.##.#.\r\n\r\n#....######\r\n#....####.#\r\n#....#..#.#\r\n##..####...\r\n.####......\r\n..##.....#.\r\n.......##.#\r\n......#...#\r\n#.##.##.##.\r\n......#.#..\r\n.####..#..#\r\n\r\n...#...#..#....#.\r\n#...##..#..##.#..\r\n###.####.#..##..#\r\n###.##.##.######.\r\n...#.###.#......#\r\n#..###.#..##..##.\r\n#..###.#..##..##.\r\n\r\n#########.#..##\r\n..#....#.#.#.#.\r\n#.#.#.###...#..\r\n#....##.#.#..##\r\n#.....#.#.#..##\r\n#.#...###.#...#\r\n..####..#.#...#\r\n..####..#.#...#\r\n#.#...###.#...#\r\n#.....#.#.#..##\r\n#....##.#.#..##\r\n\r\n..##...\r\n...##.#\r\n...##.#\r\n..##...\r\n..#...#\r\n...#...\r\n##...#.\r\n....#.#\r\n..###..\r\n#####..\r\n..###..\r\n....###\r\n.#.##..\r\n...#...\r\n####...\r\n\r\n##....######..#\r\n.#....#.##.#..#\r\n########.###..#\r\n.##...#..#.....\r\n.##..##.##.####\r\n.######.##.#..#\r\n#..##..#...####\r\n##.##.#####.##.\r\n.#....#.##.#..#\r\n#......###.####\r\n#.#..#.#.#..##.\r\n###..###..#.##.\r\n#########.#.##.\r\n\r\n#.#####.#..####..\r\n...###.....#..#..\r\n#...#..##...##...\r\n####.##.#.##..##.\r\n#########.##..##.\r\n#...#..#.########\r\n#..##..#.########\r\n\r\n..#####\r\n..##...\r\n#..#.##\r\n#.#.###\r\n.#..#..\r\n....###\r\n.#.#.#.\r\n....#..\r\n#..####\r\n.##..##\r\n.##..##\r\n#..####\r\n....#..\r\n\r\n###..#.##\r\n#.###.#.#\r\n#.###.#.#\r\n###..#.##\r\n.#.#.###.\r\n.#.###.##\r\n.#####.##\r\n\r\n#####.#.##...\r\n#..##...##...\r\n.##..#......#\r\n......#.##.#.\r\n####..######.\r\n....#.######.\r\n.##...#....#.\r\n.##.#........\r\n#######....##\r\n#######....##\r\n####.#..##..#\r\n#..#.###..###\r\n#####.#.##.#.\r\n####.#.#..#.#\r\n#..####.##.##\r\n\r\n####..#####\r\n#.#.##.#.#.\r\n###....###.\r\n###....###.\r\n#.#.##.#.#.\r\n####..#####\r\n#..#..#..#.\r\n#.##..##.##\r\n...####....\r\n######.###.\r\n##..##..###\r\n..#.##.#..#\r\n#.#.##.#.##\r\n####..####.\r\n#.##..##.#.\r\n.###..###.#\r\n#..#..#..#.\r\n\r\n#....#.##..##\r\n........#..#.\r\n......####.#.\r\n......####.#.\r\n........#..#.\r\n#....#.##..##\r\n#.##.##.##.##\r\n#....#..#....\r\n#.##.##..#.#.\r\n##.#####.#.##\r\n..##........#\r\n......##.##.#\r\n#....#.#..###\r\n\r\n##..#...#\r\n##..#..##\r\n#..#.###.\r\n######..#\r\n#.###....\r\n....#....\r\n....#....\r\n#.###....\r\n######..#\r\n\r\n........#....##.#\r\n.####...#....#.#.\r\n..##..####.#.##.#\r\n##..##.....##..#.\r\n###.##..#######..\r\n.#..#.....####.##\r\n.#..#.....####.##";
            //InputData = "";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);

            InitialisationGrids();

            if (this.Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail ligne à ligne.
        /// </summary>
        private void InitialisationGrids()
        {
            List<string> TempData = new List<string>();
            foreach (string ligne in Lines)
            {
                if (string.IsNullOrEmpty(ligne))
                {
                    if (TempData.Count > 0)
                    {
                        Grids.Add(new Grid(TempData));
                        TempData.Clear();
                    }
                }
                else
                {
                    TempData.Add(ligne);
                }
            }
            if (TempData.Count > 0)
            {
                Grids.Add(new Grid(TempData));
                TempData.Clear();
            }
        }
        #endregion

        #region Méthodes publiques
        public override long Partie1()
        {
            return ProcessPart1();
        }

        public override long Partie2()
        {
            return ProcessPart2();
        }
        #endregion

        #region Process
        private long ProcessPart1()
        {
            return Grids.Sum(g=>g.Summary);
        }
        private long ProcessPart2()
        {
            Grids.ForEach(g => g.FindSmurges());
            return Grids.Sum(g => g.SummaryApresSmurge);
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail
        private class Grid : List<Dot>
        {
            #region Propriétés
            public List<string> Cols {  get; private set; }
            public List<string> Rows {  get; private set; }

            private List<Tuple<int, int>> AxesSymetriesV { get; set; }
            private List<Tuple<int, int>> AxesSymetriesH { get; set; }
            private long? SummaryV { get; set; } = null;
            private long? SummaryH { get; set; } = null;
            public long Summary
            {
                get
                {
                    if (!SummaryH.HasValue)
                        SummaryH = GetAxesSymetrie(false).Sum(r => r.Item2 * 100);
                    if (!SummaryV.HasValue)
                        SummaryV = GetAxesSymetrie(true).Sum(r => r.Item2);
                    return SummaryH.Value + SummaryV.Value;
                }
            }

            public List<Tuple<int, int, int>> ColsOneDifference { get; private set; } = new List<Tuple<int, int, int>>();
            public List<Tuple<int, int, int>> RowsOneDifference { get; private set; } = new List<Tuple<int, int, int>>();

            private List<Tuple<int, int>> Smurges { get; set; }

            private bool Smurge { get; set; } = false;
            public List<string> ColsApresSmurge { get; private set; }
            public List<string> RowsApresSmurge { get; private set; }

            private List<Tuple<int, int>> AxesSymetriesVApresSmurge { get; set; }
            private List<Tuple<int, int>> AxesSymetriesHApresSmurge { get; set; }
            private long? SummaryVApresSmurge { get; set; } = null;
            private long? SummaryHApresSmurge { get; set; } = null;
            public long SummaryApresSmurge
            {
                get
                {
                    if (!SummaryHApresSmurge.HasValue)
                        SummaryHApresSmurge = GetAxesSymetrie(false).Where(ashas=>!AxesSymetriesH.Exists(ash=>ash.Item1 == ashas.Item1 && ash.Item2 == ashas.Item2)).Sum(r => r.Item2 * 100);
                    if (!SummaryVApresSmurge.HasValue)
                        SummaryVApresSmurge = GetAxesSymetrie(true).Where(asvas => !AxesSymetriesV.Exists(asv => asv.Item1 == asvas.Item1 && asv.Item2 == asvas.Item2)).Sum(r => r.Item2);
                    return SummaryHApresSmurge.Value + SummaryVApresSmurge.Value;
                }
            }
            #endregion

            #region Constructeurs et initialisation
            public Grid(Grid gridBase, int xDiff, int yDiff)
            {
                this.AddRange(gridBase.Select(d => d.Clone() as Dot));
                this.Invert(xDiff, yDiff);
                InitColsAndRows();
            }

            public Grid(List<string> lines)
            {
                for(int i = 0; i < lines.Count; i ++)
                {
                    for(int j = 0; j < lines[i].Length; j ++)
                    {
                        this.Add(new Dot(j, i, lines[i][j]));
                    }
                }
                
                InitColsAndRows();

                // Pour la partie 2
                FindDifferences();
            }

            private void InitColsAndRows()
            {
                if(Smurge)
                {
                    ColsApresSmurge = this.GroupBy(d => d.X)
                                .Select(g => new { index = g.Key, val = string.Join("", g.OrderBy(u => u.Y).Select(u => u.estDiese ? "#" : ".")) })
                                .OrderBy(g => g.index)
                                .Select(g => g.val)
                                .ToList();
                    RowsApresSmurge = this.GroupBy(d => d.Y)
                                .Select(g => new { index = g.Key, val = string.Join("", g.OrderBy(u => u.X).Select(u => u.estDiese ? "#" : ".")) })
                                .OrderBy(g => g.index)
                                .Select(g => g.val)
                                .ToList();
                }
                else
                {
                    Cols = this.GroupBy(d => d.X)
                                .Select(g => new { index = g.Key, val = string.Join("", g.OrderBy(u => u.Y).Select(u => u.estDiese ? "#" : ".")) })
                                .OrderBy(g => g.index)
                                .Select(g => g.val)
                                .ToList();
                    Rows = this.GroupBy(d => d.Y)
                                .Select(g => new { index = g.Key, val = string.Join("", g.OrderBy(u => u.X).Select(u => u.estDiese ? "#" : ".")) })
                                .OrderBy(g => g.index)
                                .Select(g => g.val)
                                .ToList();
                }
            }
            #endregion

            private void Invert(int X, int Y)
            {
                this.FirstOrDefault(d => d.X == X && d.Y == Y)?.invert();
            }

            #region RechercheSymetrie
            private List<Tuple<int, int>> GetAxesSymetrie(bool vertical)
            {
                #region Lecture mémo
                if (Smurge)
                {
                    if (vertical)
                    {
                        if (this.AxesSymetriesVApresSmurge != null)
                            return this.AxesSymetriesVApresSmurge;
                    }
                    else
                    {
                        if (this.AxesSymetriesHApresSmurge != null)
                            return this.AxesSymetriesHApresSmurge;
                    }
                }
                else
                {
                    if (vertical)
                    {
                        if (this.AxesSymetriesV != null)
                            return this.AxesSymetriesV;
                    }
                    else
                    {
                        if (this.AxesSymetriesH != null)
                            return this.AxesSymetriesH;
                    }
                }
                #endregion

                List<string> ListeTravail = (vertical ? (Smurge ? ColsApresSmurge : Cols) : (Smurge ? RowsApresSmurge : Rows)).ToList();
                List<Tuple<int, int>> Res = new List<Tuple<int, int>>();

                // On regroupe les chaînes identiques
                var Groups = ListeTravail.Select((c, i) => new { index = i, val = c }).GroupBy(c => c.val).ToList();

                // On cherche les chaines identiques consécutives
                foreach( var g in Groups)
                {
                    List<int> indexs = g.Select(g1=>g1.index).ToList();
                    foreach(var i in indexs)
                        if(indexs.Contains(i+1))
                            Res.Add(new Tuple<int, int>(i, i + 1));
                }

                // On retire les chaînes identiques consécutives qui ne sont pas un axe de symétrie
                Res.RemoveAll(r => !isAxeSymetrie(r.Item1, vertical));

                #region Écriture mémo
                if (Smurge)
                {
                    if (vertical)
                        this.AxesSymetriesVApresSmurge = Res;
                    else
                        this.AxesSymetriesHApresSmurge = Res;
                }
                else
                {
                    if (vertical)
                        this.AxesSymetriesV = Res;
                    else
                        this.AxesSymetriesH = Res;
                }
                #endregion

                return Res;
            }
            private bool isAxeSymetrie(int indexMin, bool vertical)
            {
                List<string> ListeTravail = (vertical ? (Smurge ? ColsApresSmurge : Cols) : (Smurge ? RowsApresSmurge : Rows)).ToList();
                int maxi = ListeTravail.Count - 1;
                for (int i = 0; i <= Math.Min(indexMin, maxi - (indexMin + 1)); i++)
                {
                    if (!ListeTravail[indexMin - i].Equals(ListeTravail[indexMin + 1 + i]))
                        return false;
                }
                return true;
            }
            #endregion

            #region Coquilles
            /// <summary>
            /// Comparaison des colonnes et des lignes deux à deux et sauvegarde des "coquilles"
            /// </summary>
            private void FindDifferences()
            {
                for (int i = 0; i < Cols.Count - 1; i++)
                {
                    for (int j = i + 1; j < Cols.Count; j++)
                    {
                        if (Differences(Cols[i], Cols[j], out int index) == 1)
                            ColsOneDifference.Add(new Tuple<int, int, int>(i, j, index));
                    }
                }
                for (int i = 0; i < Rows.Count - 1; i++)
                {
                    for (int j = i + 1; j < Rows.Count; j++)
                    {
                        if (Differences(Rows[i], Rows[j], out int index) == 1)
                            RowsOneDifference.Add(new Tuple<int, int, int>(i, j, index));
                    }
                }
            }
            /// <summary>
            /// Compte le nombre de caractères différents entre deux chaînes et indique l'index de la dernière différence
            /// </summary>
            /// <param name="s1">Chaîne 1 à comparer</param>
            /// <param name="s2">Chaîne 2 à comparer</param>
            /// <param name="indexLastDiff">Index de la dernière différence entre les chaînes. -1 en cas d'égalité</param>
            /// <returns>Nombre de différences</returns>
            private int Differences(string s1, string s2, out int indexLastDiff)
            {
                int nb = 0;
                indexLastDiff = -1;
                for(int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    { 
                        nb++;
                        indexLastDiff = i;
                    }
                }
                return nb;
            }

            /// <summary>
            /// Parmi toutes les colonnes / lignes n'ayant d'un caractère de différence, on vérifie si le changement de caractère génère un nouvel axe de symétrie, et on ajoute les coordonnées de ce caractère en tant que Smurge
            /// </summary>
            public void FindSmurges()
            {
                List<Tuple<int, int>> ValidesV = new List<Tuple<int, int>>();
                List<Tuple<int, int>> ValidesH = new List<Tuple<int, int>>();

                // On traite les colonnes identiques à 1 près
                foreach (var d in ColsOneDifference.Where(d=>(d.Item1 + d.Item2) % 2 == 1).ToList())
                {
                    Grid g = new Grid(this, d.Item1, d.Item3);
                    if(g.isAxeSymetrie((int)Math.Floor((decimal)(d.Item1 + d.Item2) / 2), true)) 
                    {
                        ValidesV.Add(new Tuple<int, int>(d.Item1, d.Item3));
                    }
                }

                // On traite les lignes identiques à 1 près
                foreach (var d in RowsOneDifference.Where(d=>(d.Item1 + d.Item2) % 2 == 1).ToList())
                {
                    Grid g = new Grid(this, d.Item3, d.Item1);
                    if(g.isAxeSymetrie((int)Math.Floor((decimal)(d.Item1 + d.Item2) / 2), false)) 
                    {
                        ValidesH.Add(new Tuple<int, int>(d.Item3, d.Item1));
                    }
                }

                Smurges = ValidesV.Union(ValidesH).ToList();

                this.Invert(Smurges[0].Item1, Smurges[0].Item2);

                Smurge = true;

                InitColsAndRows();

                return;
            }
            #endregion
        }

        private class Dot : ICloneable
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public bool estDiese { get; private set; } = false;
            private Dot() { }
            public Dot(int x, int y, char Caract) 
            {
                X = x;
                Y = y;
                estDiese = Caract == '#';
            }
            public void invert()
            {
                estDiese = !estDiese;
            }

            public object Clone()
            {
                Dot clone = new Dot(this.X, this.Y, this.estDiese ? '#' : '.');
                return clone;
            }
        }
        #endregion
    }
}
