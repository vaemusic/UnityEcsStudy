using Entitas;
using UnityEngine;

[Input]
//玩家输入系统
public class InputSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        //创建inputEntity
        var playerInputEntity = _contexts.input.CreateEntity();
        //玩家输入组件
        playerInputEntity.AddInputComp(
            new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            ),
            Input.mousePosition,
            Input.GetMouseButton(0)
        );
    }
}
