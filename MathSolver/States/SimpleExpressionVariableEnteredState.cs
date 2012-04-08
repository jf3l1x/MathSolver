namespace MathSolver.States
{
    public class SimpleExpressionVariableEnteredState : SimpleExpressionCoeficientEnteredState
    {
        public double Exponent
        {
            get { return GetDoubleFromBuffer(); }
        }

        protected override void CreateTransitions()
        {
            Transitions.Add(new Transition(@"[0-9\.]", this));
            Transitions.Add(new Transition(@"[\!\+\-/*\|&\<\>\=]", new OperatorEnteringState(){ FunctionFactory = FunctionFactory }));
        }

        protected override void SetExpressionData(SimpleExpression expression)
        {
            expression.Exponent = Exponent;
        }
    }
}