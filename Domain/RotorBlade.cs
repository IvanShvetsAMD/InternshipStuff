namespace Domain
{
    public class RotorBlade : Blade
    {
        private readonly bool _hasSupersonicTip;

        public virtual bool HasSupersonicTip
        {
            get { return _hasSupersonicTip; }
        }

        public RotorBlade(bool hassupersonictip, int length, int chord, string materialType) : base(length, chord, materialType)
        {
            _hasSupersonicTip = hassupersonictip;
        }
    }
}