using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class Spool
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