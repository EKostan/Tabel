using System.Collections.Generic;

namespace CACore.Trees
{
    public class TemplateTree : Tree
    {
        private ITemplate _template;

        public TemplateTree(ITemplate template)
        {
            _template = template;

            CompileTemplateNodes(null);
        }

        /// <summary>
        /// Добавляем к узлу все узлы из шаблона дерева. 
        /// Используется только для создания подъузлов из шаблона.
        /// </summary>
        /// <param name="node"></param>
        private void CompileTemplateNodes(INode node)
        {
            // получаем ключ узла для которого необходимо найти опиатели узлов из шаблона
            var nodeKey = node == null ? string.Empty : node.Key;

            // получаем список описателей подъузлов для nodeKey
            var childrenNodesFromTemplate = _template.GetChildren(nodeKey);

            foreach (var nodeDescriptor in childrenNodesFromTemplate)
            {
                var childrenNode = nodeDescriptor.CreateNode();

                if (childrenNode == null)
                    continue;

                base.AddNode(childrenNode, node);

                var childrenNodeKey = childrenNode.Key;

                // для подъузла ищем все его подъузлы
                var childrenNodeChildren = _template.GetChildren(childrenNodeKey);

                if (childrenNodeChildren.Count > 0)
                    CompileTemplateNodes(childrenNode);
            }
        }



        public override void AddNode(INode node, INode rootNode)
        {
           


            // в соответствии с шаблоном ищем узел в который надо добавить node 
            // относительно корневого узла rootNode
            
            
            // надо получить ключ дочернего узла для node.key
            var parentKey = _template.GetParentKey(node.Key);

            var parentNode = FindParentNode(rootNode, parentKey);

            base.AddNode(node, parentNode ?? rootNode);

            // выстраиваем для нового узла поъузлы в соответствии с шаблоном
            CompileTemplateNodes(node);
        }

        public override void AddNodes(List<INode> nodes, INode rootNode)
        {

            // в соответствии с шаблоном ищем узел в который надо добавить node 
            // относительно корневого узла rootNode
            foreach (var node in nodes)
            {
                // надо получить ключ дочернего узла для node.key
                var parentKey = _template.GetParentKey(node.Key);

                var parentNode = FindParentNode(rootNode, parentKey);

                base.AddNode(node, parentNode ?? rootNode);
                
                // выстраиваем для нового узла поъузлы в соответствии с шаблоном
                CompileTemplateNodes(node);
            }
        }

        private INode FindParentNode(INode rootNode, string parentKey)
        {
            if (rootNode == null || rootNode.Key.Equals(parentKey))
                return rootNode;

            if (!rootNode.HasChildren)
                return null;

            foreach (var node in rootNode.Nodes)
            {
                var res = FindParentNode(node, parentKey);

                if (res != null)
                    return res;
            }

            return null;
        }

    }
}