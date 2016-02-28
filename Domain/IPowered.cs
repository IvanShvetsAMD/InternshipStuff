namespace Domain
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