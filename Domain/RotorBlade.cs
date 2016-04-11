namespace Domain
{
    public class RotorBlade : Blade
    {
        private readonly bool _hasSupersonicTip;
        private RotorCraft _parentAircraft;

        public virtual bool HasSupersonicTip
        {
            get { return _hasSupersonicTip; }
        }

        public virtual RotorCraft ParentAircraft
        {
            get { return _parentAircraft; }
            set { _parentAircraft = value; }
        }

        public RotorBlade()
        {
            
        }

        public RotorBlade(bool hassupersonictip, int length, int chord, string materialType) : base(length, chord, materialType)
        {
            _parentAircraft = null;
            _hasSupersonicTip = hassupersonictip;
        }
    }
}