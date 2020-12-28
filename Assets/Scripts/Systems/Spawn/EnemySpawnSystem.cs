using UnityEngine;
using Entitas;

//生成敌人
public class EnemySpawnSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private float _timer = 0f;

    public EnemySpawnSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var dt = Time.deltaTime;
        _timer += dt;

        //计时器，每1秒生成一个
        if (_timer >= 1f)
        {
            _timer = 0f;
            //位置随机
            var x = Random.Range(-9f, 9f);
            var y = Random.Range(-5f, 5f);
            var enemyEntity = EntityUtil.CreateEnemyEntity(_contexts,new Vector2(x,y), Vector2.zero);

            //给敌人增加一个目标
            var playerEntity = _contexts.game.playerTagEntity;
            enemyEntity.AddTargetComp(playerEntity.idComp.Value);
        }
    }
}
