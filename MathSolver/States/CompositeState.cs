namespace MathSolver.States
{
    public class CompositeState : SignedState

    {
        private IState _containedState;

        protected IState ContainedState
        {
            get
            {
                if (_containedState == null)
                    _containedState = new InitialState();
                return _containedState;
            }
            set { _containedState = value; }
        }

        public override bool IsFinalState
        {
            get { return ContainedState.IsFinalState; }
        }
    }
}