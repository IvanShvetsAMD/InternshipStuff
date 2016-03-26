using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FixedWingAircraft : HeavierThanAirAircraft
    {
        public List<Wing> Wings { get; set; }
        public int? CruiseSpeed { get; }
        public int? StallSpeed { get; }

        public FixedWingAircraft(List<Wing> wings, int cruisespeed, int stallspeed, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            Wings = wings;
            CruiseSpeed = cruisespeed;
            StallSpeed = stallspeed;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", cruise speed: {0}, stall speed: {1}", CruiseSpeed, StallSpeed);
            return final.ToString();
        }
    }
}