using System.Collections.Generic;

namespace Domain
{
    public class HeavierThanAirAircraft : PoweredAircraft
    {
        public HeavierThanAirAircraft(List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {

        }

        protected HeavierThanAirAircraft() { }
    }
}