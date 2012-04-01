namespace MathSolver.Functions
{
    public class FunctionFactory : IFunctionFactory
    {
        #region IFunctionFactory Members

        public IFunctionExpression CreateFunction(string name)
        {
            switch (name.ToUpper())
            {
                case "RAIZ":
                case "SQRT":
                    return new Root();
                case "E":
                    return new E();
                case "PI":
                    return new Pi();
                case "LOG":
                    return new Log();
                case "SOMA":
                case "SUM":
                    return new Sum();
                case "PRODUTO":
                case "MUL":
                    return new Product();
                case "SEN":
                    return new Sen();
                case "COS":
                    return new Cos();
                case "TG":
                case "TAN":
                    return new Tan();
                case "EXP":
                    return new Pow();
            }
            return null;
        }

        #endregion
    }
}