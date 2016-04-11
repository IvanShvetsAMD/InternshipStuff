namespace Domain
{
    public class TurbineBlade : Blade
    {
        private readonly int _maxTemp;
        private readonly bool _hasCoolingChannels;
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
            protected set { _parentSpool = value; }
        }

        public TurbineBlade()
        {
            
        }

        public TurbineBlade(int maxtemp, bool hascoolingchannels, int length, int chord, string materialType, Spool parentSpool = null):base(length, chord, materialType)
        {
            _maxTemp = maxtemp;
            _hasCoolingChannels = hascoolingchannels;
            _parentSpool = parentSpool;
        }
    }
}