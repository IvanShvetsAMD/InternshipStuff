namespace Domain
{
    public class TurbineBlade : Blade
    {
        private readonly int _maxTemp;
        private readonly bool _hasCoolingChannels;

        public virtual int MaxTemp
        {
            get { return _maxTemp; }
        }

        public virtual bool HasCoolingChannels
        {
            get { return _hasCoolingChannels; }
        }

        public TurbineBlade(int maxtemp, bool hascoolingchannels, int length, int chord, string materialType):base(length, chord, materialType)
        {
            _maxTemp = maxtemp;
            _hasCoolingChannels = hascoolingchannels;
        }
    }
}