namespace MathSolver.States
{
    public class SignEnteredState : BaseState
    {
        public SignEnteredState()
        {
            Transitions.Add(new Transition(@"\(", new EnclosedExpressionEnteringState()));
            Transitions.Add(new Transition(@"[0-9\.]", new CoeficientOrSimpleExpressionState()));
            Transitions.Add(new Transition("[A-Z]", new FunctionOrVariableEnteringState()));
        }

        public Sign Sign
        {
            get
            {
                if (Buffer == "-")
                    return Sign.Negative;
                return Sign.Positive;
            }
        }

        public static Sign GetSign(IState from)
        {
            var s = from as SignEnteredState;
            if (s != null)
                return s.Sign;
            return Sign.Positive;
        }
    }
}