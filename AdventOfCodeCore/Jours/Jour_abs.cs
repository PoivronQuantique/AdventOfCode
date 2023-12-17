using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public abstract class Jour_abs
    {
        protected List<string> Lines { get; set; } = new List<string>();
        protected bool Debug { get; set; }


        protected Jour_abs(bool debug)
        {
            Debug = debug;
        }
        protected void InitInputData(string inputData)
        {
            Lines = inputData.Replace("\r\n", "\n").Split('\n').ToList();
        }


        public abstract long Partie1();
        public abstract long Partie2();
    }
}
