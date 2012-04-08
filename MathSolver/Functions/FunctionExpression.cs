using System;
using System.Collections.Generic;
using System.Text;

namespace MathSolver.Functions
{
    public abstract class FunctionExpression : IFunctionExpression
    {
      
        private readonly List<IExpression> _parameters;

        public FunctionExpression(int minimumParameters, int maximumParameters)
        {
            Sign = Sign.Positive;
            MinParameters = minimumParameters;
            MaxParameters = maximumParameters;
            _parameters = new List<IExpression>();
        }

        public abstract string Name { get; }
        public Sign Sign { get; set; }

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
                if (_parameters.Count == MaxParameters)
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
            if (Parameters.Count < MinParameters)
                throw new InvalidOperationException();
            if (Parameters.Count > MaxParameters)
                throw new InvalidOperationException();
        }

        protected double AddSign(double value)
        {
            if (Sign == Sign.Negative)
                return value*-1;
            return value;
        }

        public int MinParameters { get; set; }
        public int MaxParameters { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Sign == Sign.Negative ? "-": string.Empty);
            sb.Append(Name);
            sb.Append("(");
            foreach (var expression in Parameters)
            {
                sb.Append(expression.ToString());
                sb.Append(",");
            }
            if (Parameters.Count>0)
            {
                sb.Remove(sb.Length-1, 1);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}