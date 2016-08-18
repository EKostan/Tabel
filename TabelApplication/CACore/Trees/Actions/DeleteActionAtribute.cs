using System;

namespace CACore.Trees.Actions
{
    /// <summary>
    /// Атрибут можно применить к классу наследника Node. 
    /// Если класс помечен этим атрибутом, то в конструкторе в Node.Actions будет добавлен DeleteNodeAction.
    /// </summary>
    public class DeleteActionAtribute : Attribute
    {
    }

    
}