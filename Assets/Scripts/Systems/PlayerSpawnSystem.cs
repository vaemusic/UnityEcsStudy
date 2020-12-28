using Entitas;
using UnityEngine;

//初始玩家系统，只会执行一次
public class PlayerSpawnSystem : IInitializeSystem
{

    private readonly Contexts _contexts;

    public PlayerSpawnSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        EntityUtil.CreatePlayerEntity(_contexts, Vector2.zero,Vector2.zero);
    }
}
