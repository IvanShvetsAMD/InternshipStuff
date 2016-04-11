using System;

namespace Domain
{
    public class Oxidiser : Entity
    {
        private int _intValue;
        private string _name;

        public virtual int IntValue
        {
            get { return _intValue; }
            protected set { _intValue = value; }
        }

        public virtual String Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public virtual OxidisersEnum PropellantEnum
        {
            get { return (OxidisersEnum)IntValue; }
        }

        public Oxidiser()
        {

        }

        public Oxidiser(OxidisersEnum ox)
        {
            _intValue = (int)ox;
            _name = ox.ToString();
        }

        public Oxidiser(int value, string name)
        {
            _intValue = value;
            _name = name;
        }
    }
}