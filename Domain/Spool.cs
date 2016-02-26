using System.Collections.Generic;

namespace Domain
{
    public class Spool
    {
        protected List<TurbineBlade> Blades { get; private set; }
        protected string Type { get; }

        public Spool(List<TurbineBlade> blades, string type )
        {
            Blades = blades;
            Type = type;
        }
    }
}