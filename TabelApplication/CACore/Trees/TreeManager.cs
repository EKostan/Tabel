using System.Collections.Generic;
using CACore.Menu;

namespace CACore.Trees
{
    public class TreeManager
    {
        static Dictionary<string, Tree> _trees = new Dictionary<string,Tree>();

        public static TemplateTree BuildTree(ITemplate template)
        {
            return TreeBuilder.Build(template);
        }

        public static void AddTree(Tree tree)
        {
            _trees[tree.Name] = tree;
        }

        public static Tree GetTree(string name)
        {
            return _trees[name];
        }

        static Dictionary<INode, IItem> _nodeMenuItems = new Dictionary<INode, IItem>();


    }
}