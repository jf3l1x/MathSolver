namespace MathSolver.States
{
    public class InitialState : BaseState
    {
        public InitialState()
        {
            Transitions.Add(new Transition(@"\(", new EnclosedExpressionEnteringState(){FunctionFactory = FunctionFactory}));
            Transitions.Add(new Transition(@"[+\-]", new SignEnteredState() { FunctionFactory = FunctionFactory }));
            Transitions.Add(new Transition(@"[0-9\.]", new CoeficientOrSimpleExpressionState() { FunctionFactory = FunctionFactory }));
            Transitions.Add(new Transition("[A-Z]", new FunctionOrVariableEnteringState() { FunctionFactory = FunctionFactory }));
        }
    }
}