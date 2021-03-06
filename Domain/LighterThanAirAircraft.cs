using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class LighterThanAirAircraft : PoweredAircraft, ILighterThanAir
    {
        private ILiftingGasPumpModule _gasManager = new SafeGasPumpManager();
        private int _ballastMass;
        private readonly string _gasType;
        private readonly float _gasVolume;
        private readonly IList<GasCompartment> _compartments;

        public virtual ILiftingGasPumpModule GasManager
        {
            get { return _gasManager; }
            set { _gasManager = value; }
        }

        public virtual int BallastMass
        {
            get { return _ballastMass; }
            protected set { _ballastMass = value; }
        }

        public virtual string GasType
        {
            get { return _gasType; }
        }

        public virtual float GasVolume
        {
            get { return _gasVolume; }
        }

        public virtual IList<GasCompartment> Compartments
        {
            get { return _compartments.ToList(); }
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat("\n ballast mass: {0}, gas type: {1}, gas volume {2}\n Gas compartments:", BallastMass, GasType, GasVolume);

            foreach (var gasCompartment in Compartments)
            {
                final.AppendFormat("\n\tCompartment number: {0}, {1} ", Compartments.IndexOf(gasCompartment),gasCompartment);
            }
            return final.ToString();
        }

        public virtual void DumpBallast(int mass)
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

        public virtual void ShiftGas(int originCompartment, int destinationCompartment, float volume)
        {
            GasManager.PumpGas(originCompartment, destinationCompartment, compartments: Compartments.ToList(), volume: volume);
        }

        public LighterThanAirAircraft()
        {
            
        }

        public LighterThanAirAircraft(ILiftingGasPumpModule gasManager, int ballastmass, string gastype, List<GasCompartment> compartments, 
            List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            _gasManager = gasManager;
            _ballastMass = ballastmass;
            _gasType = gastype;
            _compartments = compartments;
            _gasVolume = Compartments?.Sum(chamber => chamber.CurrentVolume) ?? 0;
        }
    }
}