using Entitas;
using UnityEngine;

//通过entity获得gameObject,用来连接entity到gameObject的组件
public sealed class ViewComp : IComponent
{
    public View View;
}
