namespace Domain
{
    interface ILighterThanAir
    {
        void DumpBallast(uint mass);
        void ShiftGas(int OriginCompartment, int DestinationComnpartment,  float Volume);
    }
}