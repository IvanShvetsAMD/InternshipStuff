namespace Domain
{
    interface ILighterThanAir
    {
        void DumpBallast(uint TankNumber, uint mass);
        void ShiftGas(uint OriginCompartment, uint DestinationComnpartment,  float Volume);
    }
}