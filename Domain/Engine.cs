using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Engine : Entity
    {
        private readonly string _manufacturer;
        private readonly string _model;
        private float _currentPower;
        private readonly string _serialNumber;
        private float _maxPower;
        private readonly float _operatingTime;
        private readonly Aircraft _parentAircraft;
        private float _fuelFlow;
        private OnOff _onOffStatus;


        public virtual string Manufacturer
        {
            get { return _manufacturer; }
        }

        public virtual string Model
        {
            get { return _model; }
        }

        public virtual float CurrentPower
        {
            get { return _currentPower; }
            protected set { _currentPower = value; }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
        }

        public virtual float MaxPower
        {
            get { return _maxPower; }
            protected set { _maxPower = value; }
        }

        public virtual float OperatingTime
        {
            get { return _operatingTime; }
        }

        public virtual Aircraft ParentAircraft
        {
            get { return _parentAircraft; }
        }

        public virtual float FuelFlow
        {
            get { return _fuelFlow; }
            set { _fuelFlow = value; }
        }

        public virtual OnOff OnOffStatus
        {
            get { return _onOffStatus; }
            set { _onOffStatus = value; }
        }

        public override string ToString()
        {
            return
                String.Format(
                    ", Manufacturer: {0}, model: {1}, current power setting: {2}, serial number: {3}, maximum power output: {4}, operating time: {5}, parent aircraft: {6}, fuel flow {7}, Status: {8}",
                    Manufacturer, Model, CurrentPower, SerialNumber, MaxPower, OperatingTime, ParentAircraft, FuelFlow,
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
            Aircraft parentaircraft, float fuelflow, OnOff stat)
        {
            _manufacturer = manufacturer;
            _model = model;
            _currentPower = 0;
            _maxPower = maxpower;
            _serialNumber = serialnumber;
            _operatingTime = operatingtime;
            _parentAircraft = parentaircraft;
            _fuelFlow = fuelflow;
            _onOffStatus = stat;
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