namespace Domain
{
    public abstract class Blade : Entity
    {
        private int length;
        private int chord;
        private readonly string materialType;

        public virtual int Length
        {
            get { return length; }
            protected set { length = value; }
        }

        public virtual int Chord
        {
            get { return chord; }
            protected set { chord = value; }
        }

        public virtual string MaterialType
        {
            get { return materialType; }
        }

        public Blade(int bladeLength, int bladeChord, string bladeMaterialType)
        {
            length = bladeLength;
            chord = bladeChord;
            bladeMaterialType = materialType;
        }
    }

    public class TurbineBlade : Blade
    {
        public int MaxTemp { get; private set; }
        public bool HasCoolingChannels { get; private set; }

        public TurbineBlade(int maxtemp, bool hascoolingchannels, int length, int chord, string materialType):base(length, chord, materialType)
        {
            MaxTemp = maxtemp;
            HasCoolingChannels = hascoolingchannels;
        }
    }

    public class RotorBlade : Blade
    {
        public bool HasSupersonicTip { get; private set; }

        public RotorBlade(bool hassupersonictip, int length, int chord, string materialType) : base(length, chord, materialType)
        {
            HasSupersonicTip = hassupersonictip;
        }
    }
}