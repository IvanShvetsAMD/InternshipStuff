using System;

namespace Domain
{
    public class Propellant : Entity
    {
        private int _intValue;
        private string _name;
        private JetEngine _parentEngine;

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

        public virtual JetEngine ParentEngine
        {
            get { return _parentEngine; }
            set { _parentEngine = value; }
        }

        public Propellant()
        {

        }

        public Propellant(PropellantsEnum pr)
        {
            _parentEngine = null;
            _intValue = (int)pr;
            _name = pr.ToString();
        }

        public Propellant(int value, string name)
        {
            _parentEngine = null;
            _intValue = value;
            _name = name;
        }
    }
}