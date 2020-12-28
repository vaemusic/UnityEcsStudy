using UnityEngine;
using Entitas;

//用来创建gameObject的组件
public sealed class CreateGameObjectCmdComp : IComponent
{
    //路径
    public string path;
}
