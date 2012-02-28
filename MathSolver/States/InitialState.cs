namespace MathSolver.States
{
    public class InitialState : BaseState
    {
        public InitialState()
        {
            Transitions.Add(new Transition(@"\(", new EnclosedExpressionEnteringState()));
            Transitions.Add(new Transition(@"[+\-]", new SignEnteredState()));
            Transitions.Add(new Transition(@"[0-9\.]", new CoeficientOrSimpleExpressionState()));
            Transitions.Add(new Transition("[A-Z]", new FunctionOrVariableEnteringState()));
        }
    }
}