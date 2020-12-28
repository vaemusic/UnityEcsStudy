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
            GameMatcher.VelComp,
            GameMatcher.PhysicsComp,
            GameMatcher.ViewComp
        ));
    }

    //每帧都会执行的接口
    public void Execute()
    {
        var dt = Time.deltaTime;
        foreach(var entity in _group.GetEntities())
        {
            var velComp = entity.velComp;
            var rigidbody = ((IPhysicsView)entity.viewComp.View).Rigidbody;
            rigidbody.velocity = velComp.value;
            
        }
    }
}
