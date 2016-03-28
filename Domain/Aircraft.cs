﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Aircraft : Entity
    {
        //private IList<IAviationAdministration> aviationAdministrations;
        private bool isOperational;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _maxTakeoffWeight;
        private readonly int _vne;
        private readonly string _serialNumber;

        public virtual string Manufacturer => _manufacturer;

        public virtual string Model => _model;

        public virtual int MaxTakeoffWeight => _maxTakeoffWeight;

        public virtual int Vne => _vne;

        public virtual string SerialNumber => _serialNumber;

        public bool IsOperational
        {
            get { return isOperational; }
            set
            {
                isOperational = value;
                //if (value == false)
                //    NotifyOfCrash();
            }
        }

        //public IList<IAviationAdministration> AviationAdministrations
        //{
        //    get { return aviationAdministrations; }
        //    set { aviationAdministrations = value; }
        //}


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

        //public void Subscribe(IAviationAdministration administration)
        //{
        //    if(!aviationAdministrations.Contains(administration))
        //        aviationAdministrations.Add(administration);
        //}

        //public void Unsubscribe(IAviationAdministration administration)
        //{
        //    if (aviationAdministrations.Contains(administration))
        //        aviationAdministrations.Remove(administration);
        //}

        //public void NotifyOfCrash()
        //{
        //    foreach (var aviationAdministration in aviationAdministrations)
        //    {
        //        aviationAdministration.GetNotifiedAboutCrash(this);
        //    }
        //}

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            //aviationAdministrations = new List<IAviationAdministration>();
            _manufacturer = manufacturer;
            _model = model;
            _maxTakeoffWeight = maxTOweight;
            _vne = vne;
            _serialNumber = serialnumber;
            isOperational = true;
        }

        protected Aircraft() { }
    }
}