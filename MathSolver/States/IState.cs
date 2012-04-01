using System.Collections.Generic;
using MathSolver.Functions;

namespace MathSolver.States
{
    public interface IState
    {
        bool IsFinalState { get; }
        string Buffer { get; }
        IList<ITransition> Transitions { get; }
        IState Process(char c);
        void Enter(IState from, char c);
        IExpression CreateExpression();
        IFunctionFactory FunctionFactory { get; set; }
    }
}