using System;
using System.Collections.Generic;

namespace Domain
{
    public class Generator : Entity
    {
        public virtual float OutputCurrent { get; protected set; }
        public virtual float OutputVoltage { get; protected set; }

        public virtual void GenerateCurrent() {
            Console.WriteLine("Generating current");
        }

        public Generator() { }

        public Generator(float c, float v)
        {
            OutputCurrent = c;
            OutputVoltage = v;
        }

        public override string ToString()
        {
            return String.Format("generator current: {0}, voltage: {1}", OutputCurrent, OutputVoltage);
        }
    }

    public class GeneratorComparer : IEqualityComparer<Generator>
    {
        public bool Equals(Generator x, Generator y)
        {
            return NearlyEqual(x.OutputCurrent, y.OutputCurrent, 0.00001f) && NearlyEqual(x.OutputVoltage, y.OutputVoltage, 0.00001f);
        }

        public int GetHashCode(Generator obj)
        {
            return obj.ToString().GetHashCode();
        }

        public bool NearlyEqual(float a, float b, float epsilon)
        {
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b)
                return true;
            if (a == 0 || b == 0 || diff < float.Epsilon)
                return diff < epsilon;
            return diff / (absA + absB) < epsilon;
        }
    }
}