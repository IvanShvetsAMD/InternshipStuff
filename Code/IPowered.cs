using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    interface IEnginePowerManagement
    {
        void DecreasePower(Engine engine);
        void IncreasePower(Engine engine);
        float GetCurrentPower(Engine engine);
        float GetTotalCurrentPower();
    }

    interface IEngineStartStop
    {
        void StartEngine(Engine engine);
        void StopEngine(Engine engine);
    }


    interface IPowered : IEnginePowerManagement, IEngineStartStop
    {
        void MaxPower(Engine engine);
        void IdlePower(Engine engine);
    }
}