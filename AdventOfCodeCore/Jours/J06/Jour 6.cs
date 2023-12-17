using System;
using System.Collections.Generic;

namespace AdventOfCodeCore.Jours
{
    public class Jour_6 : Jour_abs
    {
        #region Propriétés
        List<Tuple<int, int>> records { get; set; } = new List<Tuple<int, int>>();
        Tuple<long, long> recordPt2 { get; set; }
        Dictionary<int, List<Tuple<int, int>>> jeuxGagnants { get; set; } = new Dictionary<int, List<Tuple<int, int>>>();
        #endregion

        #region Constructeur
        /// <summary> Initialisation des données
        /// </summary>
        /// <param name="debug"></param>
        public Jour_6(bool debug = false):base(debug)
        {
            Init();

            if (Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        private void Init()
        {
            records.Add(new Tuple<int, int>(50, 242));
            records.Add(new Tuple<int, int>(74, 1017));
            records.Add(new Tuple<int, int>(86, 1691));
            records.Add(new Tuple<int, int>(85, 1252));
            recordPt2 = new Tuple<long, long>(50748685, 242101716911252);
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
        /// <summary>
        /// Recherche du nombre de solutions gagnantes par force brute
        /// </summary>
        /// <returns>Nombre de solutions gagnantes pour toutes les courses</returns>
        private long ProcessPart1()
        {
            long nb = 1;
            int nbR = 0;
            foreach(var record in records)
            {
                int Seuil = record.Item2;
                int Temps = record.Item1;
                jeuxGagnants.Add(nbR, new List<Tuple<int, int>>());
                for (int i = 1; i < Temps; i++)
                {
                    int tempsCourse = Temps - i;
                    int vitesse = i;
                    int distance = tempsCourse * i;
                    if(distance > Seuil)
                        jeuxGagnants[nbR].Add(new Tuple<int, int>(i, distance));
                }
                nbR++;
            }
            foreach(int key in  jeuxGagnants.Keys)
            {
                nb *= jeuxGagnants[key].Count;
            }
            return nb;
        }

        /// <summary>
        /// Temps d'appui * temps total - temps d'appui = distance parcourue
        /// On recherche les temps d'appuis pour lesquels la distance parcourue est supérieure au record.
        /// -x² - tx - Record > 0
        /// Le problème peut être modélisé de forme ax² + bx + c
        /// Par la méthode du calcul du discriminant, on recherche les valeurs pour lesquelles la distance parcourue est égale au record, 
        /// puis on compte le nombre de valeurs entières entre les deux.
        /// </summary>
        /// <returns>Nombre de possibilités de battre le record</returns>
        private long ProcessPart2()
        {
            long a = -1, b = recordPt2.Item1, c = -recordPt2.Item2;
            long delta = (b * b) - (4 * a * c);
            double max = (-b - Math.Sqrt(delta)) / (2*a);
            double min = (-b + Math.Sqrt(delta)) / (2*a);
            long maxVal = (long)Math.Floor(max);
            long minVal = (long)Math.Ceiling(min);
            
            return maxVal - minVal + 1;
        }
        #endregion

        #region Debug
        /// <summary>
        /// Fonction de debug de l'initialisation, par reconstruction de la matrice d'entrée et comparaison ligne à ligne
        /// </summary>
        private void DebugInit()
        {
        }
        #endregion
    }
}
