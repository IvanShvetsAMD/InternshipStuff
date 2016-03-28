namespace Domain
{
    public class RotorBlade : Blade
    {
        private readonly bool _hasSupersonicTip;
        private RotorCraft _parentRotorCraft;

        public virtual bool HasSupersonicTip
        {
            get { return _hasSupersonicTip; }
        }

        public virtual RotorCraft ParentRotorCraft
        {
            get { return _parentRotorCraft; }
            protected set { _parentRotorCraft = value; }
        }

        public RotorBlade(bool hassupersonictip, int length, int chord, string materialType, RotorCraft parentRotorCraft = null) : base(length, chord, materialType)
        {
            _hasSupersonicTip = hassupersonictip;
            _parentRotorCraft = parentRotorCraft;
        }
    }
}