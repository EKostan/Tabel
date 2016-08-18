using System.Collections.Generic;

namespace CACore.Trees
{
    public interface ITemplate
    {
        string Name { get; set; }

        /// <summary>
        /// Возвращает узел и все подъузлы шаблона по ключу описателя узла nodeKey
        /// </summary>
        /// <param name="nodeKey"></param>
        /// <returns></returns>
        INodeDescriptor GetNodeDescriptor(string nodeKey);

        /// <summary>
        /// Возвращает список описателей корневых узлов дерева
        /// </summary>
        /// <returns></returns>
        ICollection<INodeDescriptor> GetRootDescriptors();
        
        /// <summary>
        /// Добавляет описатель узла дерева в подузел узла с ключом nodeDescriptor.ParentNodeKey.
        /// Если nodeDescriptor.ParentNodeKey не задан, то добавляем описатель корневым узлом.
        /// </summary>
        /// <param name="nodeDescriptor"></param>
        void AddNodeDescriptor(INodeDescriptor nodeDescriptor);

        /// <summary>
        /// Возвращает список подъузлов для узла с ключом nodeKey
        /// </summary>
        /// <param name="nodeKey"></param>
        ICollection<INodeDescriptor> GetChildren(string nodeKey);

        /// <summary>
        /// Возвращает дочерний узел для узла с ключом nodeKey
        /// </summary>
        /// <param name="nodeKey"></param>
        /// <returns></returns>
        string GetParentKey(string nodeKey);
    }
}