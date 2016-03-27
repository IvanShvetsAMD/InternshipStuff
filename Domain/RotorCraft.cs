using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RotorCraft : HeavierThanAirAircraft
    {
        private readonly IList<RotorBlade> _rotorBlades;
        private readonly string _rotorType;
        //public int NumberOfRotors { get; private set; }
        public virtual IList<RotorBlade> RotorBlades
        {
            get { return _rotorBlades; }
        }

        public virtual string RotorType
        {
            get { return _rotorType; }
        }

        void EjectRotorBlades() => RotorBlades.Clear();

        public RotorCraft() { }

        public RotorCraft(/*int numberofrotors,*/ List<RotorBlade> rotorblades, string rotortype, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            //NumberOfRotors = numberofrotors;
            _rotorBlades = rotorblades;
            _rotorType = rotortype;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", number of rotors: {0}, type of rotor: {1}", /*NumberOfRotors,*/RotorBlades.Count, RotorType);
            return final.ToString();
        }
    }
}