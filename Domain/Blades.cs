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
}