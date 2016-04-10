using System;

namespace Domain
{
    public class Propellant : Entity
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

        public virtual PropellantsEnum PropellantEnum
        {
            get { return (PropellantsEnum)IntValue; }
        }

        public Propellant()
        {
            
        }

        public Propellant(PropellantsEnum pr)
        {
            _intValue = (int) pr;
            _name = pr.ToString();
        }

        public Propellant(int value, string name)
        {
            _intValue = value;
            _name = name;
        }
    }
}