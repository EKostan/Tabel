using System.Collections.Generic;

namespace CACore.Menu
{
    public interface IRuleMenuItem
    {
        ICollection<string> RuleKeys { get; set; }
    }
}