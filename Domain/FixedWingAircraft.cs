using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FixedWingAircraft : HeavierThanAirAircraft
    {
        private IList<Wing> _wings;
        private readonly int? _cruiseSpeed;
        private readonly int? _stallSpeed;

        public virtual IList<Wing> Wings
        {
            get { return _wings; }
            set { _wings = value; }
        }

        public virtual int? CruiseSpeed
        {
            get { return _cruiseSpeed; }
        }

        public virtual int? StallSpeed
        {
            get { return _stallSpeed; }
        }

        protected FixedWingAircraft()
        {
            
        }

        public FixedWingAircraft(List<Wing> wings, int cruisespeed, int stallspeed, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            _wings = wings;
            _cruiseSpeed = cruisespeed;
            _stallSpeed = stallspeed;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", cruise speed: {0}, stall speed: {1}", CruiseSpeed, StallSpeed);
            return final.ToString();
        }
    }
}