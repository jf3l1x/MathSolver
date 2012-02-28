using System;
using System.Collections.Generic;

namespace MathSolver.States
{
    public class InvalidState : IState
    {
        private static readonly InvalidState _instance = new InvalidState();

        private InvalidState()
        {
        }

        public static InvalidState Instance
        {
            get { return _instance; }
        }

        #region IState Members

        public IState Process(char c)
        {
            return this;
        }

        public void Enter(IState from, char c)
        {
        }

        public bool IsFinalState
        {
            get { return false; }
        }

        public string Buffer
        {
            get { return string.Empty; }
        }

        public IExpression CreateExpression()
        {
            throw new NotImplementedException();
        }

        public IList<ITransition> Transitions
        {
            get { return new List<ITransition>(); }
        }

        #endregion
    }
}