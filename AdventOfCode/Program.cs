﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Program
    {
        static List<Tuple<long, int, int, int>> Nombres = new List<Tuple<long, int, int, int>>();
        static List<Tuple<int, int, char>> PlacementSymboles = new List<Tuple<int, int, char>>();
        static void Main(string[] args)
        {
            string input = "........954......104.......52......70..............206.806........708..........................217...............................440........\r\n.......@...................*.............................*.664..............677................@....459.........687.........................\r\n..................378.....398........548..495..........983....*................*..282.................*...........$.248.....409.......165...\r\n......261........................704.&.......*................943...615.504.....6....*773..........687..../973.2*.....=.311*....*..../......\r\n187..-....&...............828....*......*268..488....534.........................................................244.........722.286........\r\n........663.254.723.@.......*.842....696............../...163.512&.............797.......................749................................\r\n230.........*.....*.442...563...............................*.....................*716...................*...395............352..594&.......\r\n...........468.522............................+33........660....&......................................891......-...#.......................\r\n......929...........*261..680............-...........@.........29.312.............972.......................704.....545.56*274......537.....\r\n........*.......................+.#158..311.........987............*................&....923................*...837.............561...%.....\r\n......35....75.....715........382...........855............/440..890.224.....613............*......622./....810....*632.........%...........\r\n............*.....%.......286........534.................$............*...........277.....851..14...*...645.............916../.......682....\r\n.....189..641.%.........%....*..........$...694.214*......137.......16........26.....+..%........&.675.........511........*..848.184*.....55\r\n..............760......323....167..674.......*.......604@..............-......*.........24.................$......*.....666.................\r\n....99.....................................*.360.......................805..509../.........284.....&981..827....714.................410.....\r\n...*.................+.601&..10&........202.......753...........................208..925...*..........................652...752.....#.......\r\n...411......656...448..............................&......888.749..677...............=...970.................128....-....*..*....@..........\r\n.............*.......................236.60...181..........*.....*....-.713.170................@.......839.....*....116.....79.431.=........\r\n.689...542..46................483.....*....*...*.....#..289..348.483........*........=...731....376...@.....656.....................924.&...\r\n.........*.............340......&..@..92..314.3...572.........$.......408.177........728....*....................325...929..............852.\r\n........824....323....*...........157....................126............*.....640...........404...................*......@........430.......\r\n.649..............*.723.......32............375......480*....537..637.467.....*....=598.............959.......263..136......718...*....#....\r\n..........931..316...........*...........78*................../..*.........611..........979.@...198....*751...*.........123./......579..733.\r\n.81&.....*..............772.884......809..................435.....940............162*........96...*............145....../......414..........\r\n.......#.511......204....................706*.....442........*........213.............116......................................./...........\r\n625...60............*..............@.........870.#...........17.......*.......725.....*...........-..696.......114......../.......=.........\r\n............734..................482.................35*974.....%....227........@.....60........382...*.......-..........664....584...472...\r\n288.....697*............................*614....975.............999.........599..........332..........978..60......./...................*...\r\n...*............701..961..180........998..................211..............$...............*...310..................953.....$..153...861....\r\n356........%344..@....*....*........................267....+...421%........................697....*...........531.........776.....*......193\r\n........#...........757.925................360.........................261......71.....950.........490....-../........+..........989........\r\n634...385....*70............................*.......%........311...457*.......%........*...640..........687.......=...946...................\r\n...*......514....973....100...46..570..21....155.....692.575..../..............977.233........$.................931...........*..240+.......\r\n332.............*........*........#....-................./.........944..............*............230.....+...........889.....462.......615..\r\n.....&..531....77.435.427..437......*....=417.......................%..194.......385.........88-..#...174...................................\r\n....951.............-............716.261.......................234....*..................&........................................439.......\r\n................*.........563+............*.............805.....%....681..............393...909..247.$415.............=..+..................\r\n..954.644...-...35...%425........890....857.......%.521..+..438...............437..............@...@.........563.....133..696...............\r\n...$........887.............&466.*..............547.%.........*...804....118...=..15.......302...............*......................80..%549\r\n........610......877...990.......368.......................553....*.....*........-............*.....232...282..-...............264....*.....\r\n410.....@.......%....*....*793.......946.....67*863.895.........511.....628..............945..764....*.........455...............$.....880..\r\n...*.......331....540.540.............*................*192.............................*.........103.......................................\r\n.311......*..................954......602.766.403...............#.....307..239..417......617..........959...416.........&521................\r\n.....-..51.....732.......-...=.....$.........*......695........131....*...*.....................494@..*......*...............+...983........\r\n...284.....337....+......541.......345..........306.........%........111..677........679.............738..#...537............523...%..338...\r\n.......770...............................415.......*.........32...............@..................420.....32............................-....\r\n........+...........781.....................&.......459.............649*213....36..493.621..........*.......7..458*103.......921...491......\r\n............921.....*.........373$..............*..................................*...*.......114.473.......*.......................*......\r\n.....*........=.473....+..38.........120.......294................+519.............899........*...........263...606/.545..............828...\r\n..993.............$..76....*.........%.....302.........886+.513............................193...*....................@...........592.......\r\n.......783..............872....533......%..+....................../.............................425...387........%.......958........*..6....\r\n........*..440*155..588...........*...894.....*56...339............78.@493.............261.101..........*......340...*.....*....+.....*.....\r\n.......423.........*........771..902.......167.........*...665.988.........606.....30.....*..........469..=.........745.610..542.......679..\r\n...................611.....*........................553....*......*252........=....*...$.....665...........102..............................\r\n....333...103.409.......583.............................688..92.........-........415....615.....*519............805.493.......297...........\r\n751*.........*...............926............899.............*........963..420................&...............*.....*.....286.......=495.....\r\n..................244.......*.........784.....%..737.......942.962.........-...3..........909.............160.358...........*............832\r\n........600.830....*..779....988......%.....*......*....................%..........$...............262..................335.433..81.....*...\r\n.151.......*......................$......271.302.34.....150............575.43..425.109...169........@.....@......63..25..+.............849..\r\n........*........................923..............................$560.....*............*.....167.......639............&....................\r\n573..551.855............201................*482.586.........677.........802..619........83....*.....22........#......................560*...\r\n...*..............747..*.......699.....+........*.........*....&..256.........................998..*.....823...993.........&.............662\r\n.164.634#..........*..556.........*...286....437.......483.815.....*.....*................654.....67..................#.....633.8*..........\r\n...........998..855..........67..398.............107...............610.620...........721.-.............946.900.439.283............959.199...\r\n.211*916..*..........&...524*.............436...*.............518...............893.*................*.....*...*...........=..........-.....\r\n..........235..%...473......................*....54..............*.....-......../....551............833..994.81......*640...70....74....*770\r\n...$..........950........190..704.380....442.............@264.821...-.918......................427................275.............*..248....\r\n....443..................*...........*........738.................484......................691.+.........%949..........749.....658..........\r\n.............678.....180.350........232...........................................934......#........315.........$....../..............+.....\r\n...833...920....#....*........131..................717...............222.....858..*...........%........*.530....996...........*....109......\r\n......*.....$.......389.331..@.......................*.................*.*......*..612......168.....672...$..........%.....788.15.......625.\r\n...815..........................40.589...98......./...574........451.403..327..140..............................945...136............64.....\r\n..............124..*........49......*..........200.........162....+.....................914..........461......./....%.................=.....\r\n..808.......=......363........*......27....397.........107...*.......739+....232....+........68*395.................322..166+...=.......471.\r\n...........465..............893..355..........*....70......963................*..133..........................................419.499.......\r\n..................336..62.......*...........798.......*885....../..431.851..176.............=.............583$.....................*........\r\n........429....../....%...........@.................18..........54...=.*.............245.171.......29.................=936.........657......\r\n........*................405.......405.......*689........*994...........328...980......*.....159..*.............256....................-703.\r\n.....444..................*......=........275.........421........479............*....54.........*..324....47.....#....332*855.946...........\r\n..........233....735*325.162....900.............................*................725....@.....453............499...............*............\r\n...820....*..............................848..974..82............178...54..............688.....................*...340.810..749.............\r\n....*...234.....187....*967....348......-......*.....*...&148............=..626...*.........589.....501.........82....*.....................\r\n.712........$....*..858.......*.................706...49......................+...653.......*.......*.......588..............168.313........\r\n..........776...740...........107........612..........................644.................242..................*695......236.#....*....761..\r\n.....767..............995..................*.447*...........130......*...........513..................................#........384....*.....\r\n.......................*..........306............275..............372.....................779.......&....&.....457.....731.............650..\r\n.......................161..........&...213...................726......866................*.......813..398......*..376...........607@.......\r\n..93..860....469.905............%..........*494...../215..../.#................@...980....501.................839.*....@....................\r\n......*...&..&...*....278........286..............$......183................840...*............941........300......578.259.558.....*..389...\r\n....804..669.....392...................422........743.........323..425..........774.........@....*.229.........*............*...711.8.*.....\r\n........................559.523..6.673.................292+..#......./....871=...........638....97..*.........629............28........975..\r\n..................*283...*...*........*........................*................./.@287..............124...............258.2................\r\n...*80.........545.....991....765.....595...361.......785...111.582...#........890......388.....*209......964...+.....+............475......\r\n971....666.................................*...........%.............500...653........@....*.391..........+....882..................*.......\r\n........*....-........................115...725.238*.....626...............*...-...987..680......342*.....................540........409....\r\n.153*....925.439....#..........752.....*............634..*...500&..177....47....73...................74.................+..*................\r\n.................844...........*....305.................425..........-..................445*566.........652...........732.14..581..219......\r\n.....794..482=.................163........624.....206.............................223..................*....%158..121........&......*.......\r\n.......*.......&..687...732...............%......*......47...........$.............+.....+..........323...........*...27/...........738.....\r\n.......591....313..*...../.......763..858......67.......*......550..812...$............375....334................193........................\r\n..860............................./................47...934.....*..........749....7..............*..830...938..............795..........#...\r\n...*..67...............678&..........791...........*..@......622....$..808.............$.......452./......*......................539..580...\r\n..320...*223........................%...........232..171.714.......139...*..............909............606.........=......272...............\r\n..............................88.........445..............*.....$........717.......+7.............450............874......*.................\r\n..............%...383......+.............@..............807...668....................................*735.................218...............\r\n........699..598..$.....851...&...41........651*346...................63..................89...801.........*394................&............\r\n.......*....................25.....$...........................*965............771.............*.......741.............$......229.@707......\r\n........20.853....100..438...........606..............916....20................*...........75..388.....*.....840..104.859...................\r\n.............*...#.........&........%............%.....................105$....317...........@.......349..../.....&...........239..104...873\r\n..751......715...........72..345$................881......328.38*......................465......541.................=.........&.....*.......\r\n....*..............................422...............208....*.............................*549..*....313.430.....892.................274....\r\n..88...-.....28....440.........305*...................*...789.@...../222.......898.............571....=..*............183....856............\r\n.....105............./..................578*........14........37..................*.......................981..........*.....*..............\r\n.........754..............+...561..646......637...................................544..707...97.................363..231...848.........410..\r\n........*........270.727.789..$.......*334......787*...979..............422@..120.....*.....#...........98............................*.....\r\n.......107.989......*.....................................*612...512..........*.......515..........460.@...476......463.....730....703......\r\n...........................132....146............................+........83*..849...................*.....&....669*...........*............\r\n320*......$206.........491*......*.....171..919..........486.........966$..........230......25.......126..............906....234............\r\n....690........%...............223.................156...*....*678.........................@....234.......=...350.....*............596...36.\r\n................717..511*...............322..108......*...280...........12......#......615........*.....755...*......682..904...........&...\r\n....#....................345......%406....*.....%.....169..........858...*...763.............%181.274.......74....$........*..998...........\r\n..167....230...................%........341.......................%.....827........................................814..374...........922...\r\n..................471........73..................852........272................717.....@617...100.....@.....................................\r\n...................=..................*.....769...#..........*.....545.863........$............@....791....403.....298........402*763..536..\r\n......................*............963.693.+............%..621............-...........579......................132*....................*....\r\n.535.......675.....975.314.284*..................=....49.......$.............454..211............316......................989...@.....600...\r\n............*..................528..........&...793...........700...................*.....770......*.........-....321.....*......277........\r\n...391..291..625..........................703.....................972@...797........24.92....*......822.900...703....*212.558...............\r\n....*..=...................160.165..........................#.............+..4..........*.262.............*......................+..........\r\n...837........736-..........+.....*...217-.347....446....785.....897..546....&...555.898.......382......75...48......../.....655..586.......\r\n.......................503......678.........%..........................*..........................=............*..235..321...=..............\r\n........536../....204....+.............807....................*833.677.480...322=.939...............587.....575..*.............546..........\r\n........=...974.....@...........$........%.......672.......317......@................&....789.-....&.....$......268..................780....\r\n.................*.....276...248..............87*...............................757........*..815.....129............*......................\r\n...*....776......951..*............*157.................254......&...628........*........104......................941.563................871\r\n....586...............88........283..........100.986.......*...142...*.......567...............783................................663.......\r\n.........641..........................213....*...*........468........127..........%.............*....202.........340*.............*.........\r\n.367......#......274............445..*......96.232..............175.............403.726...642..561......*............790.........433........\r\n....*.......241..*...498.........*...64............698*357......*...#4.....*..........*.....*..........210...961&...........................\r\n...152...........236.............95............................517......789.836.....236..194......................................202....720";

            var Lines = input.Replace("\r\n", "\n").Split('\n').ToList();
            int i = 0;
            foreach(var ligne in Lines) 
            {
                InitialisationLigne(i, ligne);
                i++;
            }

            // On vérifie la bonne initialisation des données de travail
            DebugInit(Lines);
            int NbLignes = Lines.Count;
            long TotalPart1 = 0;
            long TotalPart2 = 0;

            // On compte la somme des nombres à proximité d'au moins un symbole
            foreach (var nombre in Nombres)
            {
                if (SymboleProche(nombre.Item2, nombre.Item3, nombre.Item4))
                    TotalPart1 += nombre.Item1;
            }

            // On compte la somme des produits des nombres à proximité d'une étoile lorsqu'il n'y a que deux nombres concernés
            foreach (var Symbole in PlacementSymboles.Where(ps=>ps.Item3 == '*'))
            {
                if (NombresProches(Symbole.Item1, Symbole.Item2, out long produit) == 2)
                    TotalPart2 += produit;
            }

            Console.WriteLine("Part 1 : " + TotalPart1);
            Console.WriteLine("Part 2 : " + TotalPart2);
        }

        /// <summary>
        /// Pour un nombre donné (à partir de ses coordonnées), indique si un symbole se trouve à proximité
        /// </summary>
        /// <param name="ligne">Numéro de la ligne du nombre</param>
        /// <param name="debut">Index du premier chiffre du nombre dans la ligne</param>
        /// <param name="fin">Index du dernier chiffre du nombre dans la ligne</param>
        /// <returns>Vrai si au moins un symbole est voisin, faux sinon</returns>
        static bool SymboleProche(int ligne, int debut, int fin)
        {
            int ligneMin = ligne - 1;
            int ligneMax = ligne + 1;
            return PlacementSymboles.Exists(m => m.Item1 >= ligneMin && m.Item1 <= ligneMax && m.Item2 >= debut-1 &&  m.Item2 <= fin + 1);
        }

        /// <summary>
        /// Pour un symbole donné, renvoie le nombre de nombres voisins, et le produit de ses nombres
        /// </summary>
        /// <param name="LigneSymbole">Numéro de ligne du symbole</param>
        /// <param name="colSymbole">Index du symbole dans la ligne</param>
        /// <param name="produit">Produit des nombres voisins</param>
        /// <returns>Nombre de nombres voisins</returns>
        static int NombresProches(int LigneSymbole, int colSymbole, out long produit)
        {
            int ligneMin = LigneSymbole - 1;
            int ligneMax = LigneSymbole + 1;
            int colMin = colSymbole - 1;
            int colMax = colSymbole + 1;

            List<long> nombresProches = Nombres.Where(n => n.Item2 <= ligneMax
                                                        && n.Item2 >= ligneMin
                                                        && n.Item3 <= colMax
                                                        && n.Item4 >= colMin
                                                        ).Select(n => n.Item1).ToList();

            if(nombresProches.Count == 0)
                produit = 0;
            else
            {
                produit = 1;
                foreach(long n in nombresProches) 
                {
                    produit *= n;
                }
            }
            return nombresProches.Count;
        }

        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// Pour chaque symbole, on crée une entrée de type <n° de ligne, n° colonne> dans PlacementSymboles
        /// Pour chaque nombre, on crée une entrée de type <nombre, n° ligne, n° colonne du premier chiffre, n° de colonne du dernier chiffre>
        /// </summary>
        /// <param name="Numero">Numéro de la ligne d'entrée</param>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        static void InitialisationLigne(int Numero, string ligne)
        {
            var Caracteres = ligne.Where(c=> c != '0' &&
                            c != '1' &&
                            c != '2' &&
                            c != '3' &&
                            c != '4' &&
                            c != '5' &&
                            c != '6' &&
                            c != '7' &&
                            c != '8' &&
                            c != '9' &&
                            c != '.').Distinct().ToList();
            for (int i = 0; i < ligne.Length; i++)
            {
                if (Caracteres.Contains(ligne[i]))
                    PlacementSymboles.Add(new Tuple<int, int, char>(Numero, i, ligne[i]));
            }
            string LigneVide = ligne.ToString();
            foreach (var caractere in Caracteres)
                LigneVide = LigneVide.Replace(caractere, '.');

            List<long> listeNombres = LigneVide.Split('.').ToList().Select(l => (long.TryParse(l, out long nb) ? nb : (long?)null)).Where(n=>n.HasValue).Select(n=>n.Value).ToList();
            foreach(long nb in listeNombres)
            {
                string tmp = nb.ToString();
                int ndx = LigneVide.IndexOf(tmp);
                long nbl = nb;
                int ndxMoins = ndx; 
                LigneVide = (ndx == 0 ? "" : LigneVide.Substring(0, ndx))
                                    + "".PadRight(tmp.Length, '.')
                                    + (ndx + tmp.Length >= LigneVide.Length ? "" : LigneVide.Substring(ndx + tmp.Length));

                Nombres.Add(new Tuple<long, int, int, int>(nbl, Numero, ndxMoins, ndx + tmp.Length - 1));
            }
        }

        /// <summary>
        /// Fonction de debug de l'initialisation, par reconstruction de la matrice d'entrée et comparaison ligne à ligne
        /// </summary>
        /// <param name="input">Matrice d'entrée</param>
        static void DebugInit(List<string> input)
        {
            // Rendu généré à partir des données de travail
            List<string> rendu = new List<string>();
            // Données d'entrée où chaque symbole est remplacé par un #
            List<string> inPutDiese = new List<string>();

            // On construit la liste avec uniquement des points
            for (int i = 0; i < input.Count; i++)
            {
                rendu.Add("".PadRight(input[0].Length, '.'));
            }

            // On remplace les caractères par des # dans la ligne d'entrée
            foreach (var ligne in input)
            {
                var Caracteres = ligne.Where(c => c != '0' &&
                                c != '1' &&
                                c != '2' &&
                                c != '3' &&
                                c != '4' &&
                                c != '5' &&
                                c != '6' &&
                                c != '7' &&
                                c != '8' &&
                                c != '9' &&
                                c != '.' &&
                                c != '#').Distinct().ToList();
                string LigneVide = ligne.ToString();
                foreach (var caractere in Caracteres)
                    LigneVide = LigneVide.Replace(caractere, '#');

                inPutDiese.Add(LigneVide);
            }

            // On place les nombres dans le rendu à partir des données de travail
            foreach (var nombre in Nombres)
            {
                string nbStr = nombre.Item1.ToString();
                rendu[nombre.Item2] = (nombre.Item3 == 0 ? "" : rendu[nombre.Item2].Substring(0, nombre.Item3))
                                    + nbStr
                                    + (nombre.Item4 + 1 >= rendu[nombre.Item2].Length ? "" : rendu[nombre.Item2].Substring(nombre.Item4 + 1));
            }

            // On place les symboles dans le rendu à partir des données de travail
            foreach (var symbole in PlacementSymboles)
            {
                rendu[symbole.Item1] = (symbole.Item2 == 0 ? "" : rendu[symbole.Item1].Substring(0, symbole.Item2))
                                    + "#"
                                    + (symbole.Item2 + 1 >= rendu[symbole.Item1].Length ? "" : rendu[symbole.Item1].Substring(symbole.Item2 + 1));
            }

            // On affiche les lignes différentes
            Console.WriteLine($"*** DEBUG ***");
            for (int i = 0; i < rendu.Count; i++)
            {
                if (!inPutDiese[i].Equals(rendu[i]))
                {
                    Console.WriteLine($"Ligne {i} : ");
                    Console.WriteLine(inPutDiese[i]);
                    Console.WriteLine(rendu[i]);
                }

            }

            Console.WriteLine($"--- DEBUG ---");
        }
    }
}
