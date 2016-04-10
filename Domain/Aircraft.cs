using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Aircraft : Entity
    {
        private List<IAviationAdministration> aviationAdministrations;
        private bool isOperational;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _maxTakeoffWeight;
        private readonly int _vne;
        private readonly string _serialNumber;

        public virtual string Manufacturer
        {
            get { return _manufacturer; }
        }

        public virtual string Model
        {
            get { return _model; }
        }

        public virtual int MaxTakeoffWeight
        {
            get { return _maxTakeoffWeight; }
        }

        public virtual int Vne
        {
            get { return _vne; }
        }

        public virtual string SerialNumber
        {
            get { return _serialNumber; }
        }

        public virtual bool IsOperational
        {
            get { return isOperational; }
            set
            {
                isOperational = value;
                if (value == false)
                   NotifyOfCrash();
            }
        }


        public virtual void ReleaseParkingBrake()
        {
            Console.WriteLine("Parking brake released.");
        }

        public virtual void SetParkingBrake()
        {
            Console.WriteLine("Parking brake set.");
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, model: {Model}, maximum takeoff weight: {MaxTakeoffWeight}, Vne: {Vne}, Serial number: {SerialNumber}";
        }

        public virtual void Subscribe(IAviationAdministration administration)
        {
            if (!aviationAdministrations.Contains(administration))
                aviationAdministrations.Add(administration);
        }

        public virtual void Unsubscribe(IAviationAdministration administration)
        {
            if (aviationAdministrations.Contains(administration))
                aviationAdministrations.Remove(administration);
        }

        public virtual void NotifyOfCrash()
        {
            foreach (var aviationAdministration in aviationAdministrations)
            {
                aviationAdministration.GetNotifiedAboutCrash(this);
            }
        }

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            aviationAdministrations = new List<IAviationAdministration>();
            _manufacturer = manufacturer;
            _model = model;
            _maxTakeoffWeight = maxTOweight;
            _vne = vne;
            _serialNumber = serialnumber;
            isOperational = true;
        }

        protected Aircraft()
        {
            
        }
    }
}