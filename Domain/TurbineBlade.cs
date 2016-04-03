namespace Domain
{
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
}