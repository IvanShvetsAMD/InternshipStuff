using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Angle
    {
        public int dergees { get; set; }
        public int arcminutes { get; set; }
        public int arcseconds { get; set; }

        public Angle(int arcseconds)
        {
            dergees = arcseconds / 3600;
            arcminutes = arcseconds % 3600;
            this.arcseconds = arcseconds % 60;
        }

        public Angle(int d, int m, int s)
        {
            dergees = d;
            arcminutes = m;
            arcseconds = s;
        }

        public Angle(Angle obj)
        {
            dergees = obj.dergees;
            arcminutes = obj.arcminutes;
            arcseconds = obj.arcseconds;
        }

        public static int ToSeconds(Angle obj)
        {
            return obj.dergees*3600 + obj.arcminutes*60 + obj.arcseconds;
        }
        public static Angle operator +(Angle obj1, Angle obj2)
        {
            return new Angle(Angle.ToSeconds(obj1) + Angle.ToSeconds(obj2));
        }
    }
}
