using System;
using System.Globalization;
using System.Text;

namespace MathSolver
{
    public enum Sign
    {
        Positive,
        Negative
    }

    public class SimpleExpression : IExpression
    {
        private readonly Sign _sign;
        private double _coeficient;
        private double _exponent;
        private string _variable;

        public SimpleExpression(Sign sign, string variable, double coeficient, double exponent)
        {
            _sign = sign;
            _variable = variable;
            _coeficient = coeficient;
            _exponent = exponent;
        }

        public double Coeficient
        {
            get { return _coeficient; }
            set { _coeficient = value; }
        }

        public string Variable
        {
            get { return _variable; }
            set { _variable = value; }
        }

        public double Exponent
        {
            get { return _exponent; }
            set { _exponent = value; }
        }

        #region IExpression Members

        public double Calc(IVariableResolver variableValue)
        {
            if (_sign == Sign.Positive)
                return _coeficient*Math.Pow(variableValue.Resolve(Variable), _exponent);
            return _coeficient * Math.Pow(variableValue.Resolve(Variable), _exponent) * -1;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_sign == Sign.Negative)
            {
                sb.Append("-");
            }
            if (_coeficient>1 || _exponent==0)
            {
                sb.Append(_coeficient);    
            }
            
            if (_exponent!=0)
            {
                sb.Append(_variable);
                if (_exponent>1)
                {
                    sb.Append(_exponent);        
                }
                
            }
            
            return sb.ToString();
        }
        #endregion
    }
}