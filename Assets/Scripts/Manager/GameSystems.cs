public class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        //生成玩家
        Add(new PlayerSpawnSystem(contexts));
        //生成敌人
        Add(new EnemySpawnSystem(contexts));
        //玩家输入
        Add(new InputSystem(contexts));
        Add(new PlayerInputProcessSystem(contexts));

        //目标系统
        Add(new FollowTargetSystem(contexts));

        //移动和旋转
        Add(new MoveSystem(contexts));
        Add(new RotationSystem(contexts));

        //开火系统
        Add(new FireSystem(contexts));

        //视图层系统
        Add(new AddViewSystem(contexts));
        //生命周期系统
        Add(new LifeTimeSystem(contexts));

        Add(new GameEventSystems(contexts));
        //清理
        Add(new InputCleanupSystem(contexts));
        //销毁系统
        Add(new DestroySystem(contexts));
    }
}
