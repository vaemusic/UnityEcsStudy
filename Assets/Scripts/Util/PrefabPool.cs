using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PrefabPool
{
    //把对象整理到这两个根下边
    public Transform SpawnRoot;
    public Transform PoolRoot;

    //预制体
    public GameObject Prefab;

    //存放所有在池级的对象的栈
    protected readonly Stack<GameObject> _inPoolObjs = new Stack<GameObject>();
    //存放所有在池外（已经生成出去了的对象）
    protected readonly HashSet<GameObject> _outPoolObjs = new HashSet<GameObject>();

    //预载对象
    public void Preload(int count)
    {
        if (Prefab == null)
            return;

        //判断当前池里和池外对象的数量是否已经有这么多了，如果已经有了就不需要加载了
        if (_inPoolObjs.Count + _outPoolObjs.Count >= count)
            return;

        //如果没有这么多，用差量计算需要生成多少个
        //比如需要5个，池里有3个，池外有1个，就5-3-1，需要再生成1个
        var n = count - _inPoolObjs.Count - _outPoolObjs.Count;
        for(var i = 0; i < n; i++)
        {
            var obj = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity);

            //在池里的对象取消显示
            obj.SetActive(false);
            //obj.transform.SetParent(PoolRoot);
            //把生成的对象放进池里
            _inPoolObjs.Push(obj);
        }
    }

    //生成对象
    public GameObject Spawn()
    {
        GameObject obj;

        //如果池里还有对象
        if (_inPoolObjs.Count > 0)
        {
            //直接从池里拿一个对象出来返回出去
            obj = _inPoolObjs.Pop();
        }
        else
        {
            //如果没有，就创建一个
            obj = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity);
        }
        _outPoolObjs.Add(obj);
        //生成后默认为显示
        obj.SetActive(true);
        //设置父节点,放到生成的节点下边
        obj.transform.SetParent(SpawnRoot);
        return obj;
    }

    //回收对象
    public bool Recycle(GameObject obj)
    {
        //判断需要回收的对象是不是在池外
        if (!_outPoolObjs.Contains(obj))
        {
            //如果不在的话,不需要回收
            UnityEngine.Object.Destroy(obj);
            return false;
        }

        //如果在池外，首先需要把这个对象从池外移除
        _outPoolObjs.Remove(obj);
        obj.SetActive(false);
        //设置父节点,放到池的节点下边
        obj.transform.SetParent(PoolRoot);
        //然后再放回池中
        _inPoolObjs.Push(obj);
        return true;
    }
}

//可以从池中拿出某一个组件
[Serializable]
public class PrefabPool<T> where T : Component
{
    //把对象整理到这两个根下边
    public Transform SpawnRoot;
    public Transform PoolRoot;

    //预制体
    public GameObject Prefab;

    //存放所有在池级的对象的栈
    protected readonly Stack<T> _inPoolObjs = new Stack<T>();
    //存放所有在池外（已经生成出去了的对象）
    protected readonly HashSet<T> _outPoolObjs = new HashSet<T>();

    //预载对象
    public void Preload(int count)
    {
        if (Prefab == null)
            return;
        //判断当前池里和池外对象的数量是否已经有这么多了，如果已经有了就不需要加载了
        if (_inPoolObjs.Count + _outPoolObjs.Count >= count)
            return;
        //如果没有这么多，用差量计算需要生成多少个
        //比如需要5个，池里有3个，池外有1个，就5-3-1，需要再生成1个
        var n = count - _inPoolObjs.Count - _outPoolObjs.Count;
        for (var i = 0; i < n; i++)
        {
            var obj = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity);

            //在池里的对象取消显示
            obj.SetActive(false);
            obj.transform.SetParent(PoolRoot);
            //把生成的对象放进池里
            _inPoolObjs.Push(obj.GetComponent<T>());
        }
    }

    //生成对象
    public T Spawn()
    {
        T obj;
        //如果池里还有对象
        if (_inPoolObjs.Count > 0)
        {
            //直接从池里拿一个对象出来
            obj = _inPoolObjs.Pop();
        }
        else
        {
            //如果没有，就创建一个
            obj = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity).GetComponent<T>();
        }
        _outPoolObjs.Add(obj);
        //生成后默认为显示
        obj.gameObject.SetActive(true);
        //设置父节点,放到生成的节点下边
        obj.transform.SetParent(SpawnRoot);
        return obj;
    }

    //回收对象
    public bool Recycle(T obj)
    {
        //判断需要回收的对象是不是在池外
        if (!_outPoolObjs.Contains(obj))
        {
            //如果不在的话,不需要回收
            UnityEngine.Object.Destroy(obj);
            return false;
        }

        //如果在池外，首先需要把这个对象从池外移除
        _outPoolObjs.Remove(obj);
        obj.gameObject.SetActive(false);
        //设置父节点,放到池的节点下边
        obj.transform.SetParent(PoolRoot);
        //然后再放回池中
        _inPoolObjs.Push(obj);
        return true;
    }
}
