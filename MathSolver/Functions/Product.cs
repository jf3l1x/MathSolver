namespace MathSolver.Functions
{
    public class Product : Sum
    {
        protected override double Calc(double left, double right)
        {
            return left*right;
        }
    }
}