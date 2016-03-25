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
}