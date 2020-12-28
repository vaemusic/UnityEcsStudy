using UnityEngine;
using Entitas;

//追踪目标系统
public class FollowTargetSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;

    public FollowTargetSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.TargetComp,
            GameMatcher.VelComp,
            GameMatcher.RotComp
         )) ;
    }

    public void Execute()
    {
        foreach(var entity in _group.GetEntities())
        {
            var targetEntity = _contexts.game.GetEntityWithIdComp(entity.targetComp.TargetId);

            var targetPos = targetEntity.posComp.value;
            var selfPos = entity.posComp.value;

            var dirVector = (targetPos - selfPos).normalized;

            //朝着目标方向
            entity.ReplaceRotComp(dirVector.Vector2Angle2D());
            //敌人速度
            entity.ReplaceVelComp(dirVector * 5);
        }
    }
}
