using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain;

namespace Factories
{
    public class TurbineEngineFactory
    {
        static readonly Lazy<TurbineEngineFactory> LazyInstance = new Lazy<TurbineEngineFactory>(() => new TurbineEngineFactory(), true);

        //static TurbineEngineFactory() { }

        private TurbineEngineFactory() { }

        public static TurbineEngineFactory GeTurbineEngineFactory() => LazyInstance.Value;

        public Turbofan MakeTurbofan(float bypassratio, int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
                                    int numberofcycles, List<Propellant> fueList, List<Oxidiser> oxidisers, string manuf, string model,
                                    string serialnumber, float maxpower, float operatingtime, float fuelflow, OnOff stat, bool isgeared = false,
                                    bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            //return new Turbofan(3, false, true, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
            //                    new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //                    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0, OnOff.Stopped);

            GeneralConditionsChecker(numberofshafts, spools, fueList, oxidisers, serialnumber);


            Debug.WriteLine("Creating a new turbofan ({0})", serialnumber);
            return new Turbofan(bypassratio, isgeared, hasreverse, numberofshafts, gen, spools, egt, isp,
                numberofcycles, fueList, oxidisers,
                manuf, model, serialnumber, maxpower, operatingtime, parentvehicle, fuelflow, stat);
        }

        public bool TryMakeTurbofan(float bypassratio, int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
                                    int numberofcycles, List<Propellant> fueList, List<Oxidiser> oxidisers, string manuf, string model,
                                    string serialnumber, float maxpower, float operatingtime, float fuelflow, OnOff stat, out Turbofan incomingTurbofan, bool isgeared = false,
                                    bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            try
            {
                Turbofan turbofan = MakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared, hasreverse,
                    parentvehicle);

                incomingTurbofan = turbofan;
                return true;
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                incomingTurbofan = null;
                return false;
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                incomingTurbofan = null;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                incomingTurbofan = null;
                return false;
            }
        }


