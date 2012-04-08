namespace MathSolver.Functions
{
    public class Sum : FunctionExpression
    {
        public Sum()
            : base(3, 3)
        {
        }

        protected virtual double Calc(double left, double right)
        {
            return left + right;
        }

        public override double Calc(IVariableResolver resolver)
        {
            ValidateParameters();
            double min = (int)GetParameterValue(1, resolver);
            double max = (int)GetParameterValue(2, resolver);
            double retval = GetParameterValue(0, new ConstantResolver(min));
            for (double i = min + 1; i <= max; i++)
            {

                retval = Calc(retval, GetParameterValue(0,new ConstantResolver(i)));
            }
            return AddSign(retval);
        }
        public override string Name
        {
            get { return "Sum"; }
        }
    }
}