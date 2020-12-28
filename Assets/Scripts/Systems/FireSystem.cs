using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class FireSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public FireSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var gameEntity in entities)
        {
            //获得开火命令组件
            var fireCmd = gameEntity.fireCmdComp;
            //一次性的，获得完就可以移除掉
            gameEntity.RemoveFireCmdComp();

            var playerView = (PlayerView)gameEntity.viewComp.View;

            EntityUtil.CreateBulletEntity(_contexts, 
                playerView.Shoot.position,
                fireCmd.Angle.Angle2Vector2D() * 5,
                fireCmd.Angle);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //触发时机是同时拥有这三个组件的entity
        return context.CreateCollector(GameMatcher.AllOf(
            GameMatcher.PlayerTag,
            GameMatcher.FireCmdComp,
            GameMatcher.ViewComp
        ));
    }
}
