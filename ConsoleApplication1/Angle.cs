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

        private int degrees;
        private int arcminutes;
        private int arcseconds;

        public int Degrees
        {
            get { return degrees; }
            set { degrees = value; }
        }

        public int Arcminutes
        {
            get { return arcminutes; }
            set
            {
                if (value > 59 || value < -59)
                {
                    degrees += value / 60;
                    arcminutes = value % 60;
                    return;
                }
                arcminutes = value;
            }
        }

        public int Arcseconds
        {
            get { return arcseconds; }
            set
            {
                if (value > 59 || value < -59)
                {
                    arcminutes += value / 60;
                    arcseconds = value % 60;
                    return;
                }
                arcseconds = value;
            }
        }

        public Angle(int arcseconds)
        {
            Degrees = arcseconds / 3600;
            Arcminutes = (arcseconds % 3600) / 60;
            this.Arcseconds = arcseconds % 60;
        }

        public Angle() : this(new Random().Next(0, 5000)) { }

        public Angle(int d, int m, int s)
        {
            Degrees = d;
            Arcminutes = m;
            Arcseconds = s;
        }

        public Angle(Angle obj)
        {
            Degrees = obj.Degrees;
            Arcminutes = obj.Arcminutes;
            Arcseconds = obj.Arcseconds;
        }

        public static int ToSeconds(Angle obj)
        {
            return obj.Degrees * 3600 + obj.Arcminutes * 60 + obj.Arcseconds;
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
            return obj * multiplier;
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
            return String.Format("Degrees: {0}, minutes of arc: {1}, seconds of arc: {2}", Degrees, Arcminutes, Arcseconds);
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

        public static bool operator <(Angle obj1, Angle obj2)
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