﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class TurbineEngineFactory
    {
        static readonly Lazy<TurbineEngineFactory> LazyInstance = new Lazy<TurbineEngineFactory>(() => new TurbineEngineFactory(), true);

        static TurbineEngineFactory() { }

        private TurbineEngineFactory() { }

        public static TurbineEngineFactory GeTurbineEngineFactoryFactory() => LazyInstance.Value;

        public Turbofan MakeTurbofan(float bypassratio, uint numberofshafts, Dictionary<Generator, double> gens,
            List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellants> fueList, List<Oxidisers> oxidisers, string manuf, string model,
            string serialnumber,
            float maxpower, float operatingtime, float fuelflow, OnOff stat, bool isgeared = false,
            bool hasreverse = true, string parentvehicleID = null)
        {
            //return new Turbofan(3, false, true, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
            //                    new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //                    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0, OnOff.Stopped);

            GeneralConditionsChecker(numberofshafts, spools, fueList, oxidisers, serialnumber);


            Debug.WriteLine("Creating a new turbofan ({0})", serialnumber);
            return new Turbofan(bypassratio, isgeared, hasreverse, numberofshafts, gens, spools, egt, isp,
                numberofcycles, fueList, oxidisers,
                manuf, model, serialnumber, maxpower, operatingtime, parentvehicleID, fuelflow, stat);
        }

        public bool TryMakeTurbofan(float bypassratio, uint numberofshafts, Dictionary<Generator, double> gens,
            List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellants> fueList, List<Oxidisers> oxidisers, string manuf, string model,
            string serialnumber,
            float maxpower, float operatingtime, float fuelflow, OnOff stat, out Turbofan incomingTurbofan, bool isgeared = false,
            bool hasreverse = true, string parentvehicleID = null)
        {
            try
            {
                Turbofan turbofan = MakeTurbofan(bypassratio, numberofshafts, gens, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, isgeared, hasreverse,
                    parentvehicleID);

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

        public Turboshaft MakeTurboshaft(float gearingR, float maxtorque, uint numberofshafts,
            Dictionary<Generator, double> gens,
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> fueList,
            List<Oxidisers> oxidisers, string manuf, string model, string serialnumber, float maxpower,
            float operatingtime, float fuelflow, OnOff stat, bool hasreverse = true, string parentvehicleID = null)
        {
            GeneralConditionsChecker(numberofshafts, spools, fueList, oxidisers, serialnumber);

            if (maxtorque <= 0)
                throw new ApplicationException("No max torque data was provided");

            return new Turboshaft(gearingR, maxtorque, hasreverse, numberofshafts, gens, spools, egt, isp,
                numberofcycles, fueList,
                oxidisers, manuf, model, serialnumber, maxpower, operatingtime, parentvehicleID, fuelflow, stat);

        }

        public bool TryMakeTurboshaft(float gearingR, float maxtorque, uint numberofshafts,
            Dictionary<Generator, double> gens,
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> fueList,
            List<Oxidisers> oxidisers, string manuf, string model, string serialnumber, float maxpower,
            float operatingtime, float fuelflow, OnOff stat, out Turboshaft incomingTurboshaft, bool hasreverse = true, string parentvehicleID = null)
        {
            try
            {
                Turboshaft turboshaft = MakeTurboshaft(gearingR, maxtorque, numberofshafts, gens, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                    parentvehicleID);

                incomingTurboshaft = turboshaft;
                return true;
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                incomingTurboshaft = null;
                return false;
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                incomingTurboshaft = null;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                incomingTurboshaft = null;
                return false;
            }
        }

        private void GeneralConditionsChecker(uint numberofshafts, List<Spool> spools, List<Propellants> fueList, List<Oxidisers> oxidisers, string serialnumber)
        {
            if (numberofshafts < 1)
                throw new ArgumentException("There could be no turbofan with less than one shaft");
            if (spools == null)
                throw new ArgumentNullException(nameof(spools), "A turbine engine has to have some spools");
            if (fueList == null || oxidisers == null)
                throw new ArgumentException(
                    "The engine needs fuels and oxidisers, otherwise the very notion of an engine becomes meaningless.");
            if (string.IsNullOrWhiteSpace(serialnumber))
                throw new ArgumentNullException(nameof(serialnumber), "No serial number provided");
        }

        public static Turbojet MakeTurbojet(uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools, int egt, int isp, int numberofcycles,
                                            List<Propellants> fueList, List<Oxidisers> oxidisers, string manuf, string model, string serialnumber, float maxpower,
                                            float operatingtime, float fuelflow, OnOff stat, bool hasreverse = true, string parentvehicleID = null)
        {
            if (numberofshafts < 1)
                throw new ArgumentException("There could be no turbofan with less than one shaft");
            if (spools == null)
                throw new ArgumentNullException(nameof(spools), "A turbine engine has to have some spools");
            if (fueList == null || oxidisers == null)
                throw new ArgumentException(
                    "The engine needs fuels and oxidisers, otherwise the very notion of an engine becomes meaningless.");
            if (string.IsNullOrWhiteSpace(serialnumber))
                throw new ArgumentNullException(nameof(serialnumber), "No serial number provided");

            return new Turbojet(hasreverse, numberofshafts, gens, spools, egt, isp,
                numberofcycles, fueList,
                oxidisers, manuf, model, serialnumber, maxpower, operatingtime, parentvehicleID, fuelflow, stat);
        }

        public bool TryMakeTurbojet(uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools,
            int egt, int isp, int numberofcycles,
            List<Propellants> fueList, List<Oxidisers> oxidisers, string manuf, string model, string serialnumber,
            float maxpower,
            float operatingtime, float fuelflow, OnOff stat, out Turbojet incomingTurbojet, bool hasreverse = true, string parentvehicleID = null)
        {
            try
            {
                Turbojet turbojet = MakeTurbojet(numberofshafts, gens, spools, egt, isp,
                    numberofcycles, fueList,
                    oxidisers, manuf, model, serialnumber, maxpower, operatingtime, fuelflow, stat, hasreverse,
                    parentvehicleID);
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
    }
}