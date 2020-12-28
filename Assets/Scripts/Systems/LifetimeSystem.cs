using UnityEngine;
using Entitas;

public class LifeTimeSystem : IExecuteSystem
{
    public readonly IGroup<GameEntity> _group;

    public LifeTimeSystem(Contexts contexts)
    {
        _group = contexts.game.GetGroup(GameMatcher.LifetimeComp);
    }

    public void Execute()
    {
        var dt = Time.deltaTime;
        foreach(var gameEntity in _group.GetEntities())
        {
            var newTime = gameEntity.lifetimeComp.Time - dt;
            //生命周期结束
            if (newTime <= 0)
                gameEntity.isDestroyFlag = true;
            else
                gameEntity.ReplaceLifetimeComp(newTime);
        }
    }
}
