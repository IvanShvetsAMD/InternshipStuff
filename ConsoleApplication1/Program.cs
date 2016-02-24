using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using SideTasts;

namespace ConsoleApplication1
{
    public delegate bool ArrangeDelegate(object obj1, object obj2);
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

            gen.OutputVoltage = 10;
            gen.OutputCurrent = 0;

            ep.Voltage = 3;
            ep.Current = 3;
        }

        public static bool RearrangeMethod1(object obj1, object obj2)
        {
            if (obj1 is Generator)
                return true;
            if (obj1 is Angle && obj2 is ElectricParameters)
                return true;
            if (obj1 is ElectricParameters)
                return false;
            return false;
        }

        public static List<object> Rearrange(List<object> list, ArrangeDelegate arrangedelegate)
        {
            var flag = true;

            for (int i = 1; (i <= (list.Count - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (list.Count - 1); j++)
                {
                    if (arrangedelegate(list[j], list[j + 1]))
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

        static void Main(string[] args)
        {
            Console.WriteLine("Heloo, World!");

            #region 

            //List<Generator> Generators = new List<Generator>();
            Random rnd = new Random();
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
            //char c2 = (char)o;
            //Console.WriteLine("\nBoxing a char into an object and unboxing it.");
            //Console.WriteLine("As a char: " + c1);
            //Console.WriteLine("As an object: " + o);
            //Console.WriteLine("As a char again: " + c2);

            #endregion

            #region 

            //Angle angle1 = new Angle(4020);
            //Console.WriteLine(Angle.ToSeconds(angle1));
            //Angle angle2 = new Angle(1, 61, 0);
            //Console.WriteLine(Angle.ToSeconds(angle2));


            //Console.WriteLine("\nAngle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            //Console.WriteLine("\nAngle1: " + angle1 + "\nAngle2: " + angle2);

            //Console.WriteLine("\nangle2 = angle1 + angle2");
            //angle2 = angle1 + angle2;
            //Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            //Console.WriteLine("Angle1: " + angle1 + "\nAngle2: " + angle2);

            //Console.WriteLine("\nangle2 = angle2 - angle1");
            //angle2 = angle2 - angle1;
            //Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            //Console.WriteLine("Angle1: " + angle1 + "\nAngle2: " + angle2);
            //Console.WriteLine("Equal: " + (angle2 == angle1));

            //Console.WriteLine("\nangle2 -= angle1");
            //angle2 -= angle1;
            //Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            //Console.WriteLine("Angle1: " + angle1 + "\nAngle2: " + angle2);

            //Console.WriteLine("\nAngle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            //Console.WriteLine("\nAngle1: " + angle1 + "\nAngle2: " + angle2);
            //Console.WriteLine("Greater (angle1 > angle2):\t\t " + (angle1 > angle2));
            //Console.WriteLine("Lesser (angle1 < angle2):\t\t " + (angle1 < angle2));
            //Console.WriteLine("Greater or equal (angle1 >= angle2):\t " + (angle1 >= angle2));
            //Console.WriteLine("Less or equal (angle1 <= angle2):\t " + (angle1 <= angle2));
            //Console.WriteLine("Equal (angle1 == angle2):\t\t " + (angle2 == angle1));


            //Console.WriteLine("\nangle2 = angle1 * angle2");
            //angle2 = angle1*2;
            //Console.WriteLine("Angle1: " + Angle.ToSeconds(angle1) + "\nAngle2: " + Angle.ToSeconds(angle2));
            //Console.WriteLine("Angle1: " + angle1 + "\nAngle2: " + angle2);

            #endregion

            #region 

            //List<IOnOff> ConcertEquipment = new List<IOnOff>(8);

            //ConcertEquipment.Add(new Speaker(100, 21000, 40));
            //ConcertEquipment.Add(new Amplifier(400, 4));
            //ConcertEquipment.Add(new LaserSystem(300, "stars"));
            //ConcertEquipment.Add(new Projector(80, new byte[8], 0));
            //ConcertEquipment.Add(new Speaker(100, 21000, rnd.Next(10, 30)));
            //ConcertEquipment.Add(new Amplifier(700, rnd.Next(2, 20)));
            //ConcertEquipment.Add(new LaserSystem(rnd.Next(200, 230), "waves"));
            //ConcertEquipment.Add(new Projector(rnd.Next(70, 100), new byte[88], 10));

            //foreach (var eq in ConcertEquipment)
            //{
            //    eq.StartEquipment();
            //    Console.WriteLine(eq);
            //}
            //Console.WriteLine();
            //foreach (var eq in ConcertEquipment)
            //    eq.StopEquipment();

            #endregion

            #region 

            //GenericArrayClass<string> words = new GenericArrayClass<string>(4);

            //words[0] = "kettle";
            //words[1] = "spoon";
            //words[2] = "fork";
            //words[3] = "salad fork";

            //Console.WriteLine(words);

            //Console.WriteLine("\nSwapping by index");
            //words.SwapByIndex(2, 3);
            //Console.WriteLine(words);

            //Console.WriteLine("\nSwapping by value");
            //words.SwapByValue("kettle", "fork");
            //Console.WriteLine(words);

            //GenericArrayClass<Angle> angles = new GenericArrayClass<Angle>(4);
            //angles[0] = new Angle(rnd.Next(0, 6000));
            //angles[1] = new Angle(2);
            //angles[2] = new Angle(3);
            //angles[3] = new Angle(4);

            //Console.WriteLine(angles);

            //Console.WriteLine("\nSwapping by index");
            //angles.SwapByIndex(2, 3);
            //Console.WriteLine(angles);

            //Console.WriteLine("\nSwapping by value");
            //angles.SwapByValue(new Angle(4), new Angle(3));
            //Console.WriteLine(angles);

            #endregion

            #region 

            List<Object> stuff = new List<object>();
            stuff.Add(new Generator(4, 4));
            stuff.Add(new Angle(3, 4, 5));
            stuff.Add(new Generator(3, 8));
            stuff.Add(new Angle(400));
            stuff.Add(new Generator(220, 10));
            stuff.Add(new ElectricParameters(1, 1));

            List<object> stuff2 = new List<object>(stuff);
            List<object> stuff3 = new List<object>(stuff);
            List<object> stuff4 = new List<object>(stuff);

            Console.WriteLine("Original collection:\n");
            foreach (var obj in stuff)
            {
                Console.WriteLine(obj.GetType().Name);
            }

            ArrangeDelegate ad1 = new ArrangeDelegate(RearrangeMethod1);
            stuff = Rearrange(stuff, ad1);
            Console.WriteLine("\nafter first rearrangement(delegate)\n");
            foreach (var obj in stuff)
            {
                Console.WriteLine(obj.GetType().Name);
            }

            stuff2 = Rearrange(stuff2, delegate (object obj1, object obj2)
            {
                if (obj1 is Generator)
                    return true;
                if (obj1 is ElectricParameters && obj2 is Angle)
                    return true;
                if (obj1 is Angle)
                    return false;
                return false;
            }
                );

            Console.WriteLine("\nafter second rearrangement (anonymous function)\n");
            foreach (var obj in stuff2)
            {
                Console.WriteLine(obj.GetType().Name);
            }


            stuff3 = Rearrange(stuff3, (obj1, obj2) =>
            {
                if (obj1 is Angle)
                    return true;
                if (obj1 is ElectricParameters && obj2 is Generator)
                    return true;
                if (obj1 is Generator)
                    return false;
                return false;
            });
            Console.WriteLine("\nafter N3\n");
            foreach (var o in stuff3)
            {
                Console.WriteLine(o.GetType().Name);
            }

            Console.WriteLine("\nUsing an extension method:\n");
            var b = stuff.Change((obj1, obj2) =>
            {
                if (obj1 is Angle)
                    return true;
                if (obj1 is ElectricParameters && obj2 is Generator)
                    return true;
                if (obj1 is Generator)
                    return false;
                return false;
            });

            foreach (var o in b)
            {
                Console.WriteLine(o.GetType().Name);
            }

            Console.WriteLine("\nLINQ\n");
            foreach (var o in trylinq(stuff))
            {
                Console.WriteLine(o.GetType().Name);
            }

            #endregion


            stuff4.Add(new Generator(4, 4));
            stuff4.Add(new ElectricParameters(1, 1));
            Console.WriteLine("\nDistinct\n");
            foreach (var source in stuff4.OfType<ElectricParameters>().Distinct())
            {
                Console.WriteLine(source);
            }

            Console.WriteLine("\nSelect\n");
            foreach (var result in stuff4.OfType<Generator>().Select(obj => obj.OutputCurrent))
            {
                Console.WriteLine(result);
            }

            Console.WriteLine("\nJoin\n");
            foreach (var result in stuff4.Join(stuff3, stuff4element => stuff4element, stuff3element => stuff3element, (stuff4element, stuff3element) => new { stuff3element.GetType().Name, stuff4element.GetType().FullName }))
            {
                Console.WriteLine(result);
            }


            Console.WriteLine("\nOrderByDescending and ThenByDescending\n");
            foreach (var source in stuff4.OrderByDescending(obj => obj.GetType().Name).ThenByDescending(obj => obj.GetType().Namespace))
            {
                Console.WriteLine(source + " " + source.GetType().Name);
            }

            Console.WriteLine("\nGroupBy\n");
            var b2 = stuff4.GroupBy(obj => obj.GetType().Name);
            foreach (var VARIABLE in b2)
            {
                Console.WriteLine(VARIABLE.Key);
            }


            Console.WriteLine("\nConcat\n");
            foreach (var source in stuff.Concat(stuff4))
            {
                Console.WriteLine(source);
            }


            Console.WriteLine("\nLast\n");
            try
            {
                Console.WriteLine(stuff4.Concat(stuff3).Last());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine(stuff.Aggregate("\nAggregation of types: ", (current, obj) => current + "\n\t" + obj.GetType().FullName));

            Console.WriteLine("\nSequence equal: {0}", stuff.SequenceEqual(stuff));

            Console.WriteLine("\nRepeating random angles\n");
            foreach (var result in Enumerable.Repeat(new Angle(), 4))
            {
                Console.WriteLine(result);
            }


            Console.WriteLine("\nClosures\n");
            Func<Angle, Angle> assignment = AngleMiltiplierProvider();
            Angle arg = new Angle(100);
            Angle arg2 = assignment(arg);
            Console.WriteLine(arg2);
            arg2 = assignment(arg2);
            Console.WriteLine(arg2);
        }

        public static Func<Angle, Angle> AngleMiltiplierProvider()
        {
            double multiplier = 2.5;
            Func<Angle, Angle> multiply = delegate (Angle angle)
            {
                multiplier += 1;
                Angle a = new Angle((int)(multiplier * Angle.ToSeconds(angle)));
                return a;
            };
            return multiply;
        }

        public static List<object> trylinq(List<object> list)
        {
            List<object> final = new List<object>();

            final.AddRange(list.Where(o => o.GetType().Name == "ElectricParameters").Select(o => o));
            var subquery = from o1 in list
                           where o1.GetType().Name == "Generator"
                           select o1;

            final.AddRange(subquery);
            return final;
        }
    }
}