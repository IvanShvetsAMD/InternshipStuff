namespace Domain
{
    interface ILighterThanAir
    {
        void DumpBallast(int mass);
        void ShiftGas(int originCompartment, int destinationCompartment,  float volume);
    }
}