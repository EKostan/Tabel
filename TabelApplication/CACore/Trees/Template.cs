using System.Collections.Generic;

namespace CACore.Trees
{
    public class Template : ITemplate
    {


        public Template(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        //
        Dictionary<string, INodeDescriptor> _nodeDescriptors = new Dictionary<string, INodeDescriptor>();
        
        // parentNodeKey, список подъузлов
        Dictionary<string, List<INodeDescriptor>> _childrenNodeDescriptors = new Dictionary<string, List<INodeDescriptor>>();


        public INodeDescriptor GetNodeDescriptor(string nodeKey)
        {
            var key = GetKeySafe(nodeKey);

            if (_nodeDescriptors.ContainsKey(key))
                return _nodeDescriptors[key];
            
            return null;
        }

        public ICollection<INodeDescriptor> GetRootDescriptors()
        {
            return GetChildren(string.Empty);
        }
        
        public void AddNodeDescriptor(INodeDescriptor nodeDescriptor)
        {
            _nodeDescriptors[nodeDescriptor.NodeKey] = nodeDescriptor;

            var parentKey = GetKeySafe(nodeDescriptor.ParentNodeKey);

            if(!_childrenNodeDescriptors.ContainsKey(parentKey))
                _childrenNodeDescriptors[parentKey] = new List<INodeDescriptor>();

            _childrenNodeDescriptors[parentKey].Add(nodeDescriptor);
        }

        public ICollection<INodeDescriptor> GetChildren(string nodeKey)
        {
            var key = GetKeySafe(nodeKey);

            if (!_childrenNodeDescriptors.ContainsKey(key))
                return new List<INodeDescriptor>();

            return new List<INodeDescriptor>(_childrenNodeDescriptors[key]);
        }

        public string GetParentKey(string nodeKey)
        {
            foreach (var item in _childrenNodeDescriptors)
            {
                foreach (var nodeDescriptor in item.Value)
                {
                    if (nodeDescriptor.NodeKey.Equals(nodeKey))
                        return item.Key;
                }
            }

            return string.Empty;
        }

        private string GetKeySafe(string nodeKey)
        {
            return string.IsNullOrEmpty(nodeKey) ? string.Empty : nodeKey;
        }
       
    }
}
