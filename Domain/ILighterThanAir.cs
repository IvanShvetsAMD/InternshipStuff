namespace Domain
{
    interface ILighterThanAir
    {
        void DumpBallast(uint mass);
        void ShiftGas(int originCompartment, int destinationCompartment,  float volume);
    }
}