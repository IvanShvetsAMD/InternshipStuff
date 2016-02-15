using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    interface IPowered
    {
        void DecreasePower(int EngineNumber);
        void IncreasePower(int EngineNumber);
        float GetCurrentPower(int EngineNumber);
        float GetTotalCurrentPower();
        void StartEngine(int EngineNumber);
        void StopEngine(int EngineNumber);
    }
}
