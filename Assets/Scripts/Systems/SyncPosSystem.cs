﻿using Entitas;

//同步Unity由物理系统计算出来的位置
public class SyncPosSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;

    public SyncPosSystem(Contexts contexts)
    {
        _group = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.ViewComp,
            GameMatcher.PosComp,
            GameMatcher.PhysicsComp
        ));
    }

    public void Execute()
    {
        foreach(var gameEntity in _group.GetEntities())
        {
            var pos = gameEntity.viewComp.View.transform.position;
            gameEntity.ReplacePosComp(pos);
        }
    }
}
