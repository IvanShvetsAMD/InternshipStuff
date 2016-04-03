using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RotorCraft : HeavierThanAirAircraft
    {
        private readonly int _numberOfRotors;
        private readonly List<RotorBlade> _rotorBlades;
        private readonly string _rotorType;

        public virtual int NumberOfRotors
        {
            get { return _numberOfRotors; }
        }

        public virtual IList<RotorBlade> RotorBlades
        {
            get { return _rotorBlades; }
        }

        public virtual string RotorType
        {
            get { return _rotorType; }
        }

        protected virtual void EjectRotorBlades() => RotorBlades.Clear();

        public RotorCraft() { }

        public RotorCraft(int numberofrotors, List<RotorBlade> rotorblades, string rotortype, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            _numberOfRotors = numberofrotors;
            _rotorBlades = rotorblades;
            _rotorType = rotortype;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", number of rotors: {0}, type of rotor: {1}", NumberOfRotors, RotorType);
            return final.ToString();
        }
    }
}