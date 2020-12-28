using Entitas;
using UnityEngine;

//移动系统
public class MoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts)
    {
        //获得感兴趣的组，这个组的entity需要有位置和速度这两个组件
        _group = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.PosComp,
            GameMatcher.VelComp,
            GameMatcher.ViewComp
        ));
    }

    //每帧都会执行的接口
    public void Execute()
    {
        var dt = Time.deltaTime;
        foreach(var entity in _group.GetEntities())
        {
            var posComp = entity.posComp;
            var velComp = entity.velComp;
            entity.ReplacePosComp(new Vector2(
                posComp.value.x + dt * velComp.value.x,
                posComp.value.y + dt * velComp.value.y
            ));
            entity.viewComp.View.transform.position = entity.posComp.value;
        }
    }
}
