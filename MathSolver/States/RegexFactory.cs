using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MathSolver.States
{
    public class RegexFactory
    {
        private static readonly RegexFactory _instance = new RegexFactory();
        private readonly Dictionary<string, Regex> _pool;

        private RegexFactory()
        {
            _pool = new Dictionary<string, Regex>();
        }

        public static RegexFactory Instance
        {
            get { return _instance; }
        }

        public Regex GetRegex(string pattern)
        {
            Regex retval = null;
            if (_pool.ContainsKey(pattern))
                retval = _pool[pattern];
            else
            {
                retval = new Regex(pattern,
                                   RegexOptions.IgnoreCase | RegexOptions.Singleline |
                                   RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant);
                _pool.Add(pattern, retval);
            }
            return retval;
        }
    }
}