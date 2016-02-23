using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Generator
    {
        public double OutputVoltage { get; set; }
        public double OutputCurrent { get; set; }

        public Generator (double voltage) :this(voltage, default(float)) { }  
        
        public Generator (ElectricParameters ep) :this (ep.Voltage, ep.Current) { }     
        
        public Generator (double voltage, double amperes)
        {
            OutputVoltage = voltage;
            OutputCurrent = amperes;
        }

        public override string ToString()
        {
            return string.Format("Voltage: {0}, Current: {1}", OutputVoltage, OutputCurrent);
        }
    }

    static class Voltmeter
    {
        public static double MeasureVoltageInMillivolts(Generator gen)
        {
            return gen.OutputVoltage / 1000;
        } 
    }
    static class Ammeter
    {
        public static double MeasureCurrentInMilliamps(Generator gen)
        {
            return gen.OutputVoltage / 1000;
        }
    }

    struct ElectricParameters
    {
        public double Voltage;
        public double Current;

        public ElectricParameters(double v, double i)
        {
            Voltage = v;
            Current = i;
        }

        public override string ToString()
        {
            return string.Format("Voltage: {0}, Current: {1}", Voltage, Current);
        }
    }  

    static class Printer
    {
        public static void Print (IEnumerable<Generator> list)
        {
            Console.WriteLine("\nGenerators:");
            foreach (Generator gen in list)
                Console.WriteLine(gen);
        }

        public static void Print (object obj, ValueType vt)
        {
            Console.WriteLine("\nGenerator:");
            Console.WriteLine(obj.ToString());
            Console.WriteLine("Electrical parameters:");
            Console.WriteLine(vt);
        }

        public static List<object> Change(this List<object> list, ArrangeDelegate ad)
        {
            var flag = true;

            for (int i = 1; (i <= (list.Count - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (list.Count - 1); j++)
                {
                    if (ad(list[j], list[j + 1]))
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        flag = true;
                    }
                }
            }
            return list;
        }
    }
}