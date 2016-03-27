using System;
using System.Collections.Generic;

namespace Domain
{
    public class Spool : Entity
    {
        private readonly IList<TurbineBlade> _blades;
        private readonly string _type;

        public virtual IList<TurbineBlade> Blades
        {
            get { return _blades; }
        }

        public virtual string Type
        {
            get { return _type; }
        }

        public Spool(List<TurbineBlade> blades, string type )
        {
            _blades = blades;
            _type = type;
        }

        [Obsolete]
        public Spool()
        {
            
        }
    }
}