using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Aircraft : Entity
    {
        private List<IAviationAdministration> aviationAdministrations;
        private bool isOperational;
        public string Manufacturer { get; }
        public string Model { get; }
        public int MaxTakeoffWeight { get; private set; }
        public int Vne { get; private set; }
        public string SerialNumber { get; }

        public bool IsOperational
        {
            get { return isOperational; }
            set
            {
                isOperational = value;
                if (value == false)
                    NotifyOfCrash();
            }
        }


        public void ReleaseParkingBrake()
        {
            Console.WriteLine("Parking brake released.");
        }

        public void SetParkingBrake()
        {
            Console.WriteLine("Parking brake set.");
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, model: {Model}, maximum takeoff weight: {MaxTakeoffWeight}, Vne: {Vne}, Serial number: {SerialNumber}";
        }

        public void Subscribe(IAviationAdministration administration)
        {
            if(!aviationAdministrations.Contains(administration))
                aviationAdministrations.Add(administration);
        }

        public void Unsubscribe(IAviationAdministration administration)
        {
            if (aviationAdministrations.Contains(administration))
                aviationAdministrations.Remove(administration);
        }

        public void NotifyOfCrash()
        {
            foreach (var aviationAdministration in aviationAdministrations)
            {
                aviationAdministration.GetNotifiedAboutCrash(this);
            }
        }

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            aviationAdministrations = new List<IAviationAdministration>();
            Manufacturer = manufacturer;
            Model = model;
            MaxTakeoffWeight = maxTOweight;
            Vne = vne;
            SerialNumber = serialnumber;
            IsOperational = true;
        }

        protected Aircraft() { }
    }
}