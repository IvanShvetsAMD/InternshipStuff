using System.Collections.Generic;

namespace Domain
{
    public class RocketEngine : JetEngine
    {
        private readonly bool _isReignitable;
        private readonly string _nozzleBellType;

        public virtual bool IsReignitable
        {
            get { return _isReignitable; }
        }

        public virtual string NozzleBellType
        {
            get { return _nozzleBellType; }
        }

        public override string ToString()
        {
            return base.ToString() + "Nozzle bell type: " + NozzleBellType +
                   (IsReignitable ? ", Engine is reignitable" : ", Engine is not regnitable");
        }

        public RocketEngine()
        {
            
        }

        public RocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraft, fuelflow, stat)
        {
            _isReignitable = isreignitable;
            _nozzleBellType = nozzlebelltype;
        }
    }
}