using Entitas;
using Entitas.CodeGeneration.Attributes;

//没有属性，只是一个tag组件，只要添加了这个tag就知道这个entity是个player
[Unique]//保证带有这个tag的entity只有一个
public sealed class PlayerTag : IComponent
{
    
}
