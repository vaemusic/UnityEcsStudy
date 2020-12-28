using Entitas;
using UnityEngine;

//清理系统
public class InputCleanupSystem : ICleanupSystem
{
    private readonly Contexts _contexts;

    public InputCleanupSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Cleanup()
    {
        //清理掉input的所有entity
        _contexts.input.DestroyAllEntities();
    }
}
