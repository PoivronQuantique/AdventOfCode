
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCodeCore.Jours
{
    public class Jour_14 : Jour_abs
    {
        #region Enumerables
        public enum TiltDirection
        {
            North,
            East,
            South,
            West
        }
        #endregion

        #region Propriétés
        private Grid Grille { get; set; }
        private Grid GrillePt2 { get; set; }
        #endregion

        #region Constructeur
        public Jour_14(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "..O....O....O..#O#OOOO...O..O...#.O.#.OO...O.##O#.#..#...OOO.#....O#....#...OO..O.OO..#.OOO.O..O.O.O\r\n.OO.##....#.#..#O...........##O..#..O..O.....#.O.##.O.O............#......##........#.OO..#OO..#....\r\n##........O.O.#O...##.#...#.#.O...#..#O...#....#O...OOOO..OO.OOO.O...O.#........OO.O.O....O...O##O..\r\n...O..O#..O.O..O.O..OO..#.....O..OO....O#..O.##..O..#O.#.OO....####.OOO.OO..O.#..OO.O....O...#.#.O..\r\n...#.O.OOO..#O...O#...O....O...#.O.OO.O.O...O...#...#.#O...#....#....#..O....#..O..#...#..O.....O...\r\n.OO...#...#O#....O.O#.O#.O#.OO.OO.O.O#..........O#....O........O.O.....#...O.#....#........#........\r\n.#.#.#.OOO....#.O.#....#.#..##O.........O.#OO.OO..OO#.#....##.#.##O#.#....O.#.........#...O.#O.O....\r\n..O.#.#.O.....O....O.#..#..O#.#OO..OO........#O.#OO.O..OO.O.......#...#.#..##...........O...#.O.#.#.\r\n...#....#...O....##O......O...#...#....O.#...OOO#..#..O....##.OO.......#O.#.....OO....#.###O#O#.....\r\nO..#O..O..OO.OO.O........O.##O.O...O.O##O..#....#.#..O.OO.#.....O.#......O..O#..#.O.#O.#...#O....O..\r\nOO...O.......#........O#.#.....#O.O...O.O........O.##O......OO.....#.....O#...O#.#..#...#.#O..#.....\r\nO.....O..O..O...#..O..#O#.O..O...O....O#..O...#O.....O.OO...O....O..#...O....#O..#....O..O.##....OO.\r\n.#.#..O........O...#.......O..##.O.###.O..O.....O.##O...OO....O..#..#O....O..O.O..........O...OO.O..\r\n....O..O..O........#O.#.##...##....#.#.O...#O#.O....#.O#O#O....#.O#......O##..#.O.O....#O#..OO.#..#.\r\n##....O...O###.O.....O#.OOO.O##.##....O.....O...O..O...O..#...O....##.....O........##...#.O...##O...\r\n...O....###......#...O.OO........#.#.....OOO........O.#......O.O#....O.O.....#..##..O..#.#O#..O..O#O\r\n.O..#.##O#...O.OO#...#OO.#..##.##..O.#.#O.O.#...OOOO...#.........O...........#..O.......#.##.O...##.\r\n.OOO#.......OO....O..#..#O.O.O#.#O..#....O....#.O.O..O#..#...#.O.#O.#.OO.OO..#.#O.#.O#...#O.....#..#\r\n...#O...O.O..#.O........O#.#....O.######O#...O.#.O.#..O.....#.....#...O..............#...O....##..#.\r\n.O............O#......#O##O..OO......#....OO#..#..#..#OOO...#..#.....O#OO..O.O..#.O#..OO.##...O#.#..\r\n.O...OOO.O.#........#..#..O.O.......O...#...#OO#O.....O...O......O...OO.O#.O.O#.OO.#......O.O....#O.\r\nO.##O.....OO....O..##..O....#......O...O...O....####..#.....O.....O..O.#.O..#OO.#..#..O#O..O...#...O\r\n..O...#O#...#.#..O...O#.O......O.#..#...#..#O..#...#..O.....O...OO.O#....OO.......#..###.OO..#..OOO.\r\n.#..##O..O....O...O....O..O###.O.O......O#OO#O#O#O#...#...##.O.......#OOO#.##.#.O.....O.O.OO..#...O.\r\n.O...#..O...O..O....#....O.....#O...#..O..#..#.......O...#..#....O.O#O....#....#O...OO...#.O.....OO#\r\n.#.O..O............#...#...O..........O...O##......O.#....#O..O.O#...O##O.O..#....OOO..#...OOO....O.\r\nO#O#.....O...OO##.....O#...O.....OO#.#...OO.O.O#.O.O.......#..##......O.#O.....#.O..#...#O...#...O..\r\n..O##..#....O#.......OO#O.#......OO.##.#O.O.O....O.O..#O.#.....#..O......#O#....#O#.....#........#..\r\n.O.##.#...O....#O........OOO.#O.....#.#....O..O..###....#.#..#.#O#.#.....#..#..#O##..#..OO.##.O....O\r\n.O..O.O.....O.O...O#.#...##O....O.O.O...#....#O....#.O..OO...O.#..#O#........#OO....#...#.#..O..O...\r\n...##O.O...O##....#..O...O#...#......#.OO##.....#..#.....O....#......O#.#O..O.#.O.O..O....O..O.O###O\r\n...#....O.O...O..#.O....#...##O..O..O..#...O..#OO.#..O..#OO..O.........#O....#.#..O#O.O.#.O.....##O.\r\n.......#.O.O.O..O##.............OO...O#O.O#.O..OO#.......O#...OOO.....#...O.......#.#..O#..O..OO#...\r\nO...OO#.O..O.....OO......#.O#...#O#O.O......#.#O.....#..O.#.O#..#O.O....O.......O.....OO..O#....#.O.\r\n..#...O#.O.O.O.#.O......O..#..O....#...#..O.O.#...#.....O..O....OO#OO.O.O.O..........#O..O#.O#..O...\r\n......#O.....O.....OO.O..O#..#O###..O..#OO.#OO.....O.OOO..#.O...O....#O..#OO.#O...O.O....O#.....O.##\r\nO.....O.O..#....O....##.....#.......OO#O.#...O..##...#....#.O#O..OO#.##.#.O.O.O.O#...#.OO.#O..OOOO#.\r\n...OOO.#..#OO.O...#.....O#......#..O.O..OO#.O.O#.#.#........#.O.....#..O..O..#O..#O.#..#....#..#.O..\r\n..O..O.....#.##.OO#.......O..OOO....OOO...#.O.#O...O...OO....O#OO...O.##....O.....#..O......#......O\r\n.#..O..OO#O..#.##.O.O...##OOO.#...O......#O...O..#..#..#..O........#...O..#..#.OOO#.O.O......#.##O.#\r\n#..#...O..#.O.#.....O..#.OO.#.....O.....#....O.OO.#O..#.#.#O..O....O.OO..O.......#O##..#O.#.OO...O..\r\nO...O....OO..#OOOOO##.......##....#........O..O......O#O.#.......O.#.....OO........###..#........#.O\r\nO.....O.......#OO.O.OO..O.O##.....O....O##......OO...O#O...O.....O.O....OOO#.O....#O.##...#.#..O##..\r\n..O...#.....##.#O...#.OO.O#......O...O....OO..O.##O..OO#.O.#.O.O..#..#.O.O..O...O..#.OO.O.O....O....\r\nO.OO.###.O..OO..##O....#.O......O.....O..OO......O.O.#OO...OO.#.....O#..O..#O.O........O.OO#O.OO....\r\nO.....OO.....#O..O...O.#.OO#O.O##O...OO#..##O#.O.O#OO....#.#..#...##.#...#..O.O....O..O....#O.#.O...\r\n...#.......OO.O..O......O.O.#....#..O.#.###.#......#.#O......#.#.O..O...O.#..#...#OO...O#.O....O##.O\r\n....O.#...O..#.....O.#.OO..#...O.O....O....#..#...#..........O.O..#...O#...O#.#OOO.O.O.....O#O.....O\r\n.....O...O.O...#.#....#....##.OO..#..O.O.OO...O#.O.....#..#...O...O......#.#....O..O......OO.O.O...#\r\n.O.#..#.O..O...#.O.....OOO.O.#.OOO..O.........#.OO#....#.O.....#O.....#..#...O......#.#O.O...O.OOO.O\r\nO#OO...O..#OO.OOO##..O........###..O....O#.O...O....O..#..........#...OO#O.....O.OO.O..#....O.#..#..\r\n............O.O..O#...O.#......O....#.............O......#.O..O...O.#OO...#.....O....#.O#...#OO..O.#\r\n.O.#.#O..#O...O.O..O#.O...##.#.#...O#...#..#.#OO#....#O....#......O.#O..O#O#.O....O.......#....#....\r\n#.##...#.O.......#.....OO....#O#..O#.....O.#....O.#O#..O..##.#....O.......#....#.O#.#..#..O#.#..O.O.\r\n..O..O#..O.O....O..#....O#.O##O..O..#.#OOO#O.O.##.O##O..........#.O.O#..#O.O.OO.#..OO...###O..#.O.##\r\n.......O..........##..#.#.......#.O.O..O......O.O.OO.O............OO.O.O#..##.#......##O.O#O..O.....\r\n....O......#..O..O..##O..O#.O....O..#.O.#...O.#O.O.O.O.#.#..O.....#..O.#..O#............O..#.O...#O#\r\n..O...O..#O....O.#O..O.#.O.O..O..OO##.....##OO..#..#.O#O....O...#.....O#.O.#.......#.....O#..O..O.#.\r\n.O..#...O..#.....O.#O#O....OOO..#..#.O..O.O.#......O.#OO#O..#.O#..#....O..#.O.O#......O#..##...OO..#\r\n##.#...##.O...OOO....##O.O..OO#OO.O#...O.OO........#......OO...#.#..O#.#........O....OOO..O..O..O.#.\r\n#.OOO....O......O....#.#.OO..#.....O...O.OO..O..OO.....OO........OO....O.O..#.O#.....O......#.#.#O..\r\n...O........O..O.#O...#......O...O...O.....#.O....O.........#...OO....##...O.#.O.....O...O.......#O.\r\n..O#.#O.OO#...O.O..O..OOO..........O.....#O....O......#..OO...O..O#O.#....#.O..........#O.OOO...##..\r\n#..O#...OO#.O....O#......##.#O....O..OO.OO..O....#.......O.....O..O......O#O.....O..O...#....#....O.\r\n.#....O............O.O.OO...O##O......#....O#.........OO.O#O............O##O.#....#O.O###.#O..#.....\r\nO#.....O.O..O..#.....#.#....#......#...O.OO.#OO....#..##.O..O#O...OO..#...O.#.#.O..##.#....OO.O.....\r\n#.....O......O#.#........#....O..#O.#O.OO..O.OO.O..O##.#.#.#OO....O.#....O.O..#.....#.....O.OO...OOO\r\n..OO.##OO#O.............O.OO...O#.##...#.#O...#O.....#...#.......#OOO.#.O#OO.....#..O#..#...OO....#.\r\n.#....OO.#.O##...#.O#.....OO#O...OOO..O##....OO.#.#.#......O#...O#OO....#......OOOOO#O...#..#.....O#\r\n##O.O..O.##......#.OO...#...O..#O........##.O.......O#......#..#O....O....O#O.O..##.........O.......\r\n..O.#...#OO#O....#O.....O...##.O....#..##O#........O..#..#..#...O..#.OO.#O#...O......#....#.......##\r\n.O.###......#........##.....#...#...#O.O#O..........#..O.....O.OOO#O.....#...#.OO#O.O##O.OOO........\r\n.#..O.......O....O...#.........#O##.OOO#O..#.#...O....O#O..O....#..O#..#....#O#......O#O#..#.....#.#\r\n.###O.O..OO.O..O....O#.##O.O..O..O..#O#.#O#.O....O..O#..O..####.O...#..O..#OO....OO.......#..#.O..#.\r\nO...O#...#.O....OO..##..O..O#O#.#OOO...OO...#..#....#O..#.#....#O...OO.O...O.#.O..#.#..O.O..O#.O#.#.\r\n#.O..#..O##O..OOO.O...O.OO#.#...OO.OO.......O..#.O#OO....O.#O...........#...O..O...###O#..##..#.O.#.\r\n.O.O.#.....O#...OO....#.....#.OOO.#..#O.#O.#O...#..O.....##..O#............O....O#...#.O#.....#OO.#.\r\n##O.O...OO.O.#.#O..O....#.#.O............#O..O.....O..#..#.#.O..#.......#.O.........O.OO...#..#####.\r\n.O##..####...#...........#.O..#..O#..OO........O..O...#O.##OO..#..O.O.O..#..##.O.OO#O#...#....#O.O.O\r\nO.....O.O#....O#..#...O....OOO.OO..#..#......O...OOO.....O...O#..O..........####............#.O...OO\r\nO#..O...#......#...#....#.#.O.........O...O....##O......#...O#.O.OO....#O.......#.O.O.OO.#O.#O...#OO\r\n.O.....O...#.#..O#...O#.OO##O...#..#....#.O.O....O......#.O...##..O.##.....O#.O#..OO#.#.........#...\r\nO....O.#O......O#O..OO#.#..#.OOO...#.#...#..#..OO..#........#.O..O..O##..OO#.#.O#OO.....#.O.##....O.\r\n.OO............O....OO..#.#...O.#..O.......O.O......#....O..O..O#.......#.....OOO##...#.....O...O.#.\r\n.#...O..OO.O....O...#.#...#OO#.O...#...##.O.......O.......#.....O..##O..O..OO..O#.OO..O.O...O.#...#.\r\n..OO#.#O..#OO..O#O#O.O....O..O.......OO##.O..#.#O....O.#.....O..O.O....O##.#....#.#....O..#..#..OOO.\r\n....#..O#..#...##.....#.#O.O......#....O##............#.....##O...#..O..##.#O..#O...O....O...##OO...\r\n#O...O......O.O.#.OOO.....O##...#..O..OO...#..O#...O....O.O....#..O#...OOO..#.O..O....#..##.#.O.O...\r\n##..#O#.O.#O...O#....OO...#..#.O##.O...#.O.#.O.O....O.#...O#.....####....OO.O..#.OO#....O...#..#....\r\nO#..#...##.#.###.O##..#..##OO...#O#.........O.....O.OO#..OO..O....#.O#..........#...###.#......O..#.\r\nO..#..##.O.O....OO.O#.##.O..O.#.#..#..O..OO..O...#.O.#....O#.....#OO...O.O#OO.O#.......OO#..#.O...O.\r\nO..#..O#.#....#.O....O...#.OO.....O.O...O.#.###.#.O..O.O.#.....O.#......O#.....O...O......O.#..#...O\r\n##O..#.##...#.......#.#..#.O....#.......O...O.##.O..#.O...O..##.O..#..O....O#....O.O#..O.......O.O.O\r\n#..O...O....OO..O...O.OO....#..#..#.O#....#.#..O##.#..#.#.OOO#.#.O..#..O##......O.....OO....O#.#...O\r\n#O.....O........##OO#..OO..O..O.#...O#......O..O..OO..OO....##.....#OOO.#OO.......O....O#.O...##..#.\r\n.O..OO.O.....OOO...##O....##O....#.#.#O...OO.O...#..#......O.O.O..O.O..##....O....O.O.##....OO.#O.O.\r\n..........O..O#...#...#..#..O..O...O#..O#OOO#......OOO#O..O.O.#O...O#..#O.OO..O##..O##O...O.O#.....#\r\n#...#O..O.......O.O##.OO.#.#O..O.....O...#..O..O......O...#....#..O..O....##.....#.#...O.........#..\r\n#....O.....O..O......#..#..........O..OO.#..##.....#..O...##....O.O..#.#O.#....OO.#....#.O...O...#O.\r\n.......#..#.O..#....O......OOO.#....#O#.O..O..O#O#.##.#.#.#.............#O##OO.#.#O.#....O.O.#......";
            //InputData = "";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);
            InitialisationGrille();

            if (this.Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// </summary>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationGrille()
        {
            Grille = new Grid(this.Lines);
            GrillePt2 = new Grid(this.Lines);
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
            Grille.Tilt(TiltDirection.North);
            return Grille.Weight;
        }
        private long ProcessPart2()
        {
            long nb = 0;
            // Après [offset] cycles, la grille se stabilise et donnera toujours les mêmes résultats par périodes de [reason] cycles.
            // On cherche donc la première répétition de résultat après x cycles
            Dictionary<string, List<long>> Cycles = new Dictionary<string, List<long>>();
            do
            {
                GrillePt2.Cycle();
                nb++;
                string sc = GrillePt2.ToString();
                if(Cycles.TryGetValue(sc, out var Tmp))
                {
                    Tmp.Add(nb);
                }
                else
                {
                    Cycles.Add(sc, new List<long>() { nb });
                }
            }
            while (!Cycles.Any(c=>c.Value.Count > 1));

            var Cycle = Cycles.First(c => c.Value.Count == 2);

            // De cette répétition, on déduit la première occurrence et la période
            long offset = Cycle.Value.First();
            long reason = Cycle.Value.Last() - offset;

            // Inutile alors de tilter 4000000000 de fois, il suffit de trouver quelle étape d'un cycle correspond
            long mod = (1000000000 - offset) % reason;

            for(long i = 0; i < mod; i++)
            {
                GrillePt2.Cycle();
            }

            return GrillePt2.Weight;
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail
        public class Rock
        {
            public bool isFixed { get; private set; }
            public int X { get; set; }
            public int Y { get; set; }
            private Rock(){}
            public Rock(int x, int y, char Type)
            {
                X = x;
                Y = y;
                this.isFixed = Type == '#';
            }
            public override string ToString()
            {
                return "[" + this.X.ToString() + ";" + this.Y.ToString() + "] : " + (this.isFixed ? "Fixed" : "");
            }
        }
        public class Grid : List<Rock>
        {
            private int NbCols { get; set; } = 0;
            private int NbRows { get; set; } = 0;
            public long Weight 
            {
                get
                {
                    return this.Where(r => !r.isFixed).Sum(r => r.Y);
                } 
            }
            private Grid() { }
            public Grid(List<string> lines)
            {
                NbRows = lines.Count;
                for (int i = 0; i < lines.Count; i++)
                {
                    NbCols = Math.Max(lines[i].Length, NbCols);
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        if (lines[i][j] != '.')
                            this.Add(new Rock(j + 1, lines.Count - i, lines[i][j]));
                    }
                }

            }
            public void Tilt(TiltDirection Direction)
            {
                switch(Direction)
                {
                    case TiltDirection.North:
                        var Columns = this.GroupBy(r => r.X).ToList();
                        foreach (var c in Columns)
                        {
                            int curr = this.NbRows;
                            foreach (Rock r in c.OrderByDescending(r=>r.Y).ToList())
                            {
                                if (r.isFixed)
                                {
                                    curr = r.Y;
                                }
                                else
                                {
                                    r.Y = curr;
                                }
                                curr--;
                            }
                        }
                        break;
                    case TiltDirection.South:
                        Columns = this.GroupBy(r => r.X).ToList();
                        foreach (var c in Columns)
                        {
                            int curr = 1;
                            foreach (Rock r in c.OrderBy(r => r.Y).ToList())
                            {
                                if (r.isFixed)
                                {
                                    curr = r.Y;
                                }
                                else
                                {
                                    r.Y = curr;
                                }
                                curr++;
                            }
                        }
                        break;
                    case TiltDirection.East:
                        var Rows = this.GroupBy(r => r.Y).ToList();
                        foreach (var r in Rows)
                        {
                            int curr = this.NbCols;
                            foreach (Rock R in r.OrderByDescending(R => R.X).ToList())
                            {
                                if (R.isFixed)
                                {
                                    curr = R.X;
                                }
                                else
                                {
                                    R.X = curr;
                                }
                                curr--;
                            }
                        }
                        break;
                    case TiltDirection.West:
                        Rows = this.GroupBy(r => r.Y).ToList();
                        foreach (var r in Rows)
                        {
                            int curr = 1;
                            foreach (Rock R in r.OrderBy(R => R.X).ToList())
                            {
                                if (R.isFixed)
                                {
                                    curr = R.X;
                                }
                                else
                                {
                                    R.X = curr;
                                }
                                curr++;
                            }
                        }
                        break;
                }
            }
            public void Cycle()
            {
                this.Tilt(TiltDirection.North);
                this.Tilt(TiltDirection.West);
                this.Tilt(TiltDirection.South);
                this.Tilt(TiltDirection.East);
            }
            public override string ToString()
            {
                List<string> res = new List<string>();
                for(int i = 0; i < this.NbRows; i++)
                {
                    string s = "".PadRight(this.NbCols, '.');
                    foreach (Rock r in this.Where(r => r.Y == i + 1))
                    {
                        if (r.X == 1)
                        {
                            s = (r.isFixed ? "#" : "O") + s.Substring(1);
                        }
                        else
                        {
                            if (r.X == this.NbCols)
                            {
                                s = s.Substring(0, this.NbCols - 1) + (r.isFixed ? "#" : "O");
                            }
                            else
                            {
                                s = s.Substring(0, r.X - 1) + (r.isFixed ? "#" : "O") + s.Substring(r.X, this.NbCols - r.X);
                            }
                        }
                    }
                    res.Insert(0, s);
                }
                return string.Join("\r\n", res);
            }
        }
        #endregion
    }
}
