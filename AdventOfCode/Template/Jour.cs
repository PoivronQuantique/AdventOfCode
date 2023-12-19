namespace AdventOfCode.Jours
{
    public class Jour_ : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Helpers
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
        private long ProcessPart1()
        {
            return 0;
        }
        private long ProcessPart2()
        {
            return 0;
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail

        #endregion
    }
}
