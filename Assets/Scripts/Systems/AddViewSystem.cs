using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            var view = SpawnView(entity);
            entity.AddViewComp(view);
            entity.RemoveCreateGameObjectCmdComp();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //当有GameObject组件添加的时候，就会得到entity
        return context.CreateCollector(GameMatcher.CreateGameObjectCmdComp);
    }

    private View SpawnView(GameEntity gameEntity)
    {
        var path = gameEntity.createGameObjectCmdComp.path;
        var prefab = Resources.Load<GameObject>(path);
        View view = null;
        if (path == "Bullet")
        {
            view = PoolManager.Instance.BulletPrefabPool.Spawn();
        }
        else
        {
            var obj = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            view = obj.GetComponent<View>();
        }
        
        view.Link(_contexts,gameEntity);
        return view;
    }
}
