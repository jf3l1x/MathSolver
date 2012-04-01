using System.Collections.Generic;

namespace MathSolver.Functions
{
    public class ChainedFunctionFactory : IFunctionFactory
    {
        private readonly IFunctionFactory _defaultFunctionFactory;
        private readonly IList<IFunctionFactory> _factories;

        public ChainedFunctionFactory()
        {
            _defaultFunctionFactory = new FunctionFactory();
            _factories = new List<IFunctionFactory>();
        }

        #region IFunctionFactory Members

        public IFunctionExpression CreateFunction(string name)
        {
            IFunctionExpression retval = _defaultFunctionFactory.CreateFunction(name);
            if (retval == null)
            {
                foreach (IFunctionFactory functionFactory in _factories)
                {
                    if (functionFactory!=null)
                    {
                        retval = functionFactory.CreateFunction(name);
                        if (retval != null)
                        {
                            break;
                        }    
                    }
                    
                }
            }
            return retval;
        }

        #endregion

        public void RegisterFactory(IFunctionFactory factory)
        {
            _factories.Add(factory);
        }
    }
}