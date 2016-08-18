using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Users.Autentification
{
    [Serializable]
    public class CatalogRules : ISettings
    {
        [XmlElement]
        public List<Rule> Rules = new List<Rule>();

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }

        public Rule GetRule(string ruleName)
        {
            foreach (var rule in Rules)
            {
                if (rule.Name.Equals(ruleName))
                    return rule;
            }

            return null;
        }

        public List<Rule> GetAllRules()
        {
            return new List<Rule>(Rules);
        }


        public event EventHandler Changed;

        public List<IRule> GetRules(List<string> userSids)
        {
            var res = new List<IRule>();

            // оптимизация поиска прав при гигантском количестве userSids
            var dictUserSids = new Dictionary<string, string>();
            foreach (var userSid in userSids)
            {
                dictUserSids[userSid] = userSid;
            }


            foreach (var rule in Rules)
            {
                if(dictUserSids.ContainsKey(rule.Sid))
                    res.Add(rule);

                //foreach (var userSid in userSids)
                //{
                //    if(rule.CheckSid(userSid))
                //        res.Add(rule);
                //}
            }

            return res;
        }

        
    }
}
