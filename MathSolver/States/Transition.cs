using System.Text.RegularExpressions;

namespace MathSolver.States
{
    public class Transition : ITransition
    {
        private readonly IState _next;
        private readonly Regex _regex;
        private readonly string _simbolsRegex;

        public Transition(string simbolsRegex, IState next)
        {
            _simbolsRegex = simbolsRegex;
            _next = next;
            _regex = RegexFactory.Instance.GetRegex(simbolsRegex);
        }

        #region ITransition Members

        public IState NextState
        {
            get { return _next; }
        }

        public string SimbolsRegex
        {
            get { return _simbolsRegex; }
        }

        public bool Match(char c)
        {
            return _regex.Match(new string(c, 1)).Success;
        }

        #endregion
    }
}