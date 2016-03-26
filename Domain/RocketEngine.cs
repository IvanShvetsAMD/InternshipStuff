using System.Collections.Generic;

namespace Domain
{
    public class RocketEngine : JetEngine
    {
        public bool IsReignitable { get; private set; }
        public string NozzleBellType { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "Nozzle bell type: " + NozzleBellType +
                   (IsReignitable ? ", Engine is reignitable" : ", Engine is not regnitable");
        }

        public RocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraftID, fuelflow, stat)
        {
            IsReignitable = isreignitable;
            NozzleBellType = nozzlebelltype;
        }
    }
}