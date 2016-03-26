using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RotorCraft : HeavierThanAirAircraft
    {
        //public int NumberOfRotors { get; private set; }
        public List<RotorBlade> RotorBlades { get; private set; }
        public string RotorType { get; private set; }

        void EjectRotorBlades() => RotorBlades.Clear();

        public RotorCraft() { }

        public RotorCraft(/*int numberofrotors,*/ List<RotorBlade> rotorblades, string rotortype, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            //NumberOfRotors = numberofrotors;
            RotorBlades = rotorblades;
            RotorType = rotortype;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", number of rotors: {0}, type of rotor: {1}", /*NumberOfRotors,*/ RotorType);
            return final.ToString();
        }
    }
}