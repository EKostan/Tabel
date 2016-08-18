namespace CACore.Trees
{
    public class TreeBuilder
    {
        public static TemplateTree Build(ITemplate template)
        {
            var rootNode = new RootNode();
            var tree = new TemplateTree(template) { Name = template.Name };
            return tree;
        }


    }
}