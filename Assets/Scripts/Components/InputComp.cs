using Entitas;
using UnityEngine;

//玩家输入组件
[Input]
public sealed class InputComp : IComponent
{
    //移动
    public Vector2 Dir;
    //鼠标位置
    public Vector2 MousePos;
    //判断玩家是否开火
    public bool Fire;
}
