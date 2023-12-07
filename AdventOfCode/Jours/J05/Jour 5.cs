using AdventOfCode.Template;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventOfCode.Jours.J05
{
    public class Jour_5 : Jour_abs
    {
        #region Propriétés
        private List<long> Graines { get; set; } = new List<long>();
        private FullMap DataMapping { get; set; } = new FullMap();
        #endregion

        #region Constructeur
        public Jour_5(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "seeds: 1310704671 312415190 1034820096 106131293 682397438 30365957 2858337556 1183890307 665754577 13162298 2687187253 74991378 1782124901 3190497 208902075 226221606 4116455504 87808390 2403629707 66592398\r\n\r\nseed-to-soil map:\r\n2879792625 0 201678008\r\n2425309256 1035790247 296756276\r\n2722065532 1759457739 157727093\r\n400354950 1917184832 1164285801\r\n0 201678008 400354950\r\n1564640751 602032958 433757289\r\n1998398040 1332546523 426911216\r\n\r\nsoil-to-fertilizer map:\r\n3434127746 3670736129 29685965\r\n1809924203 1168707872 308179\r\n2108903682 1437989162 44479258\r\n237181023 2915565442 27901445\r\n1173998623 2434447796 13633544\r\n75539025 740516241 29278225\r\n41104738 706081954 34434287\r\n3279397405 3488165796 12149874\r\n3463813711 3827946213 157129363\r\n1810232382 769794466 15695437\r\n877824710 677909236 28172718\r\n2215709448 1746651561 307558709\r\n1825927819 1692597620 54053941\r\n104817250 420198730 132363773\r\n2916210208 392942051 27256679\r\n1022591555 2448081340 151407068\r\n3925105941 3985075576 182313682\r\n1897186025 2212065968 211717657\r\n2198981202 1304666789 16728246\r\n850656807 2054210270 27167903\r\n3766599721 3500315670 158506220\r\n3419071398 3279397405 15056348\r\n7830088 2126976435 33274650\r\n3620943074 3658821890 11914239\r\n1264213180 2599488408 138420934\r\n811586355 2160251085 12020898\r\n3632857313 3354423388 133742408\r\n1612763314 1169016051 108601184\r\n1721364498 2172271983 39793985\r\n1187632167 601328223 76581013\r\n823607253 1277617235 27049554\r\n728944387 2737909342 82641968\r\n0 2426617708 7830088\r\n3291547279 3700422094 127524119\r\n1402634114 1482468420 210129200\r\n905997428 1321395035 107714902\r\n4107419623 3294453753 59969635\r\n1879981760 785489903 17204265\r\n2153382940 2081378173 45598262\r\n277361019 802694168 366013704\r\n1761158483 552562503 48765720\r\n646208806 2832829861 82735581\r\n2523268157 0 392942051\r\n1013712330 1429109937 8879225\r\n643374723 2423783625 2834083\r\n265082468 2820551310 12278551\r\n\r\nfertilizer-to-water map:\r\n4253122607 1473424614 41844689\r\n3040447798 2659805568 46237011\r\n0 146022665 42081460\r\n55436822 188104125 65067713\r\n42081460 132667303 13355362\r\n2429043181 3587614447 54605699\r\n888256662 672288214 24436041\r\n4064969883 1978094070 95324589\r\n3086684809 977403736 339965972\r\n120504535 253171838 93494065\r\n2810558403 2603914183 55891385\r\n3898695123 2901215107 166274760\r\n2483648880 4002918707 103777141\r\n1300545784 2848997109 52217998\r\n2418717938 1463099371 10325243\r\n1022681665 808998429 30429585\r\n2866449788 1411682577 4750813\r\n1181605510 4172708724 118940274\r\n2078503930 2466708865 42530000\r\n1105548530 1545561518 76056980\r\n978705579 2573458117 30456066\r\n2324405069 1317369708 94312869\r\n1991848966 3429793336 22435712\r\n4190586687 2706042579 43180396\r\n1352763782 1416433390 46665981\r\n3760606255 1683093685 138088868\r\n1399429763 3452229048 135385399\r\n2121033930 839428014 137975722\r\n2940673664 2749222975 99774134\r\n1053111250 2073418659 52437280\r\n3426650781 1821182553 152991287\r\n1534815162 2195329002 252024339\r\n730962658 3067489867 157294004\r\n3579642068 710244275 98754154\r\n1786839501 3224783871 205009465\r\n2259009652 1974173840 3920230\r\n2587426021 370264097 223132382\r\n2871200601 2125855939 69473063\r\n213998600 44701447 87965856\r\n4233767083 2447353341 19355524\r\n2262929882 1621618498 61475187\r\n1009161645 696724255 13520020\r\n3678396222 593396479 78891735\r\n912692703 4106695848 66012876\r\n3757287957 4291648998 3318298\r\n301964456 0 44701447\r\n2014284678 2509238865 64219252\r\n370264097 3642220146 360698561\r\n4160294472 1515269303 30292215\r\n\r\nwater-to-light map:\r\n4066036887 2992193346 95912236\r\n531075515 493316918 162009008\r\n3260565192 854248031 437396028\r\n1341316194 4205924684 89042612\r\n1879858967 2058162578 692895326\r\n452475911 655325926 78599604\r\n2997176790 1690328655 208783332\r\n2731804884 3324847814 265371906\r\n355611136 0 96864775\r\n2572754293 1899111987 159050591\r\n1081338600 3590219720 138271571\r\n1430358806 2779435417 212757929\r\n3234337635 4179697127 26227557\r\n854248031 3728491291 227090569\r\n4161949123 3955581860 102409244\r\n3205960122 2751057904 28377513\r\n50952557 147817332 304658579\r\n1219610171 4057991104 121706023\r\n4264358367 1291644059 30608929\r\n3697961220 1322252988 368075667\r\n1643116735 3088105582 236742232\r\n693084523 452475911 40841007\r\n0 96864775 50952557\r\n\r\nlight-to-temperature map:\r\n2756401132 2384899493 13749631\r\n1163093625 0 117407544\r\n3603435593 3599927411 262731037\r\n2081436411 2089913126 119300659\r\n693703633 117407544 395383894\r\n1672621164 1405157690 24997208\r\n3873714258 2780774148 107551276\r\n3355072403 2593861641 186912507\r\n1953100586 3862658448 62069331\r\n143286272 672639421 194814248\r\n1562062673 1010739941 110558491\r\n2869050867 2888325424 31673634\r\n3159859886 2398649124 195212517\r\n2900724501 3298674599 34708838\r\n2243940568 4059045429 56605170\r\n691405879 1193483066 2297754\r\n2300545738 2005749676 25248062\r\n3541984910 3924727779 61450683\r\n2200737070 3986178462 43203498\r\n3981265534 2030997738 58915388\r\n2530829166 4276276595 18690701\r\n621411866 641250212 31389209\r\n1784026205 4037549491 21495938\r\n1519774068 1362869085 42288605\r\n3866166630 3584674072 7547628\r\n652801075 1430154898 38604804\r\n2015169917 4029381960 8167531\r\n2770150763 2936555750 98900104\r\n1813227854 2258880377 123316040\r\n3032290681 1784026205 127569205\r\n0 867453669 143286272\r\n1805522143 3592221700 7705711\r\n4040180922 3043888225 254786374\r\n2023337448 3035455854 8432371\r\n3029587605 2382196417 2703076\r\n392553196 1468759702 228858670\r\n2710145863 3538418803 46255269\r\n1089087527 567244114 74006098\r\n2325793800 3333383437 205035366\r\n2549519867 4115650599 160625996\r\n338100520 512791438 54452676\r\n2935433339 1911595410 94154266\r\n1280501169 1121298432 72184634\r\n1352685803 1195780820 167088265\r\n2031769819 2209213785 49666592\r\n1936543894 2919999058 16556692\r\n\r\ntemperature-to-humidity map:\r\n1606220966 2958863752 268926464\r\n2994413958 1467440292 348583188\r\n1347324773 3453966662 171497865\r\n3342997146 3227790216 188948930\r\n0 211826810 113744983\r\n1875147430 1816023480 774831860\r\n699941162 0 211826810\r\n443679044 325571793 256262118\r\n3531946076 1280528675 186911617\r\n1280528675 4228171198 66796098\r\n113744983 581833911 329934061\r\n1518822638 2590855340 50170812\r\n1568993450 3416739146 37227516\r\n2967816890 4201574130 26597068\r\n3718857693 3625464527 576109603\r\n2649979290 2641026152 317837600\r\n\r\nhumidity-to-location map:\r\n3244927 955737016 9389705\r\n380524056 2531586403 38604778\r\n3713586211 965126721 158937945\r\n3122843287 1406574654 236795236\r\n776685423 1643369890 534268825\r\n2053493196 0 55930434\r\n582662115 695344450 194023308\r\n3885666529 3855399097 320692779\r\n88096722 283368340 98672354\r\n1901561222 3703467123 151931974\r\n1317500428 2570191181 151780331\r\n3872524156 3690324750 13142373\r\n2109423630 249685414 30437999\r\n1310954248 4199813128 6546180\r\n1751790747 382040694 149770475\r\n3056474029 889367758 66369258\r\n2139861629 4176091876 23721252\r\n12634632 2721971512 75462090\r\n186769076 55930434 193754980\r\n419128834 531811169 163533281\r\n3359638523 2177638715 353947688\r\n2163582881 2797433602 892891148\r\n1469280759 1124064666 282509988\r\n0 280123413 3244927";
            #endregion

            InitInputData(InputData);

            List<Dictionary<Tuple<long, long>, long>> DataMap = new List<Dictionary<Tuple<long, long>, long>>
            {
                new Dictionary<Tuple<long, long>, long>(),
                new Dictionary<Tuple<long, long>, long>(),
                new Dictionary<Tuple<long, long>, long>(),
                new Dictionary<Tuple<long, long>, long>(),
                new Dictionary<Tuple<long, long>, long>(),
                new Dictionary<Tuple<long, long>, long>(),
                new Dictionary<Tuple<long, long>, long>()
            };

            int i = 0;
            InitialisationSeeds(Lines[0]);
            Lines.RemoveAt(0);
            Lines.RemoveAt(0);
            Lines.RemoveAt(0);
            while (Lines.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(Lines[0]))
                {
                    Lines.RemoveAt(0);
                    Lines.RemoveAt(0);
                    i++;
                }
                InitialisationLigne(DataMap, i, Lines[0]);
                Lines.RemoveAt(0);
            }

            InitFullMap(DataMap, debug);
        }
        #endregion

        #region Initialisation
        private void InitialisationSeeds(string Line)
        {
            Graines = Line.Split(':')[1].Trim().Split(' ').Select(long.Parse).ToList();
        }
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// Pour chaque symbole, on crée une entrée de type <n° de ligne, n° colonne> dans PlacementSymboles
        /// Pour chaque nombre, on crée une entrée de type <nombre, n° ligne, n° colonne du premier chiffre, n° de colonne du dernier chiffre>
        /// </summary>
        /// <param name="Numero">Numéro de la ligne d'entrée</param>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationLigne(List<Dictionary<Tuple<long, long>, long>> DataMap, int Numero, string ligne)
        {
            var PremierSplit = ligne.Split(' ').Select(long.Parse).ToList();
            DataMap[Numero].Add(new Tuple<long, long>(PremierSplit[1], PremierSplit[1] + PremierSplit[2] - 1), PremierSplit[0] - PremierSplit[1]);
        }

        /// <summary>
        /// Conversion des données de chaque objet de type List<Dictionary<Tuple<long, long>, long>> en objet de travail FullMap.
        /// Fusion des objets FullMap pour n'avoir qu'un mapping global
        /// </summary>
        /// <param name="DataMap">Données d'entrée</param>
        /// <param name="debug">Si vrai, affiche les étapes de la fusion dans la console</param>
        private void InitFullMap(List<Dictionary<Tuple<long, long>, long>> DataMap, bool debug = false)
        {
            DataMapping = new FullMap(DataMap[0]);
            if(debug)
            {
                Console.WriteLine(DataMapping.ToString());
                Console.WriteLine("");
            }

            for (int i = 1; i < DataMap.Count; i++)
            {
                FullMap fm2 = new FullMap(DataMap[i]);
                if(debug)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(fm2.ToString());
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                DataMapping = FullMap.MergeMaps(DataMapping, fm2);
                if(debug)
                {
                    Console.WriteLine(DataMapping.ToString());
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
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

        /// <summary>
        /// On texte chacune des graines en entrée
        /// </summary>
        /// <returns>L'emplacement minimal parmi les graines</returns>
        private long ProcessPart1()
        {
            long TotalPart1 = long.MaxValue;

            foreach (long g in Graines)
                TotalPart1 = Math.Min(TotalPart1, DataMapping.GetValueMapped(g));

            return TotalPart1;
        }

        /// <summary>
        /// On considère les graines en entrée comme des couples (première valeur de la tranche, nombre de valeurs successives).
        /// On découpe donc ces tranches en sous-tranches correspondant aux plages d'entrée du mappping global, et on ne teste que la première graine de chaque tranche
        /// </summary>
        /// <returns>L'emplacement minimal parmi les graines</returns>
        private long ProcessPart2()
        {
            long min = long.MaxValue;
            List<Tuple<long, long>> Tranches = new List<Tuple<long, long>>();

            for(int i = 0; i < Graines.Count - 1; i += 2)
            {
                var Tranche = new Tuple<long, long>(Graines[i], Graines[i] + Graines[i + 1] - 1);

                var tmp = DataMapping.Where(m=>m.PlageDepart.Item1 <= Tranche.Item2 && m.PlageDepart.Item2 >= Tranche.Item1)
                                    .Select(m=>new Tuple<long, long>(Math.Max(Tranche.Item1, m.PlageDepart.Item1), Math.Min(Tranche.Item2, m.PlageDepart.Item2)))
                                    .ToList();
                Tranches.AddRange(tmp);
            }

            foreach(var t in Tranches)
            {
                min = Math.Min(min, DataMapping.GetValueMapped(t.Item1));
            }
            return min;
        }

        #endregion

        #region Debug
        /// <summary>
        /// Fonction de debug de l'initialisation, par reconstruction de la matrice d'entrée et comparaison ligne à ligne
        /// </summary>
        private void DebugInit()
        {
            Console.WriteLine("Mapping final : ");
            Console.WriteLine(DataMapping.ToString());
        }
        #endregion

        #region Classes de mapping
        /// <summary>
        /// Représente une plage de mapping de données
        /// </summary>
        public class Map
        {
            public Tuple<long, long> PlageDepart { get; set; }
            public Tuple<long, long> PlageArrivee { get; set; }
            public long Offset { get; set; }

            public override string ToString()
            {
                return "[" + PlageDepart.Item1 + " " + PlageDepart.Item2 + $"] --({Offset})-> [" + PlageArrivee.Item1 + " " + PlageArrivee.Item2 + "]";
            }

        }

        /// <summary>
        /// Représente un type de mapping (exemple : Graines vers sol)
        /// </summary>
        public class FullMap : List<Map>
        {
            //public List<Map> Mapping { get; set; } = new List<Map>();

            public FullMap() { }
            public FullMap(Dictionary<Tuple<long, long>, long> data)
            {
                foreach(var dm in data)
                {
                    this.Add(new Map()
                    {
                        PlageDepart = new Tuple<long, long>(dm.Key.Item1, dm.Key.Item2),
                        Offset = dm.Value,
                        PlageArrivee = new Tuple<long, long>(dm.Key.Item1 + dm.Value, dm.Key.Item2 + dm.Value)
                    });
                }
                Wrap();
            }

            /// <summary>
            /// Cette fonction couvre les "blancs" non couverts par les données d'initialisation, en créant les plages à l'offset nul sur [0 long.MaxValue]
            /// </summary>
            private void Wrap()
            {
                var MappingTrie = this.OrderBy(m=>m.PlageDepart.Item1).ToList();
                long depart = 0;
                foreach(Map map in MappingTrie)
                {
                    if(map.PlageDepart.Item1 > depart)
                    {
                        this.Add(new Map() { 
                            PlageDepart = new Tuple<long, long>(depart, map.PlageDepart.Item1-1), 
                            Offset = 0, 
                            PlageArrivee = new Tuple<long, long>(depart, map.PlageDepart.Item1 - 1) 
                        });
                    }
                    depart = map.PlageDepart.Item2 + 1;
                }
                this.Add(new Map()
                {
                    PlageDepart = new Tuple<long, long>(MappingTrie.Max(mt => mt.PlageDepart.Item2) + 1, long.MaxValue),
                    Offset = 0,
                    PlageArrivee = new Tuple<long, long>(MappingTrie.Max(mt => mt.PlageDepart.Item2) + 1, long.MaxValue)
                }) ;
                var tmp = this.OrderBy(m => m.PlageDepart.Item1).ToList();
                this.Clear();
                this.AddRange(tmp);
            }

            /// <summary>
            /// Convertir la valeur en entrée selon le plan de mapping
            /// </summary>
            /// <param name="value">Valeur à convertir</param>
            /// <returns>Valeur convertie</returns>
            public long GetValueMapped(long value)
            {
                long valueMapped = this.First(m => m.PlageDepart.Item1 <= value && m.PlageDepart.Item2 >= value).Offset + value;
                return valueMapped;
            }
            /// <summary>
            /// Rechercher un objet Map à partir de la valeur de départ
            /// </summary>
            /// <param name="startValue">Valeur recherchée</param>
            /// <returns>L'objet Map permettant de convertir la valeur en paramètre</returns>
            public Map GetMapFromStartValue(long startValue)
            {
                return this.FirstOrDefault(m => m.PlageDepart.Item1 <= startValue && m.PlageDepart.Item2 >= startValue);
            }

            /// <summary>
            /// Rechercher un objet Map à partir de la valeur d'arrivée
            /// </summary>
            /// <param name="endValue">Valeur recherchée</param>
            /// <returns>L'objet Map permettant d'arriver sur la valeur en paramètre</returns>
            public Map GetMapFromEndValue(long endValue)
            {
                return this.FirstOrDefault(m => m.PlageArrivee.Item1 <= endValue && m.PlageArrivee.Item2 >= endValue);
            }

            /// <summary>
            /// Pour debug uniquement
            /// </summary>
            /// <returns>Mise en forme esthétique du contenu de l'objet</returns>
            public override string ToString()
            {
                return string.Join("\r\n", this.OrderBy(m=>m.PlageDepart.Item1));
            }

            /// <summary>
            /// Permet de fusionner deux plans de mapping successifs pour en obtenir un seul et éviter de faire deux conversions successives
            /// </summary>
            /// <param name="map1">Plan N</param>
            /// <param name="map2">Plan N+1</param>
            /// <returns></returns>
            public static FullMap MergeMaps (FullMap map1, FullMap map2)
            {
                var Res = new FullMap();
                // À partir des plages de valeur d'arrivée du map1 et des plages de valeur de départ du map 2, on crée la liste des valeurs limites pour les futures tranches.
                List<long> Boundaries = map1.Select(m=>m.PlageArrivee.Item1).ToList();
                Boundaries.AddRange(map1.Select(m => m.PlageArrivee.Item2));
                Boundaries.AddRange(map2.Select(m => m.PlageDepart.Item1));
                Boundaries.AddRange(map2.Select(m => m.PlageDepart.Item2));
                Boundaries = Boundaries.OrderBy(l=>l).ToList();
                Boundaries.RemoveAt(0);
                Boundaries.RemoveAt(Boundaries.Count - 1);

                // Gestion des doublons : on ajoute les valeurs limites n-1 et n+1 après avoir retiré les doublons 
                List<long> Temp = Boundaries.GroupBy(l=>l).Where(g=>g.Count() > 1).Select(g=>g.First()).ToList();
                Boundaries.RemoveAll(B => Temp.Contains(B));
                foreach(long l in Temp)
                {
                    if(!Boundaries.Contains(l-1))
                        Boundaries.Add(l - 1);
                    if (!Boundaries.Contains(l))
                        Boundaries.Add(l);
                    if (!Boundaries.Contains(l+1))
                        Boundaries.Add(l + 1);
                }

                // On trie la liste des valeurs limites pour préparer le balayage à venir
                Boundaries.Sort();

                /// Pour chaque élément n de boundaries, si l'offset global est égal à l'offset global de l'élément suivant n+1, alors on crée une Map qui prend ces deux éléments (n et n+1) comme limites, et on saute directement à l'élément n+2.
                /// Si les deux offsets globaux sont différents, on ne crée de Map que pour le premier élément, et on passe au suivant.
                for(int i = 1; i < Boundaries.Count; i++)
                {
                    Map m11 = map1.GetMapFromEndValue(Boundaries[i-1]);
                    Map m12 = map1.GetMapFromEndValue(Boundaries[i]);
                    Map m21 = map2.GetMapFromStartValue(Boundaries[i-1]);
                    Map m22 = map2.GetMapFromStartValue(Boundaries[i - 1]);
                    if(m11.Offset + m21.Offset == m12.Offset + m22.Offset)
                    {
                        Res.Add(new Map()
                        {
                            PlageDepart = new Tuple<long, long>(Boundaries[i-1] - m11.Offset, Boundaries[i] - m11.Offset),
                            Offset = m11.Offset + m21.Offset,
                            PlageArrivee = new Tuple<long, long>(Boundaries[i-1] + m21.Offset, Boundaries[i] + m21.Offset)
                        });
                        i++;
                    }
                    else
                    {
                        Res.Add(new Map()
                        {
                            PlageDepart = new Tuple<long, long>(Boundaries[i - 1] - m11.Offset, Boundaries[i-1] - m11.Offset),
                            Offset = m11.Offset + m21.Offset,
                            PlageArrivee = new Tuple<long, long>(Boundaries[i - 1] + m21.Offset, Boundaries[i-1] + m21.Offset)
                        });
                    }
                }

                return Res;
            }
        }
        #endregion
    }
}
