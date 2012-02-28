using MathSolver.States;

namespace MathSolver
{
    public class Parser : ITokenParser
    {
        #region ITokenParser Members

        public IExpression Parse(string text)
        {
            IState state = new InitialState();
            foreach (char c in text)
            {
                state = state.Process(c);
            }
            if (state.IsFinalState)
                return state.CreateExpression();
            return null;
        }

        #endregion
    }
}