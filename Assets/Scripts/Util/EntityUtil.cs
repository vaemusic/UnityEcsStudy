using Entitas;
using UnityEngine;

public class EntityUtil
{
    /*创建玩家Entity
        contexts:上下文
        pos:初始化位置
        vel:速度
        angle:初始化角度
    */
    public static GameEntity CreatePlayerEntity(Contexts contexts,Vector2 pos,Vector2 vel,float angle=0)
    {
        //创建entity,Entity表示一个实体，用来存储数据用的
        var playerEntity = contexts.game.CreateEntity();
        playerEntity.isPlayerTag = true;
        //添加组件
        playerEntity.AddPosComp(pos);
        playerEntity.AddVelComp(Vector2.zero);
        playerEntity.AddRotComp(angle);
        playerEntity.AddCreateGameObjectCmdComp("Player");
        return playerEntity;
    }
    /*
     * 创建子弹Entity
     */ 
    public static GameEntity CreateBulletEntity(Contexts contexts, Vector2 pos, Vector2 vel, float angle = 0)
    {
        var bulletEntity = contexts.game.CreateEntity();
        bulletEntity.isBulletTag = true;
        //添加组件
        bulletEntity.AddPosComp(pos);
        bulletEntity.AddVelComp(vel);
        bulletEntity.AddRotComp(angle);
        bulletEntity.AddCreateGameObjectCmdComp("Bullet");
        bulletEntity.AddLifetimeComp(1);

        return bulletEntity;
    }

    public static GameEntity CreateEnemyEntity(Contexts contexts, Vector2 pos, Vector2 vel, float angle = 0)
    {
        //创建entity,Entity表示一个实体，用来存储数据用的
        var enemyEntity = contexts.game.CreateEntity();
        enemyEntity.isEnemyTag = true;
        //添加组件
        enemyEntity.AddPosComp(pos);
        enemyEntity.AddVelComp(Vector2.zero);
        enemyEntity.AddRotComp(angle);
        enemyEntity.AddCreateGameObjectCmdComp("Enemy");
        return enemyEntity;
    }
}
