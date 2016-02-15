using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

        public static Angle operator -(Angle obj1, Angle obj2)
        {
            return new Angle(Angle.ToSeconds(obj1) - Angle.ToSeconds(obj2));
        }

        public static Angle operator *(Angle obj, int multiplier)
        {
            return new Angle(Angle.ToSeconds(obj) * multiplier);
        }

        public static Angle operator *(int multiplier, Angle obj)
        {
            return obj*multiplier;
        }

        public static Angle operator /(Angle obj, int divisor)
        {
            return new Angle(Angle.ToSeconds(obj) / divisor);
        }

        public static Angle operator /(int divisor, Angle obj)
        {
            return new Angle(Angle.ToSeconds(obj) / divisor);
        }

        public override string ToString()
        {
            return String.Format("Degrees: {0}, minutes of arc: {1}, seconds of arc: {2}", dergees, arcminutes, arcseconds);
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == ToString();
        }

        public static bool Equals(Angle obj1, Angle obj2)
        {
            return obj1.ToString() == obj2.ToString();
        }

        public static bool operator ==(Angle obj1, Angle obj2)
        {
            return Equals(obj1, obj2);
        }

        public static bool operator !=(Angle obj1, Angle obj2)
        {
            return !Equals(obj1, obj2);
        }

        public static bool operator >(Angle obj1, Angle obj2)
        {
            return Angle.ToSeconds(obj1) > Angle.ToSeconds(obj2);
        }

        public static bool operator < (Angle obj1, Angle obj2)
        {
            return Angle.ToSeconds(obj1) < Angle.ToSeconds(obj2);
        }

        public static bool operator >=(Angle obj1, Angle obj2)
        {
            return Angle.ToSeconds(obj1) >= Angle.ToSeconds(obj2);
        }

        public static bool operator <=(Angle obj1, Angle obj2)
        {
            return Angle.ToSeconds(obj1) <= Angle.ToSeconds(obj2);
        }
    }
}