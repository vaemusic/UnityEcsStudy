using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView,IDestroyFlagListener
{
    //把unity的gameObject和entity连接
    public void Link(Contexts contexts, IEntity entity)
    {
        gameObject.Link(entity);

        var gameEntity = (GameEntity)entity;
        //当destroyFlag改变时，就会调用下边的Listener方法
        gameEntity.AddDestroyFlagListener(this);

        //link后初始化transform的值
        transform.position = gameEntity.posComp.value;
        transform.rotation = Quaternion.Euler(0, 0, gameEntity.rotComp.Angle);
    }

    public void OnDestroyFlag(GameEntity entity)
    {
        gameObject.Unlink();

        OnDestroyEntityHandler();
    }

    protected virtual void OnDestroyEntityHandler()
    {

    }
}
