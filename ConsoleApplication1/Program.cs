using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

            #region 

            //List<Generator> Generators = new List<Generator>();
            //Random rnd = new Random();
            //for (int i = 0; i < 5; i++)
            //    Generators.Add(new Generator(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble()));

            //Printer.Print(Generators);

            //ElectricParameters ep1 = new ElectricParameters(1, 5.5);
            //ElectricParameters ep2 = new ElectricParameters(3, 0.4);
            //Generators[2] = new Generator(ep1);
            //Generators[4] = new Generator(ep2);

            //Printer.Print(Generators);

            ////ref prameter
            //Console.WriteLine("\nref");
            //Generator gen1 = new Generator(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            //ElectricParameters ep3 = new ElectricParameters(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            //Console.WriteLine("\nBefore:");
            //Printer.Print(gen1, ep3);
            //StopGenerator(ref gen1, ref ep3);
            //Console.WriteLine("\nAfter:");
            //Printer.Print(gen1, ep3);

            ////out parameter
            //Console.WriteLine("\nout");
            //Generator gen2 = new Generator(ep1);
            //ElectricParameters ep4 = new ElectricParameters(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            //Console.WriteLine("\nBefore:");
            //Printer.Print(gen2, ep4);
            //MaxOutGenerator(out gen2, out ep4);
            //Console.WriteLine("\nAfter:");
            //Printer.Print(gen2, ep4);

            ////passing by value
            //Console.WriteLine("\nby value");
            //gen1 = new Generator(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            //ElectricParameters ep5 = new ElectricParameters(rnd.Next(0, 10), rnd.Next(0, 10) + rnd.NextDouble());
            //Console.WriteLine("\nBefore:");
            //Printer.Print(gen1, ep5);
            //RestartGenerator(gen1, ep5);
            //Console.WriteLine("\nAfter:");
            //Printer.Print(gen1, ep5);


            ////boxing and unboxing
            //char c1 = 'b';
            //object o = c1;
            //char c2 = (char) o;
            //Console.WriteLine("\nBoxing a char into an object and unboxing it.");
            //Console.WriteLine("As a char: " + c1);
            //Console.WriteLine("As an object: " + o);
            //Console.WriteLine("As a char again: " + c2);

            #endregion


            Angle angle1 = new Angle(4020);
            Console.WriteLine(Angle.ToSeconds(angle1));
            Angle angle2 = new Angle(1, 61, 0);
            Console.WriteLine(Angle.ToSeconds(angle2));


            Console.WriteLine("\nAngle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            Console.WriteLine("\nAngle1: " + angle1.ToString() + "\nAngle2: " + angle2.ToString());

            Console.WriteLine("\nangle2 = angle1 + angle2");
            angle2 = angle1 + angle2;
            Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            Console.WriteLine("Angle1: " + angle1.ToString() + "\nAngle2: " + angle2.ToString());

            Console.WriteLine("\nangle2 = angle2 - angle1");
            angle2 = angle2 - angle1;
            Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            Console.WriteLine("Angle1: " + angle1.ToString() + "\nAngle2: " + angle2.ToString());
            Console.WriteLine("Equal: " + (angle2 == angle1));

            Console.WriteLine("\nangle2 -= angle1");
            angle2 -= angle1;
            Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            Console.WriteLine("Angle1: " + angle1.ToString() + "\nAngle2: " + angle2.ToString());

            Console.WriteLine("\nAngle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            Console.WriteLine("\nAngle1: " + angle1.ToString() + "\nAngle2: " + angle2.ToString());
            Console.WriteLine("Greater (angle1 > angle2): " + (angle1 > angle2));
            Console.WriteLine("Lesser (angle1 < angle2): " + (angle1 < angle2));
            Console.WriteLine("Greater or equal (angle1 >= angle2): " + (angle1 >= angle2));
            Console.WriteLine("Less or equal (angle1 <= angle2): " + (angle1 <= angle2));
            Console.WriteLine("Equal (angle1 == angle2): " + (angle2 == angle1));
        }
    }
}