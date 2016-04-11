using System;

namespace Domain
{
    public class Oxidiser : Entity
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

        public virtual OxidisersEnum PropellantEnum
        {
            get { return (OxidisersEnum)IntValue; }
        }

        public virtual JetEngine ParentEngine
        {
            get { return _parentEngine; }
            set { _parentEngine = value; }
        }

        public Oxidiser()
        {

        }

        public Oxidiser(OxidisersEnum ox)
        {
            _parentEngine = null;
            _intValue = (int)ox;
            _name = ox.ToString();
        }

        public Oxidiser(int value, string name)
        {
            _parentEngine = null;
            _intValue = value;
            _name = name;
        }
    }
}