using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    abstract class Blade
    {
        public int Length { get; protected set; }
        public int Chord { get; protected set; }
        public string MaterialType { get; private set; }

        public Blade(int length, int chord, string materialType)
        {
            Length = length;
            Chord = chord;
            MaterialType = materialType;
        }
    }

    class TurbineBlade : Blade
    {
        public int MaxTemp { get; private set; }
        public bool HasCoolingChannels { get; private set; }

        public TurbineBlade(int maxtemp, bool hascoolingchannels, int length, int chord, string materialType):base(length, chord, materialType)
        {
            MaxTemp = maxtemp;
            HasCoolingChannels = hascoolingchannels;
        }
    }

    class RotorBlade : Blade
    {
        public bool HasSupersonicTip { get; private set; }

        public RotorBlade(bool hassupersonictip, int length, int chord, string materialType) : base(length, chord, materialType)
        {
            HasSupersonicTip = hassupersonictip;
        }
    }
}