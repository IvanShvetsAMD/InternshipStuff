using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SideTasts
{
    abstract class SoundSystem : IOnOff
    {
        private int outputDb;

        public int OutputDb
        {
            get { return outputDb; }
            set { outputDb = value; }
        }

        public virtual void StartEquipment()
        {
            Console.WriteLine("Sound equipent ready.");
        }

        public virtual void StopEquipment()
        {
            Console.WriteLine("Shutting down the sound output");
            OutputDb = 0;
        }

        public SoundSystem(int outoutdb)
        {
            OutputDb = outoutdb;
        }
    }

    class Speaker : SoundSystem
    {
        public int UpperRange { get; }
        public int LowerRange { get; }

        public override void StartEquipment()
        {
            Console.WriteLine("Speakers ready to sound");
        }

        public override void StopEquipment()
        {
            Console.WriteLine("Shutting down the speakers");
            OutputDb = 0;
        }

        public override string ToString()
        {
            return String.Format("Speaker - Output decibells: {0}, upper range: {1}, lower range: {2}", OutputDb, UpperRange, LowerRange);
        }

        public Speaker(int outputdb, int up) : this(outputdb, up, 0) { }

        public Speaker(int low) : this(100, 22000, low) { }

        public Speaker(int outputdb, int up, int low) : base(outputdb)
        {
            UpperRange = up;
            LowerRange = low;
        }
    }

    class Amplifier : SoundSystem, ISignalManager
    {
        public float GainRatio { get; set; }
        public Amplifier(int outoutdb, float gr) : base(outoutdb)
        {
            GainRatio = gr;
        }

        public override void StartEquipment()
        {
            Console.WriteLine("Amps are waiting for signals");
        }

        public override void StopEquipment()
        {
            Console.WriteLine("Shutting down the amps");
            OutputDb = 0;
        }

        public void ClearSignal()
        {
            Console.WriteLine("Signal cleaned of noise");
        }

        public void Distort(string instrument)
        {
            Console.WriteLine("Channel for instrument({0}) distorted", instrument);
        }

        public override string ToString()
        {
            return String.Format("Amplifier - Output decibells: {0}, gain ratio: {1}", OutputDb, GainRatio);
        }
    }
}