        public Turbofan TryMakeTurbofan(float bypassratio, int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
                                        int numberofcycles, List<Propellant> fueList, List<Oxidiser> oxidisers, string manuf, string model,
                                        string serialnumber, float maxpower, float operatingtime, float fuelflow, OnOff stat, bool isgeared = false,
                                        bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            Turbofan turbofan = new Turbofan();

            try
            {
                turbofan = MakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared, hasreverse,
                    parentvehicle);
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                switch (argumentNullException.ParamName)
                {
                    case nameof(spools):
                        spools = new List<Spool>();
                        TryMakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared,
                            hasreverse,
                            parentvehicle);
                        break;
                    case nameof(serialnumber):
                        serialnumber = "no serial number specified";
                        TryMakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared,
                            hasreverse,
                            parentvehicle);
                        break;
                    case nameof(fueList):
                        fueList = new List<Propellant>();
                        TryMakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared,
                            hasreverse,
                            parentvehicle);
                        break;
                    case nameof(oxidisers):
                        oxidisers = new List<Oxidiser>();
                        TryMakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared,
                            hasreverse,
                            parentvehicle);
                        break;
                }
            }
            catch (ArgumentException argumentException) when (argumentException.ParamName == nameof(numberofshafts))
            {
                Console.WriteLine(argumentException.Message);
                if (argumentException.ParamName == nameof(numberofshafts))
                {
                    numberofshafts = 1;
                    TryMakeTurbofan(bypassratio, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared,
                            hasreverse,
                            parentvehicle);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return turbofan;
        }

        public Turboshaft MakeTurboshaft(float gearingR, float maxtorque, int numberofshafts, Generator gen,
                                        List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> fueList,
                                        List<Oxidiser> oxidisers, string manuf, string model, string serialnumber, float maxpower,
                                        float operatingtime, float fuelflow, OnOff stat, bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            GeneralConditionsChecker(numberofshafts, spools, fueList, oxidisers, serialnumber);

            if (maxtorque <= 0)
                throw new ArgumentException("No max torque data was provided", nameof(maxtorque));

            return new Turboshaft(gearingR, maxtorque, hasreverse, numberofshafts, gen, spools, egt, isp,
                numberofcycles, fueList,
                oxidisers, manuf, model, serialnumber, maxpower, operatingtime, parentvehicle, fuelflow, stat);

        }

        //public bool TryMakeTurboshaft(float gearingR, float maxtorque, uint numberofshafts,
        //    Dictionary<Generator, double> gens,
        //    List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> fueList,
        //    List<Oxidisers> oxidisers, string manuf, string model, string serialnumber, float maxpower,
        //    float operatingtime, float fuelflow, OnOff stat, out Turboshaft incomingTurboshaft, bool hasreverse = true, string parentvehicleID = null)
        //{
        //    try
        //    {
        //        Turboshaft turboshaft = MakeTurboshaft(gearingR, maxtorque, numberofshafts, gens, spools, egt, isp,
        //            numberofcycles, fueList,
        //            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
        //            parentvehicleID);

        //        incomingTurboshaft = turboshaft;
        //        return true;
        //    }
        //    catch (ArgumentNullException argumentNullException)
        //    {
        //        Console.WriteLine(argumentNullException.Message);
        //        incomingTurboshaft = null;
        //        return false;
        //    }
        //    catch (ArgumentException argumentException)
        //    {
        //        Console.WriteLine(argumentException.Message);
        //        incomingTurboshaft = null;
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        incomingTurboshaft = null;
        //        return false;
        //    }
        //}


        public Turboshaft TryMakeTurboshaft(float gearingR, float maxtorque, int numberofshafts, Generator gen,
                                            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> fueList,
                                            List<Oxidiser> oxidisers, string manuf, string model, string serialnumber, float maxpower,
                                            float operatingtime, float fuelflow, OnOff stat, bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            Turboshaft turboshaft = new Turboshaft();

            try
            {
                turboshaft = MakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                    parentvehicle);
                return turboshaft;
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                switch (argumentNullException.ParamName)
                {
                    case nameof(spools):
                        spools = new List<Spool>();
                        turboshaft = TryMakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(serialnumber):
                        serialnumber = "no serial number specified";
                        turboshaft = TryMakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(fueList):
                        fueList = new List<Propellant>();
                        turboshaft = TryMakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(oxidisers):
                        oxidisers = new List<Oxidiser>();
                        turboshaft = TryMakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                switch (argumentException.ParamName)
                {
                    case nameof(numberofshafts):
                        numberofshafts = 1;
                        turboshaft = TryMakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(maxtorque):
                        maxtorque = 1;
                        turboshaft = TryMakeTurboshaft(gearingR, maxtorque, numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return turboshaft;
        }
        private void GeneralConditionsChecker(int numberofshafts, List<Spool> spools, List<Propellant> fueList, List<Oxidiser> oxidisers, string serialnumber)
        {
            if (numberofshafts < 1)
                throw new ArgumentException("There could be no turbofan with less than one shaft", nameof(numberofshafts));
            if (spools == null)
                throw new ArgumentNullException(nameof(spools), "A turbine engine has to have some spools");
            if (fueList == null)
                throw new ArgumentNullException(nameof(fueList),
                    "The engine needs fuels, otherwise the very notion of an engine becomes meaningless.");
            if (oxidisers == null)
                throw new ArgumentNullException(nameof(oxidisers),
                    "The engine needs oxidisers, otherwise the very notion of an engine becomes meaningless.");
            if (string.IsNullOrWhiteSpace(serialnumber))
                throw new ArgumentNullException(nameof(serialnumber), "No serial number provided");
        }

        public Turbojet MakeTurbojet(int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp, int numberofcycles,
                                     List<Propellant> fueList, List<Oxidiser> oxidisers, string manuf, string model, string serialnumber, float maxpower,
                                     float operatingtime, float fuelflow, OnOff stat, bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            GeneralConditionsChecker(numberofshafts, spools, fueList, oxidisers, serialnumber);

            return new Turbojet(hasreverse, numberofshafts, gen, spools, egt, isp,
                numberofcycles, fueList,
                oxidisers, manuf, model, serialnumber, maxpower, operatingtime, parentvehicle, fuelflow, stat);
        }

        public bool TryMakeTurbojet(int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> fueList,
                                    List<Oxidiser> oxidisers, string manuf, string model, string serialnumber, float maxpower, float operatingtime,
                                    float fuelflow, OnOff stat, out Turbojet incomingTurbojet, bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            try
            {
                Turbojet turbojet = MakeTurbojet(numberofshafts, gen, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                    parentvehicle);
                incomingTurbojet = turbojet;
                return true;
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                incomingTurbojet = null;
                return false;
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                incomingTurbojet = null;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                incomingTurbojet = null;
                return false;
            }
        }

        public Turbojet TryMakeTurbojet(int numberofshafts, Generator gen, List<Spool> spools,
            int egt, int isp, int numberofcycles,
            List<Propellant> fueList, List<Oxidiser> oxidisers, string manuf, string model, string serialnumber,
            float maxpower,
            float operatingtime, float fuelflow, OnOff stat, bool hasreverse = true, PoweredAircraft parentvehicle = null)
        {
            Turbojet turbojet = new Turbojet();

            try
            {
                turbojet = MakeTurbojet(numberofshafts, gen, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                    parentvehicle);
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                switch (argumentNullException.ParamName)
                {
                    case nameof(spools):
                        spools = new List<Spool>();
                        turbojet = TryMakeTurbojet(numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(serialnumber):
                        serialnumber = "no serial number specified";
                        turbojet = TryMakeTurbojet(numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(fueList):
                        fueList = new List<Propellant>();
                        turbojet = TryMakeTurbojet(numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                    case nameof(oxidisers):
                        oxidisers = new List<Oxidiser>();
                        turbojet = TryMakeTurbojet(numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                        break;
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                if (argumentException.ParamName == nameof(numberofshafts))
                {
                    numberofshafts = 1;
                    turbojet = TryMakeTurbojet(numberofshafts, gen, spools, egt, isp,
                            numberofcycles, fueList,
                            oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                            parentvehicle);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return turbojet;
        }
    }
}