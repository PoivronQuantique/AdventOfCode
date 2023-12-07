﻿using AdventOfCode.Template;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Jours.J
{
    public class Jour_ : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Propriétés
        #endregion

        #region Constructeur
        public Jour_(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "";
            //InputData = "";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);

            foreach (string ligne in Lines)
            {
                InitialisationLigne(ligne);
            }
            if (this.Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// </summary>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationLigne(string ligne)
        {
            var Split = ligne.Split(' ').ToList();
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
        /// Le process est identique au process1, avec pour seule différence la prise en compte des jokers, d'où le recalcul des valeurs des mains et le nouveau tri
        /// </summary>
        /// <returns></returns>
        private long ProcessPart2()
        {
            return 0;
        }
        private long ProcessPart1()
        {
            return 0;
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

        #region Classes de travail

        #endregion
    }
}
