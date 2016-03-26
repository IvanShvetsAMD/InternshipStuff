using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class LighterThanAirAircraft : PoweredAircraft, ILighterThanAir
    {
        public ILiftingGasPumpModule GasManager { get; set; } = new SafeGasPumpManager();
        public uint BallastMass { get; private set; }
        public string GasType { get; private set; }
        //public float GasVolume { get; private set; }
        public List<GasCompartment> Compartments { get; }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat("\n ballast mass: {0}, gas type: {1}, gas volume {2}\n Gas compartments:", BallastMass, GasType /*,GasVolume*/);

            foreach (var gasCompartment in Compartments)
            {
                final.AppendFormat("\n\tCompartment number: {0}, {1} ", Compartments.IndexOf(gasCompartment),gasCompartment);
            }
            return final.ToString();
        }

        public void DumpBallast(uint mass)
        {
            if (BallastMass > mass)
            {
                BallastMass -= mass;
            }
            else
            {
                BallastMass = 0;
            }
        }

        public void ShiftGas(int originCompartment, int destinationCompartment, float volume)
        {
            GasManager.PumpGas(originCompartment, destinationCompartment, compartments: Compartments, volume: volume);
        }

        public LighterThanAirAircraft(ILiftingGasPumpModule gasManager, uint ballastmass, string gastype, List<GasCompartment> compartments, 
            List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            GasManager = gasManager;
            BallastMass = ballastmass;
            GasType = gastype;
            Compartments = compartments;
            //GasVolume = Compartments?.Sum(chamber => chamber.CurrentVolume) ?? 0;
        }
    }
}