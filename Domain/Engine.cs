using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Engine : Entity
    {
        public string Manufacturer { get; }
        public string Model { get; }
        public virtual float CurrentPower { get; protected set; }
        public string SerialNumber { get; }
        public virtual float MaxPower { get; protected set; }
        public float OperatingTime { get; private set; }
        public string ParentAircraftID { get; private set; }
        public float FuelFlow { get; set; }
        public OnOff OnOffStatus { get; set; }

        public override string ToString()
        {
            return
                String.Format(
                    ", Manufacturer: {0}, model: {1}, current power setting: {2}, serial number: {3}, maximum power output: {4}, operating time: {5}, parent aircraft: {6}, fuel flow {7}, Status: {8}",
                    Manufacturer, Model, CurrentPower, SerialNumber, MaxPower, OperatingTime, ParentAircraftID, FuelFlow,
                    OnOffStatus);
        }

        public void Cooldown()
        {
            Console.WriteLine("Cooling down started");
        }

        public void Start()
        {
            if (OnOffStatus == OnOff.Running)
                throw new InvalidOperationException("The engine is already running.");

            CurrentPower = 5;
            FuelFlow = 0.5f;
            OnOffStatus = OnOff.Running;
        }

        public void Stop()
        {
            if (OnOffStatus == OnOff.Stopped)
                throw new InvalidOperationException("\nThe engine was already stopped or wasn't even started.");
            CurrentPower = 0;
            FuelFlow = 0f;
            OnOffStatus = OnOff.Stopped;
        }

        public virtual void IncreasePower()
        {
            if (CurrentPower < 96)
            {
                CurrentPower += 5;
                FuelFlow += 0.5f;
            }
            else
            {
                CurrentPower = 100;
                FuelFlow = 10f;
            }
        }

        public virtual void DecreasePower()
        {
            if (CurrentPower > 5)
            {
                CurrentPower -= 5;
                FuelFlow -= 0.5f;
            }
            else
            {
                CurrentPower = 0;
                FuelFlow = 0f;
            }
        }

        public void WarmUp()
        {
            Console.WriteLine("Warming up engine core for 1 minute. Monitor temps afterward.");
        }

        public Engine()
        {

        }

        public Engine(string manufacturer, string model, string serialnumber, float maxpower, float operatingtime,
            string parentaircraftID, float fuelflow, OnOff stat)
        {
            Manufacturer = manufacturer;
            Model = model;
            CurrentPower = 0;
            MaxPower = maxpower;
            SerialNumber = serialnumber;
            OperatingTime = operatingtime;
            ParentAircraftID = parentaircraftID;
            FuelFlow = fuelflow;
            OnOffStatus = stat;
        }

        public class EngineComparer : IEqualityComparer<Engine>
        {
            public bool Equals(Engine x, Engine y)
            {
                return x.SerialNumber == y.SerialNumber;
            }

            public int GetHashCode(Engine obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}