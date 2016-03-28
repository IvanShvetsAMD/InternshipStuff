using System;
using System.Collections.Generic;

namespace Domain
{
    public class Generator : Entity
    {
        private float _outputCurrent;
        private float _outputVoltage;
        private TurbineEngine _parentEngine;

        public virtual float OutputCurrent
        {
            get { return _outputCurrent; }
            protected set { _outputCurrent = value; }
        }

        public virtual float OutputVoltage
        {
            get { return _outputVoltage; }
            protected set { _outputVoltage = value; }
        }

        public virtual TurbineEngine ParentEngine
        {
            get { return _parentEngine; }
            protected set { _parentEngine = value; }
        }

        public virtual void IncreaseCurrent(float delta)
        {
            _outputCurrent += delta;
        }

        public virtual void IncreaseVoltage(float delta)
        {
            _outputVoltage += delta;
        }

        public virtual void GenerateCurrent() {
            Console.WriteLine("Generating current");
        }

        public Generator() { }

        public Generator(float c, float v, TurbineEngine engine = null)
        {
            _outputCurrent = c;
            _outputVoltage = v;
            _parentEngine = engine;
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