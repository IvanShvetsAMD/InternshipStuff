using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        public static void StopGenerator(ref Generator gen, ref ElectricParameters ep)
        {
            //gen = new Generator(0, 0);
            //ep = new ElectricParameters(0, 0);

            gen.OutputVoltage = 0;
            gen.OutputCurrent = 0;
            

            ep.Voltage = 3;
            ep.Current = 3;
        }

        public static void MaxOutGenerator(out Generator gen, out ElectricParameters ep)
        {
            gen = new Generator(double.MaxValue, double.MaxValue);
            ep = new ElectricParameters(double.MaxValue, double.MaxValue);
        }

        static void RestartGenerator(Generator gen, ElectricParameters ep)
        {
            //gen = new Generator(new ElectricParameters(0, 3));
            //ep = new ElectricParameters(0, 3);

            gen.OutputVoltage = 0;
            gen.OutputCurrent = 0;                       

            ep.Voltage = 3;
            ep.Current = 3;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Heloo, World!");

            List<Generator> Generators = new List<Generator>();
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)            
                Generators.Add( new Generator(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble()));

            Printer.Print(Generators);

            ElectricParameters ep1 = new ElectricParameters(1, 5.5);
            ElectricParameters ep2 = new ElectricParameters(3, 0.4);
            Generators[2] = new Generator(ep1);
            Generators[4] = new Generator(ep2);
            
            Printer.Print(Generators);

            //ref prameter
            Console.WriteLine("\nref");
            Generator gen1 = new Generator(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            ElectricParameters ep3 = new ElectricParameters(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            Console.WriteLine("\nBefore:");
            Printer.Print(gen1, ep3);
            StopGenerator(ref gen1, ref ep3);
            Console.WriteLine("\nAfter:");
            Printer.Print(gen1, ep3);

            //out parameter
            Console.WriteLine("\nout");
            Generator gen2 = new Generator(ep1);
            ElectricParameters ep4 = new ElectricParameters(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            Console.WriteLine("\nBefore:");
            Printer.Print(gen2, ep4);
            MaxOutGenerator(out gen2, out ep4);            
            Console.WriteLine("\nAfter:");
            Printer.Print(gen2, ep4);

            //passing by value
            Console.WriteLine("\nby value");
            gen1 = new Generator(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            ElectricParameters ep5 = new ElectricParameters(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            Console.WriteLine("\nBefore:");
            Printer.Print(gen1, ep5);
            RestartGenerator(gen1, ep5);
            Console.WriteLine("\nAfter:");
            Printer.Print(gen1,ep5);


            //boxing and unboxing
            char c1 = 'b';
            object o = c1;
            char c2 = (char)o;
            Console.WriteLine("\nBoxing a char into an object and unboxing it.");
            Console.WriteLine("As a char: " + c1);
            Console.WriteLine("As an object: " + o);            
            Console.WriteLine("As a char again: " + c2);            
        }
    }
}