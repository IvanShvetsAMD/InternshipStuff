using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideTasts
{
    abstract class LightingSystem : IOnOff
    {
        private int outputWatts;

        public int OutputWatts
        {
            get { return outputWatts; }
            set { outputWatts = value; }
        }

        public virtual void StartEquipment()
        {
            Console.WriteLine("Equipent ready to light up.");
        }

        public virtual void StopEquipment()
        {
            Console.WriteLine("Shutting down the lights");
            OutputWatts = 0;
        }

        public LightingSystem(int output)
        {
            OutputWatts = output;
        }
    }

    class LaserSystem : LightingSystem
    {
        private string laserpattern;

        public string LaserPattern
        {
            get { return laserpattern; }
            set { laserpattern = value; }
        }

        public override void StartEquipment()
        {
            Console.WriteLine("Laser equipent ready to light up.");
        }

        public override void StopEquipment()
        {
            Console.WriteLine("Shutting down the laser lights");
            OutputWatts = 0;
        }

        public override string ToString()
        {
            return String.Format("Laser - Output wattage: {0}, laser pattern: {1}", OutputWatts, LaserPattern);
        }

        public LaserSystem(int output, string pattern = "default") : base(output)
        {
            LaserPattern = pattern;
        }
    }

    class Projector : LightingSystem, IImageCorrector
    {
        private byte[] image;

        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        public int WhiteBallance { get; set; }

        public void ClearSignal()
        {
            Console.WriteLine("Image noise removed");
        }

        public void Distort(string instrument)
        {
            Console.WriteLine("Image distorted to a trapezoid");
        }

        public void AdjustWhiteBallance()
        {
            Console.WriteLine("White ballance adjusted");
            WhiteBallance = 10;
        }

        public override void StartEquipment()
        {
            Console.WriteLine("Projection equipent ready to light up.");
        }

        public override void StopEquipment()
        {
            Console.WriteLine("Shutting down the regular lights");
            OutputWatts = 0;
        }

        public override string ToString()
        {
            return String.Format("Projectors - Output wattage: {0}, white balance: {1}", OutputWatts, WhiteBallance);
        }

        public Projector(int output, byte[] im) : this(output, im, 0) { }
        public Projector(int output, byte[] im, int wb) : base(output)
        {
            Image = im;
            WhiteBallance = wb;
        }
    }
}