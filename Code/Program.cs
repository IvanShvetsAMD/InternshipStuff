using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class Program
    {
        static void Main()
        {
            JetEngine jet = new JetEngine(600, 500, 5, new List<Propellants> {Propellants.Jet_A}, new List<Oxidisers> {Oxidisers.GOX}, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);

            Console.WriteLine(jet);
        }
    }
}