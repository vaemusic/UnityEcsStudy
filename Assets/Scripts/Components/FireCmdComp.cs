using Entitas;
using UnityEngine;

//开火命令组件
public sealed class FireCmdComp : IComponent
{
    //表示要朝哪个方向开火
    public float Angle;
}
