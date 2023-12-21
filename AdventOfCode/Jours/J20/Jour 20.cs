using System.ComponentModel.Design;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode.Jours
{
    public class Jour_20 : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Helpers
        #endregion

        #region Propriétés
        private Modules Reseau { get; set; }
        #endregion

        #region Constructeur
        public Jour_20(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "%gv -> lq, pm\r\n%rv -> jd, nh\r\n%nh -> rs, jd\r\n&vt -> tj\r\n%zv -> pm, gv\r\n%gh -> jd, vd\r\n%hh -> bf, qm\r\n%kx -> nf\r\n%st -> pm, zc\r\n%bh -> qm, pv\r\n&sk -> tj\r\n%hl -> nf, pn\r\n%mt -> st, pm\r\n&jd -> ts, gh, vd, dc, xc\r\n%zm -> hm\r\n%pv -> vv\r\n%zf -> nf, cz\r\n&xc -> tj\r\n%bf -> qm\r\n%ts -> sg\r\n%ht -> ch, nf\r\n%pb -> rv, jd\r\n%nx -> fc\r\n%mb -> mt\r\n%mh -> jd, pb\r\n%lc -> bh\r\n%xg -> mb, pm\r\n%vd -> dc\r\nbroadcaster -> gh, dl, xg, fb\r\n%sg -> mh, jd\r\n%qq -> ts, jd\r\n%dl -> nf, sv\r\n%vv -> sm, qm\r\n%zc -> tb\r\n%sr -> zv, pm\r\n%dc -> gb\r\n%cz -> nf, zm\r\n%rs -> jd\r\n%hm -> nf, hl\r\n%gd -> sr\r\n&qm -> lc, pv, nx, fb, kk\r\n&tj -> rx\r\n%gb -> qq, jd\r\n%xf -> zf\r\n%tb -> lg\r\n%sm -> qm, hh\r\n%fb -> dr, qm\r\n%lq -> pm\r\n&nf -> zm, dl, ch, xf, vt\r\n&pm -> sk, zc, tb, gd, mb, xg\r\n%pn -> nf, kx\r\n%fc -> xb, qm\r\n%ch -> xf\r\n&kk -> tj\r\n%lg -> pm, gd\r\n%sv -> nf, ht\r\n%xb -> qm, lc\r\n%dr -> nx, qm";
            //InputData = "broadcaster -> a, b, c\r\n%a->b\r\n%b->c\r\n%c->inv\r\n&inv->a";   // Exemple donné pour debug
            //InputData = "broadcaster->a\r\n% a->inv, con\r\n& inv->b\r\n% b->con\r\n& con->output";   // Exemple donné pour debug

            #endregion

            InitInputData(InputData);

            Reseau = new Modules(Lines);

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
            if (Debug)
            {
                Console.WriteLine("i : |".PadLeft(19) + "Traités : |".PadLeft(19) + "".PadRight(12) + "File d'attente : |".PadLeft(19) + "".PadRight(12) + "Terminés : |".PadLeft(19) + "".PadRight(13) + "Temps écoulé : |".PadLeft(19));
                Console.WriteLine("  ".PadRight(130, '-'));
            }
            return Reseau.PushButton(1000, Debug);
        }
        private long ProcessPart2()
        {
            if (Debug)
            {
                Console.WriteLine("i : |".PadLeft(19) + "Traités : |".PadLeft(19) + "".PadRight(12) + "File d'attente : |".PadLeft(19) + "".PadRight(12) + "Terminés : |".PadLeft(19) + "".PadRight(13) + "Temps écoulé : |".PadLeft(19));
                Console.WriteLine("  ".PadRight(130, '-'));
            }
            return Reseau.PushButtonUntilOneLow(Debug);
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail
        private class Pulse
        {
            public string SenderName { get; set; } = "";
            public string TargetName { get; set; } = "";
            public bool isHigh { get; set; } = false;
            public override string ToString()
            {
                return SenderName + " --" + (isHigh? "H" : "L")+ "-> " + TargetName;
            }
        }
        private class Modules : Dictionary<string, Module>
        {
            private Button Button { get; set; }
            private Output? outputModule { get; set; }
            private DateTime Debut { get; set; }
            public void Init()
            {
                this.ToList().ForEach(m => m.Value.Init());
            }
            public Modules(List<string> inputData, bool Debug = false)
            {
                this.Button = new Button();
                foreach(string s in inputData)
                {
                    Module? m = null;
                    switch(s[0])
                    {
                        case '%':
                            m = new FlipFlop(s.Substring(1));
                            break;
                        case '&':
                            m = new Conjunction(s.Substring(1));
                            break;
                        default:
                            if(s.StartsWith("broadcaster"))
                            {
                                m = new Boradcast(s);
                            }
                            break;
                    }
                    if(m != null)
                    {
                        this.Add(m.Name, m);
                    }
                }
                List<Module> ModulesSuppl = new List<Module>();
                foreach(var Mod in this)
                {
                    foreach(var str in Mod.Value.NomsModulesSuivants)
                    {
                        if(this.TryGetValue(str, out Module? mod))
                        {
                            Mod.Value.AddModule(mod);
                        }
                        else
                        {
                            Output o = new Output(str + " -> ");
                            outputModule = o;
                            ModulesSuppl.Add(o);
                            Mod.Value.AddModule(o);

                        }
                    }
                }
                foreach (var Module in ModulesSuppl)
                    this.Add(Module.Name, Module);
                if(Debug)
                {
                    foreach (var v in this)
                    {
                        Console.WriteLine(v.Value.ToString());
                    }
                }
            }
            public long PushButton(long NombreAppuis, bool Debug = false, long? nbDebug = null)
            {
                long nbLow = 0;
                long nbHigh = 0;
                long nbOut = 0;
                if(!nbDebug.HasValue)
                {
                    Debut = DateTime.Now;

                }
                for (long i = 1;  i <= NombreAppuis; i++)
                {
                    Queue<Pulse> Queue = new Queue<Pulse>();
                    Queue.Enqueue(Button.PushButton());
                    while (Queue.TryDequeue(out Pulse? p))
                    {
                        if (p.isHigh)
                            nbHigh++;
                        else
                            nbLow++;
                        var resultat = this[p.TargetName].Process(p);
                        if (resultat.Count == 0)
                            nbOut++;
                        while (resultat.TryDequeue(out Pulse? nouveauPulse))
                        {
                            Queue.Enqueue(nouveauPulse);
                        }
                        if(Debug)
                        {
                            TimeSpan ts = DateTime.Now - Debut;
                            Console.Write((nbDebug.HasValue ? nbDebug.Value : i).ToString("N0").PadLeft(18) + "|" + (nbLow + nbHigh).ToString("N0").PadLeft(18) + "|".PadRight(13) + Queue.Count.ToString("N0").PadLeft(18) + "|".PadRight(13) + nbOut.ToString("N0").PadLeft(18) + "|".PadRight(13) + ts.ToString("c").PadLeft(18) + " |" + this.ToString() + "\r" );
                        }
                    }
                }
                if (Debug && !nbDebug.HasValue)
                    Console.WriteLine();
                return nbLow * nbHigh;
            }

            public long PushButtonUntilOneLow(bool Debug = false)
            {
                long Nb = 0;
                Debut = DateTime.Now;
                this.Init();
                while (outputModule.NbLowPulse < 1 )
                {
                    outputModule.Init();
                    Nb++;
                    PushButton(1, Debug, Nb);
                }
                return Nb;
            }
            public override string ToString()
            {
                return string.Join("", this.Select(p => p.Value.GetEtat()));
            }
        }
        private class Button
        {
            private Pulse InitPulse { get; set; } = new Pulse()
            {
                SenderName = "button",
                TargetName = "broadcaster"
            };
            public Pulse PushButton()
            {
                return InitPulse;
            }
        }
        private abstract class Module
        {
            public string Name { get; protected set; } = "";
            protected List<Module> ModulesSuivants { get; private set; } = new List<Module>();
            public List<string> NomsModulesSuivants { get; private set; } = new List<string>();

            public Module(string s)
            {
                var Split = s.Split('-');
                Name = Split[0].Trim();
                NomsModulesSuivants = Split[1].Substring(1).Split(',').Select(t=>t.Trim()).ToList();    
            }
            public void AddModule(Module module)
            {
                ModulesSuivants.Add(module);
                module.EndInit(this);
            }
            public abstract void Init();
            public virtual void EndInit(Module prev)
            {
            }
            public abstract Queue<Pulse> Process(Pulse p);
            public virtual string GetEtat()
            {
                return " " ;
            }
            public override string ToString()
            {
                return this.Name + " -> " + string.Join(", ", this.ModulesSuivants.Select(ms=>ms.Name));
            }
        }
        private class Boradcast : Module
        {
            public Boradcast(string Line) : base(Line) { }

            public override void Init()
            {
            }

            public override Queue<Pulse> Process(Pulse p)
            {
                Queue<Pulse> pulses = new Queue<Pulse>();
                foreach (Module m in this.ModulesSuivants)
                {
                    pulses.Enqueue(new Pulse()
                    {
                        isHigh = p.isHigh,
                        SenderName = this.Name,
                        TargetName = m.Name
                    });
                }
                return pulses;
            }
        }
        private class Output : Module
        {
            public Output(string s) : base(s) { }
            public long NbLowPulse { get; private set; } = 0;
            public override Queue<Pulse> Process(Pulse p)
            {
                if(!p.isHigh)
                {
                    NbLowPulse++;

                }
                return new Queue<Pulse>();
            }

            public override void Init()
            {
                NbLowPulse = 0;
            }
        }
        private class FlipFlop : Module
        {
            private bool isOn { get; set; } = false;

            public FlipFlop(string Line) : base(Line) {}

            public override Queue<Pulse> Process(Pulse p)
            {
                Queue<Pulse> pulses = new Queue<Pulse>();
                if(!p.isHigh)
                {
                    this.isOn = !this.isOn;
                    foreach(Module m in this.ModulesSuivants)
                    {
                        pulses.Enqueue(new Pulse()
                        {
                            isHigh = this.isOn,
                            SenderName = this.Name,
                            TargetName = m.Name
                        });
                    }
                }
                return pulses;
            }
            public override string GetEtat()
            {
                return (isOn ? "+" : "-");
            }
            public override string ToString()
            {
                return "%" + base.ToString();
            }

            public override void Init()
            {
                this.isOn = false;
            }
        }
        private class Conjunction : Module
        {
            private Dictionary<string, bool> Memoire { get; set; } = new Dictionary<string, bool>();
            public Conjunction(string Line) : base(Line) {}
            public override Queue<Pulse> Process(Pulse p)
            {
                Queue<Pulse> pulses = new Queue<Pulse>();
                Memoire[p.SenderName] = p.isHigh;
                bool Etat = false;
                if(Memoire.ContainsValue(false)) 
                {
                    Etat = true;
                }
                else 
                {
                    // High on all
                    Etat = false;
                }
                foreach(Module m in this.ModulesSuivants)
                {
                    pulses.Enqueue(new Pulse()
                    {
                        isHigh = Etat,
                        SenderName = this.Name,
                        TargetName = m.Name
                    });
                }
                return pulses;
            }

            public override void EndInit(Module prev)
            {
                base.EndInit(prev);
                if(!Memoire.TryGetValue(prev.Name, out bool unused))
                {
                    Memoire.Add(prev.Name, false);
                }
            }
            public override string GetEtat()
            {
                return string.Join("", this.Memoire.Select(m => (m.Value ? "+" : "-")));
            }
            public override string ToString()
            {
                return "&" + base.ToString();
            }

            public override void Init()
            {
                Memoire.ToList().ForEach(m => Memoire[m.Key] = false);
            }
        }

        #endregion
    }
}
