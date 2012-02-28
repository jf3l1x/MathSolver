using System;
using System.Collections.Generic;

namespace MathSolver.Functions
{
    public abstract class FunctionExpression : IExpression
    {
        private readonly int _maxParameters;
        private readonly int _minParameters;

        private readonly List<IExpression> _parameters;
        private Sign _sign;

        public FunctionExpression(int minimumParameters, int maximumParameters)
        {
            _sign = Sign.Positive;
            _minParameters = minimumParameters;
            _maxParameters = maximumParameters;
            _parameters = new List<IExpression>();
        }

        public Sign Sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        protected List<IExpression> Parameters
        {
            get { return _parameters; }
        }

        #region IExpression Members

        public abstract double Calc(IVariableResolver resolver);

        #endregion

        public void AddParameter(params IExpression[] parameters)
        {
            foreach (IExpression e in parameters)
            {
                if (_parameters.Count == _maxParameters)
                    throw new InvalidOperationException();
                _parameters.Add(e);
            }
        }

        protected double GetParameterValue(int position, IVariableResolver resolver)
        {
            return _parameters[position].Calc(resolver);
        }

        protected virtual void ValidateParameters()
        {
            if (Parameters.Count < _minParameters)
                throw new InvalidOperationException();
            if (Parameters.Count > _maxParameters)
                throw new InvalidOperationException();
        }

        protected double AddSign(double value)
        {
            if (Sign == Sign.Negative)
                return value*-1;
            return value;
        }
    }
}