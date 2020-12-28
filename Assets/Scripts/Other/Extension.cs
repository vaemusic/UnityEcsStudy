using Entitas;
using System;
using UnityEngine;

public static class Extension
{ 
    //角度转换成向量
    public static Vector2 Angle2Vector2D(this float angle)
    {
        //原始角度加上90度，再将角度换成弧度，变成弧度值
        var a = (angle + 90) * Mathf.Deg2Rad;
        //最后，cos值就是x,sin值就是y
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }

    public static float Vector2Angle2D(this Vector2 dir)
    {
        return Vector2.SignedAngle(Vector2.up, dir);
    }
}

//为每一个entity对应一个id
public static class ContextsIdExtensions
{
    public static void SubscribeId(this Contexts contexts)
    {
        foreach (var context in contexts.allContexts)
        {
            if (Array.FindIndex(context.contextInfo.componentTypes, v => v == typeof(IdComp)) >= 0)
            {
                context.OnEntityCreated += AddId;
            }
        }
    }

    public static void AddId(IContext context, IEntity entity)
    {
        (entity as IIdCompEntity).ReplaceIdComp(entity.creationIndex);
    }
}
