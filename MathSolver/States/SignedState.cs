namespace MathSolver.States
{
    public abstract class SignedState : BaseState
    {
        private Sign _sign;

        protected SignedState()
        {
            _sign = Sign.Positive;
        }

        protected Sign Sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        public override void Enter(IState from, char c)
        {
            base.Enter(from, c);
            if (from != this)
                _sign = SignEnteredState.GetSign(from);
        }
    }
}