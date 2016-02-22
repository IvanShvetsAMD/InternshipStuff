using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    interface ILighterThanAir
    {
        void DumpBallast(uint TankNumber, uint mass);
        void ShiftGas(uint OriginCompartment, uint DestinationComnpartment,  float Volume);
    }
}