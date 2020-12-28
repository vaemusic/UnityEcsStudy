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
}
