using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MathSolver.Functions;

namespace MathSolver.States
{
    public abstract class BaseState : IState
    {
        private readonly StringBuilder _buffer;
        private readonly List<ITransition> _transitions;
        private IState _from;

        public BaseState()
        {
            FunctionFactory=new FunctionFactory();
            _transitions = new List<ITransition>();
            Transitions.Add(new Transition(@"\s", this));
            _buffer = new StringBuilder();
        }

        public IFunctionFactory FunctionFactory { get; set; }

        protected IState From
        {
            get { return _from; }
        }

        #region IState Members

        public string Buffer
        {
            get { return _buffer.ToString(); }
        }

        public virtual void Enter(IState from, char c)
        {
            _from = from;
            if (!RegexFactory.Instance.GetRegex(@"\s").Match(new string(c, 1)).Success)
                _buffer.Append(c);
        }

        public virtual IState Process(char c)
        {
            IState retval = GetNextState(c);
            retval.FunctionFactory = FunctionFactory;
            retval.Enter(this, c);
            return retval;
        }

        public virtual bool IsFinalState
        {
            get { return false; }
        }

        public virtual IExpression CreateExpression()
        {
            throw new NotImplementedException();
        }

        public IList<ITransition> Transitions
        {
            get { return _transitions; }
        }

        #endregion

        protected void Append(string c)
        {
            _buffer.Append(c);
        }

        protected double GetDoubleFromBuffer()
        {
            double retval = 0;
            double.TryParse(_buffer.ToString().Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator),
                            out retval);
            return retval;
        }

        protected IState GetNextState(char c)
        {
            IState retval = InvalidState.Instance;
            foreach (ITransition t in _transitions)
            {
                if (t.Match(c))
                {
                    retval = t.NextState;

                    break;
                }
            }
            return retval;
        }
    }
}