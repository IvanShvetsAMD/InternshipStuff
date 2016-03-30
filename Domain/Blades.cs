namespace Domain
{
    public abstract class Blade : Entity
    {
        private int _length;
        private int _chord;
        private readonly string _materialType;

        public virtual int Length
        {
            get { return _length; }
            protected set { _length = value; }
        }

        public virtual int Chord
        {
            get { return _chord; }
            protected set { _chord = value; }
        }

        public virtual string MaterialType
        {
            get { return _materialType; }
        }

        public Blade()
        {
            
        }

        public Blade(int length, int chord, string materialType)
        {
            Length = length;
            Chord = chord;
            _materialType = materialType;
        }
    }

    public class TurbineBlade : Blade
    {
        private readonly bool _hasCoolingChannels;
        private readonly int _maxTemp;
        private Spool _parentSpool;

        public virtual int MaxTemp
        {
            get { return _maxTemp; }
        }

        public virtual bool HasCoolingChannels
        {
            get { return _hasCoolingChannels; }
        }

        public virtual Spool ParentSpool
        {
            get { return _parentSpool; }
            set { _parentSpool = value; }
        }

        public TurbineBlade()
        {
            
        }

        public TurbineBlade(int maxtemp, bool hascoolingchannels, int length, int chord, string materialType):base(length, chord, materialType)
        {
            _parentSpool = null;
            _maxTemp = maxtemp;
            _hasCoolingChannels = hascoolingchannels;
        }
    }

    public class RotorBlade : Blade
    {
        private readonly bool _hasSupersonicTip;
        private RotorCraft _parentAircraft;

        public virtual bool HasSupersonicTip
        {
            get { return _hasSupersonicTip; }
        }

        public virtual RotorCraft ParentAircraft
        {
            get { return _parentAircraft; }
            set { _parentAircraft = value; }
        }

        public RotorBlade()
        {
            
        }

        public RotorBlade(bool hassupersonictip, int length, int chord, string materialType) : base(length, chord, materialType)
        {
            _parentAircraft = null;
            _hasSupersonicTip = hassupersonictip;
        }
    }
}