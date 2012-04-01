using MathSolver.Functions;
using MathSolver.States;

namespace MathSolver
{
    public class Parser : ITokenParser
    {
        #region ITokenParser Members

        private ChainedFunctionFactory _factory;
        public IExpression Parse(string text)
        {
            IState state = new InitialState();
            if (_factory!=null)
            {
                state.FunctionFactory = _factory;
            }
            foreach (char c in text)
            {
                state = state.Process(c);
            }
            if (state.IsFinalState)
                return state.CreateExpression();
            return null;
        }
        public void RegisterFunctionFactory(IFunctionFactory factory)
        {
            if (_factory==null)
            {
                _factory=new ChainedFunctionFactory();
            }
            _factory.RegisterFactory(factory);
        }

        #endregion
    }
}