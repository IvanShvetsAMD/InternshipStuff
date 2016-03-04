using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITurbineEngine
    {
        void StartGenerator();
        void StopGenerator();
        void Decorate(ITurbineEngineComponent component = null);
    }

    public abstract class TurbineEngineDecorator : ITurbineEngine
    {
        protected ITurbineEngine TurbineEngineInstance { get; set; }
        public abstract void StartGenerator();

        public abstract void StopGenerator();

        public abstract void Decorate(ITurbineEngineComponent component);

        public TurbineEngineDecorator(ITurbineEngine engine)
        {
            TurbineEngineInstance = engine;
        }
    }

    public class ReheatDecorator : TurbineEngineDecorator
    {
        public ReheatChamber Reheat { get; private set; }
        public override void StartGenerator()
        {
            TurbineEngineInstance?.StartGenerator();
        }

        public override void StopGenerator()
        {
            TurbineEngineInstance?.StopGenerator();
        }

        public override void Decorate(ITurbineEngineComponent reheat)
        {
            if (reheat is ReheatChamber)
            {
                Reheat = (ReheatChamber)reheat;
                Reheat.Disengage();
                return;
            }
            throw new ArgumentException("ReheatDecorator.Decorate", nameof(reheat));
        }

        public ReheatDecorator(ITurbineEngine engine) : base(engine) { }

        public override string ToString()
        {
            return string.Format("{0}\n{1}", TurbineEngineInstance, Reheat);
        }
    }

    public class DumpAndBurnDecorator : TurbineEngineDecorator
    {
        public FuelDumper DumpandBurn { get; private set; }
        public DumpAndBurnDecorator(ITurbineEngine engine) : base(engine) { }

        public override void StartGenerator()
        {
            TurbineEngineInstance?.StartGenerator();
        }

        public override void StopGenerator()
        {
            TurbineEngineInstance?.StopGenerator();
        }

        public override void Decorate(ITurbineEngineComponent component)
        {
            //DumpandBurn = (FuelDumper) component;
            //DumpandBurn.Disengage();
            if (component is FuelDumper)
            {
                DumpandBurn = (FuelDumper)component;
                DumpandBurn.Disengage();
                return;
            }
            throw new ArgumentException("DumpAndBurnDecorator.Decorate", nameof(component));
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}", TurbineEngineInstance, DumpandBurn);
        }
    }


    public interface ITurbineEngineComponent
    {
        void Engage();
        void Disengage();
    }

    public class ReheatChamber : ITurbineEngineComponent
    {
        public int Temp { get; private set; }
        public double MaxThrustMultiplier { get; private set; }
        public double CurrentThrustMultiplier { get; private set; }

        public ReheatChamber(double maxmultiplier)
        {
            MaxThrustMultiplier = maxmultiplier;
        }
        //public void EngageReheat()
        //{
        //    CurrentThrustMultiplier = MaxThrustMultiplier;
        //    Temp = 900;
        //}

        //public void DisengageReheat()
        //{
        //    CurrentThrustMultiplier = 1;
        //    Temp = 400;
        //}

        //public void Engage()
        //{
        //    EngageReheat();
        //}

        //public void Disengage()
        //{
        //    DisengageReheat();
        //}

        public void Engage()
        {
            CurrentThrustMultiplier = MaxThrustMultiplier;
            Temp = 900;
        }

        public void Disengage()
        {
            CurrentThrustMultiplier = 1;
            Temp = 400;
        }

        public override string ToString()
        {
            return String.Format("Reheat is {0}", CurrentThrustMultiplier == MaxThrustMultiplier ? "engaged" : "disengaged");
        }
    }

    public class FuelDumper : ITurbineEngineComponent
    {
        public double MaxFuelFlowMultiplier { get; private set; }
        public double CurrentFuelFlowMultiplier { get; private set; }

        public void Engage()
        {
            CurrentFuelFlowMultiplier = MaxFuelFlowMultiplier;
        }

        public void Disengage()
        {
            CurrentFuelFlowMultiplier = 1;
        }

        public FuelDumper(double maxmultiplier)
        {
            MaxFuelFlowMultiplier = maxmultiplier;
        }

        public override string ToString()
        {
            return String.Format("Dump-and-burn is {0} currently in progress", CurrentFuelFlowMultiplier == MaxFuelFlowMultiplier ? "" : "not");
        }
    }
}