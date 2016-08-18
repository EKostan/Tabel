using System.Collections.Generic;

namespace CACore.Trees
{
    public class TemplateRegistry
    {
        public const string DefaultTemplateName = "default";
        static Dictionary<string, ITemplate> _templates = new Dictionary<string, ITemplate>();
        
        static TemplateRegistry()
        {
            var template = new Template(DefaultTemplateName);
            RegisterTemplate(template);
        }


        public static void RegisterTemplate(ITemplate template)
        {
            _templates[template.Name] = template;
        }

        public static ITemplate GetTemplate(string name)
        {
            return _templates[name];
        }

        public static ITemplate GetTemplate()
        {
            return GetTemplate(DefaultTemplateName);
        }

    }
}
