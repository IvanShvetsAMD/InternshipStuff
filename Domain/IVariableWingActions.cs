namespace Domain
{
    public interface IVariableWingActions
    {
        void DecreaseAngle(float Angle);
        void IncreaseAngle(float Angle);
        void SweepMaxBack();
        void SweepMaxForward();
    }
}
