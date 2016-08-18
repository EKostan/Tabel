using System.Collections.Generic;

namespace Core.Users.Autentification.Containers
{
    public class RuleContainer<TElement> where TElement : class, IRule
    {
        Dictionary<string, TElement> _dict = new Dictionary<string, TElement>();

        public RuleContainer()
        {
        }

        public RuleContainer(IEnumerable<TElement> collection)
        {
            foreach (var element in collection)
            {
                _dict[element.Key] = element;
            }
        }

        public bool Contains(string key)
        {
            return _dict.ContainsKey(key);
        }

        public TElement this[string key]
        {
            get
            {
                if (_dict.ContainsKey(key))
                    return _dict[key];
                return null;
            }
            set { _dict[key] = value; }
        }

        public bool CheckRule(string key)
        {
            foreach (var value in _dict.Values)
            {
                if (value.CheckKey(key))
                    return true;
            }

            return false;
        }
    }
}
