using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideTasts
{
    interface IOnOff
    {
        void StartEquipment();
        void StopEquipment();
    }

    interface ISignalManager
    {
        void ClearSignal();
        void Distort(string instrument);
    }

    interface IImageCorrector : ISignalManager
    {
        void AdjustWhiteBallance();
    }
}
