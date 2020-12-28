using System.Collections.Generic;
using Entitas;
using UnityEngine;


//System表示系统，用来处理逻辑的。通常存在五种类型，分别如下：
    //.IInitializeSystem只在初始化时调用一次。初始化实现可以写在Initialize方法中。
    //IExecuteSystem会在每帧执行一次。执行逻辑可以写在Execute方法中。
    //ICleanupSystem会在别的System完成后，每帧执行一次。回收逻辑可以写在Cleanup方法中。
    //ReactiveSystem会在Group有变化时执行一次。执行逻辑可以写在Execute方法中。
    //Feature会将上述的System进行整合以及创建。
public class PlayerInputProcessSystem : ReactiveSystem<InputEntity>
{
    //Context表示上下文环境，用来创建和销毁Entity用的
    private readonly Contexts _contexts;
    //Group表示组，用来将相同类型的Entity归纳到一起用的
    private readonly IGroup<GameEntity> _playerGroup;
    private Camera _mainCamera;

    public PlayerInputProcessSystem(Contexts contexts) : base(contexts.input)
    {
        _mainCamera = Camera.main;
        _contexts = contexts;
        //Matcher表示匹配查找，用来从Context中获取感兴趣的Group
        _playerGroup = _contexts.game.GetGroup(GameMatcher.PlayerTag);
    }

    //GetTrigger里的采集Collector发生变化，才会执行execute
    protected override void Execute(List<InputEntity> entities)
    {
        //因为知道只有一个player，就用singleEntity了
        var playerEntity = _playerGroup.GetSingleEntity();
        foreach (var inputEntity in entities)
        {
            //处理玩家移动
            playerEntity.ReplaceVelComp(new Vector2(
                inputEntity.inputComp.Dir.x * 10,
                inputEntity.inputComp.Dir.y * 10
            ));

            //处理玩家旋转
            var mousePos = inputEntity.inputComp.MousePos;
            //Input.mousePosition获得的坐标是屏幕坐标，需要转换为世界坐标
            var worldPos = _mainCamera.ScreenToWorldPoint(mousePos);
            //鼠标位置减玩家位置，得到方向向量
            var dir = new Vector2(worldPos.x,worldPos.y) - playerEntity.posComp.value;
            //方向向量转换为角度，通过 vector2.up 和 刚才得到的玩家和鼠标的方向向量 的一个夹角
            var angle = Vector2.SignedAngle(Vector2.up, dir);
            //最后赋值给playerEntity的rotation
            playerEntity.ReplaceRotComp(angle);

            //处理玩家开火
            if (inputEntity.inputComp.Fire)
            {
                //朝向是玩家的朝向
                playerEntity.AddFireCmdComp(angle);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        //Collector表示采集，用来从Group中收集变化的Entity,类似unity里的onCollision或者onTrigger
        return context.CreateCollector(InputMatcher.InputComp);
    }
}
