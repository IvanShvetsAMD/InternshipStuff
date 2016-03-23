using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;

namespace SideTasts
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

            for (int i = 1; (i <= list.Count - 1) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < list.Count - 1; j++)
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
            Console.WriteLine("Helo, World!");

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

            //List<object> stuff = new List<object>
            //{
            //    new Generator(4, 4),
            //    new Angle(3, 4, 5),
            //    new Generator(3, 8),
            //    new Angle(400),
            //    new Generator(220, 10),
            //    new ElectricParameters(1, 1)
            //};

            //List<object> stuff2 = new List<object>(stuff);
            //List<object> stuff3 = new List<object>(stuff);
            //List<object> stuff4 = new List<object>(stuff);

            //Console.WriteLine("Original collection:\n");
            //foreach (var obj in stuff)
            //{
            //    Console.WriteLine(obj.GetType().Name);
            //}

            //ArrangeDelegate arrangeDelegate = new ArrangeDelegate(RearrangeMethod1);
            //stuff = Rearrange(stuff, arrangeDelegate);
            //Console.WriteLine("\nAfter the first rearrangement(delegate)\n");
            //foreach (var obj in stuff)
            //{
            //    Console.WriteLine(obj.GetType().Name);
            //}

            //stuff2 = Rearrange(stuff2, delegate (object obj1, object obj2)
            //{
            //    if (obj1 is Generator)
            //        return true;
            //    if (obj1 is ElectricParameters && obj2 is Angle)
            //        return true;
            //    if (obj1 is Angle)
            //        return false;
            //    return false;
            //}
            //);

            //Console.WriteLine("\nAfter second rearrangement (anonymous function)\n");
            //foreach (var obj in stuff2)
            //{
            //    Console.WriteLine(obj.GetType().Name);
            //}


            //stuff3 = Rearrange(stuff3, (obj1, obj2) =>
            //{
            //    if (obj1 is Angle)
            //        return true;
            //    if (obj1 is ElectricParameters && obj2 is Generator)
            //        return true;
            //    if (obj1 is Generator)
            //        return false;
            //    return false;
            //});
            //Console.WriteLine("\nafter N3\n");
            //foreach (var o in stuff3)
            //{
            //    Console.WriteLine(o.GetType().Name);
            //}

            //Console.WriteLine("\nUsing an extension method:\n");
            //var b = stuff.Change((obj1, obj2) =>
            //{
            //    if (obj1 is Angle)
            //        return true;
            //    if (obj1 is ElectricParameters && obj2 is Generator)
            //        return true;
            //    if (obj1 is Generator)
            //        return false;
            //    return false;
            //});

            //foreach (var o in b)
            //{
            //    Console.WriteLine(o.GetType().Name);
            //}

            //Console.WriteLine("\nLINQ\n");
            //foreach (var o in Trylinq(stuff))
            //{
            //    Console.WriteLine(o.GetType().Name);
            //}

            #endregion

            #region 

            //stuff4.Add(new Generator(4, 4));
            //stuff4.Add(new ElectricParameters(1, 1));
            //Console.WriteLine("\nDistinct\n");
            //foreach (var source in stuff4.OfType<ElectricParameters>().Distinct())
            //{
            //    Console.WriteLine(source);
            //}

            //Console.WriteLine("\nSelect\n");
            //foreach (var result in stuff4.OfType<Generator>().Select(obj => obj.OutputCurrent))
            //{
            //    Console.WriteLine(result);
            //}

            //Console.WriteLine("\nJoin\n");
            //foreach (
            //    var result in
            //        stuff4.Join(stuff3, stuff4element => stuff4element, stuff3element => stuff3element,
            //            (stuff4element, stuff3element) =>
            //                new {stuff3element.GetType().Name, stuff4element.GetType().FullName}))
            //{
            //    Console.WriteLine(result);
            //}


            //Console.WriteLine("\nOrderByDescending and ThenByDescending\n");
            //foreach (
            //    var source in
            //        stuff4.OrderByDescending(obj => obj.GetType().Name).ThenByDescending(obj => obj.GetType().Namespace)
            //    )
            //{
            //    Console.WriteLine(source + " " + source.GetType().Name);
            //}

            //Console.WriteLine("\nGroupBy\n");
            //var b2 = stuff4.GroupBy(obj => obj.GetType().Name);
            //foreach (var VARIABLE in b2)
            //{
            //    Console.WriteLine(VARIABLE.Key);
            //}


            //Console.WriteLine("\nConcat\n");
            //foreach (var source in stuff.Concat(stuff4))
            //{
            //    Console.WriteLine(source);
            //}

            //stuff4.ForEach(obj => Console.WriteLine(obj));
            //Console.WriteLine("\nLast\n");
            //try
            //{
            //    Console.WriteLine(stuff4.Concat(stuff3).Last(o => o.GetType().Name == "Angle"));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //List<int> ints = new List<int> {1, 2, 3, 4, 5, 6};


            //bool hasFive = ints.Any(i => i == 5);

            DateTime dt = new DateTime();
            dt = DateTime.Now;

            DateTimeOffset dto = new DateTimeOffset();
            dto = DateTimeOffset.Now;


            //Console.WriteLine(stuff.Aggregate("\nAggregation of types: ",
            //    (current, obj) => current + "\n\t" + obj.GetType().FullName));

            //Console.WriteLine("\nSequence equal: {0}", stuff.SequenceEqual(stuff));

            //Console.WriteLine("\nRepeating random angles\n");
            //foreach (var result in Enumerable.Repeat(new Angle(), 4))
            //{
            //    Console.WriteLine(result);
            //}


            //Console.WriteLine("\nClosures\n");
            //Func<Angle, Angle> assignment = AngleMiltiplierProvider();
            //Angle arg = new Angle(100);
            //Angle arg2 = assignment(arg);
            //Console.WriteLine(arg2);
            //arg2 = assignment(arg2);
            //Console.WriteLine(arg2);

            #endregion


            Console.WriteLine("\n\n\n");
            List<Action> list = new List<Action>();
            foreach (var i in new int[] { 1, 2, 3, 4, 5 })
            {
                list.Add(() => Console.WriteLine(i));
            }
            foreach (var f in list)
            {
                f();
            }
            Console.WriteLine("\n\n\n");

            #region 

            //Person magnus = new Person {Name = "Hedlund, Magnus"};
            //Person terry = new Person {Name = "Adams, Terry"};
            //Person charlotte = new Person {Name = "Weiss, Charlotte"};

            //Pet barley = new Pet {Name = "Barley", Owner = terry};
            //Pet boots = new Pet {Name = "Boots", Owner = terry};
            //Pet whiskers = new Pet {Name = "Whiskers", Owner = charlotte};
            //Pet daisy = new Pet {Name = "Daisy", Owner = magnus};
            //List<Person> people = new List<Person> {magnus, terry, charlotte};
            //List<Pet> pets = new List<Pet> {barley, boots, whiskers, daisy};
            //var query =
            //    people.Join(pets,
            //        person => person,
            //        pet => pet.Owner,
            //        (person, pet) =>
            //            new {OwnerName = person.Name, Pet = pet.Name});

            //foreach (var VARIABLE in query)
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            //Console.WriteLine("\n\n");

            //foreach (
            //    var result in
            //        people.GroupJoin(pets, person => person, pet => pet.Owner,
            //            (person, pet) => new {OwnerName = person.Name, PetsList = pet}))
            //{
            //    Console.WriteLine(result);
            //}

            //var query2 = people.GroupJoin(pets, person => person, pet => pet.Owner,
            //    (person, pet) => new {OwnerName = person.Name, PetsList = pet});
            ////    foreach (var VARIABLE in query2)
            ////    {
            ////        Console.WriteLine(VARIABLE.OwnerName);
            ////        foreach (var VARIABLE2 in VARIABLE.PetsList)
            ////        {
            ////            Console.WriteLine(VARIABLE2.Name + VARIABLE.PetsList.ToList().ForEach(x =>
            ////            {
            ////                Console.WriteLine(x.Name);
            ////            }).ToString());
            ////        }
            ////    }

            //query2.ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x.OwnerName);
            //    x.PetsList.ToList().ForEach(x2 => { Console.WriteLine(x2.Name); });
            //});

            #endregion



            string connectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    var sqlCommandText = "IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.AircraftRegistry') AND Type = N'U')BEGIN DROP TABLE[AircraftRegistry] END; CREATE TABLE AircraftRegistry([EntryID] int IDENTITY(1, 1), [SerialNumber] int NOT NULL, [Registration] nvarchar(10), [RegistrationDate] date);";
                    using (var sqlCommand = new SqlCommand(sqlCommandText, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlCommandText =
                        "IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Aircraft') AND Type = N'U')BEGIN DROP TABLE[Aircraft] END; CREATE TABLE Aircraft([SerialNumber] int IDENTITY(1, 1) NOT NULL,[Registration] nvarchar(10) NOT NULL,[Owner] nvarchar(50),[RegistrationDate]date,CONSTRAINT[Aircraft_PK] PRIMARY KEY([SerialNumber], [Registration]),CONSTRAINT[Aircraft_Registration_UNIQUE] UNIQUE(Registration))";
                    using (var sqlCommand = new SqlCommand(sqlCommandText, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            string sqlCommandText2 = "SELECT * FROM AircraftRegistry;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandText2, connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                adapter.SelectCommand = new SqlCommand(sqlCommandText2, connection);
                sqlCommandText2 = "INSERT INTO [AircraftRegistry]([SerialNumber],[Registration],[RegistrationDate])VALUES(@SerialNumber, @Registration, @RegistrationDate); SET IDENTITY_INSERT [AircraftRegistry] OFF;";
                var insert = new SqlCommand(sqlCommandText2, connection);
                insert.Parameters.Add("@SerialNumber", SqlDbType.Int, Int32.MaxValue, "SerialNumber");
                insert.Parameters.Add("@Registration", SqlDbType.NVarChar, 2000, "Registration");
                insert.Parameters.Add("@RegistrationDate", SqlDbType.Date, 1000, "RegistrationDate");
                adapter.InsertCommand = insert;


                sqlCommandText2 = "UPDATE [dbo].[AircraftRegistry] SET[AircraftRegistry].[SerialNumber] = @SerialNUmber, [AircraftRegistry].[Registration] = @Registration, [AircraftRegistry].[RegistrationDate] = @RegistrationDate";
                var update = new SqlCommand(sqlCommandText2, connection);
                update.Parameters.Add("@SerialNumber", SqlDbType.Int, Int32.MaxValue, "SerialNumber");
                update.Parameters.Add("@Registration", SqlDbType.NVarChar, 2000, "Registration");
                update.Parameters.Add("@RegistrationDate", SqlDbType.Date, 1000, "RegistrationDate");
                adapter.UpdateCommand = update;


                sqlCommandText2 = "DELETE FROM [dbo].[AircraftRegistry] WHERE[dbo].[AircraftRegistry].[SerialNumber] = @SerialNumber;";
                var delete = new SqlCommand(sqlCommandText2, connection);
                delete.Parameters.Add("@SerialNumber", SqlDbType.Int, 1000, "SerialNumber");
                adapter.DeleteCommand = delete;


                //DataTable Aircraft = new DataTable("Aircraft");
                //Aircraft.Columns.Add("Registration", typeof (string));
                //Aircraft.Columns.Add("Owner", typeof (string));
                //Aircraft.Columns.Add("RegistrationDate", typeof (DateTime));

                //DataRow row = Aircraft.NewRow();
                //row["Registration"] = "B-HXJ";
                //row["Owner"] = "Cathay Pacific";
                //row["RegistrationDate"] = "1998-07-28";

                //Aircraft.Rows.Add(row);

                DataTable AircraftRegistry = new DataTable("AircraftRegistry");
                DataSet dataSet = new DataSet();

                //AircraftRegistry.Columns.Add("EntryID", typeof(int));
                AircraftRegistry.Columns.Add("SerialNumber", typeof(int));
                AircraftRegistry.Columns.Add("Registration", typeof(string));
                AircraftRegistry.Columns.Add("RegistrationDate", typeof(DateTime));


                //INSERT
                DataRow regRow = AircraftRegistry.NewRow();
                //regRow["EntryID"] = 8;
                regRow["SerialNumber"] = 8;
                regRow["Registration"] = "B-HXJ";
                regRow["RegistrationDate"] = "1998-07-28";

                AircraftRegistry.Rows.Add(regRow);

                DataRow regRow2 = AircraftRegistry.NewRow();
                regRow2["SerialNumber"] = 9;
                regRow2["Registration"] = "UR-82060";
                regRow2["RegistrationDate"] = "1998-05-01";

                AircraftRegistry.Rows.Add(regRow2);

                DataRow regRow3 = AircraftRegistry.NewRow();
                regRow3["SerialNumber"] = 10;
                regRow3["Registration"] = "A7-ALA";
                regRow3["RegistrationDate"] = "2013-12-18";

                AircraftRegistry.Rows.Add(regRow3);

                DataRow regRow4 = AircraftRegistry.NewRow();
                regRow4["SerialNumber"] = 9999;
                regRow4["Registration"] = "FAKE";
                regRow4["RegistrationDate"] = DBNull.Value;

                AircraftRegistry.Rows.Add(regRow4);

                adapter.Update(AircraftRegistry);

                //SELECT
                adapter.Fill(dataSet, "AircraftRegistry");
                ShowResults(dataSet);

                //UPDATE
                DataRow changedRow = dataSet.Tables["AircraftRegistry"].Select("SerialNumber = 10").First();
                changedRow["RegistrationDate"] = "2014-12-18";

                //adapter.Update(AircraftRegistry);
                ShowResults(dataSet);
                
                for (int i = 0; i < AircraftRegistry.Rows.Count; i++)
                {
                    DataRow dr = AircraftRegistry.Rows[i];
                    if ((int)dr["SerialNumber"] > 11)
                        dr.Delete();
                }

                adapter.Update(AircraftRegistry);
                dataSet.Tables["AircraftRegistry"].Clear();
                adapter.Fill(dataSet, "AircraftRegistry");

                ShowResults(dataSet);
            }
        }

        private static void ShowResults(DataSet dataSet)
        {
            var table = dataSet.Tables["AircraftRegistry"];
            Console.WriteLine("\nDispalying results:");
            foreach (DataRow innerrow in table.Rows)
            {
                if (innerrow.RowState != DataRowState.Deleted)
                {
                    Console.WriteLine("EntryID: {0}, Serial number: {1}, Registration: {2}, Registration date: {3}",
                        innerrow?["EntryID"] ?? "NULL", innerrow?["SerialNumber"], innerrow?["Registration"],
                        innerrow?["RegistrationDate"] ?? "NULL");
                }
            }
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

        public static IEnumerable<object> Trylinq(List<object> list)
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

    class Person
    {
        public string Name { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
}