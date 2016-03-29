using System.Collections.Generic;

namespace Domain
{
    public class Spool : Entity
    {
        private readonly List<TurbineBlade> _blades;
        private readonly string _type;
        private TurbineEngine _parentEngine;

        public virtual IList<TurbineBlade> Blades
        {
            get { return _blades; }
        }

        public virtual string Type
        {
            get { return _type; }
        }

        public virtual TurbineEngine ParentEngine
        {
            get { return _parentEngine; }
            set { _parentEngine = value; }
        }

        public Spool()
        {
            
        }

        public Spool(List<TurbineBlade> blades, string type )
        {
            _parentEngine = null;
            _blades = blades;
            _type = type;
        }
    }
}