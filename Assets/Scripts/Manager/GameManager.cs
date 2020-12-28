using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameSystems _gameSystems;
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        //得到游戏分享的实例
        _gameSystems = new GameSystems(_contexts); 
    }

    private void Start()
    {
        //初始化系统，只在第一次执行
        _gameSystems.Initialize();
    }


    private void Update()
    {
        //这两个系统每一帧都会执行
        //执行系统
        _gameSystems.Execute();
        //清理系统
        _gameSystems.Cleanup();
    }

    private void OnDestroy()
    {
        //销毁时调用回收数据系统，只在最后一次执行
        _gameSystems.TearDown();
    }
}
