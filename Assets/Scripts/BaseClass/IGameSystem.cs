using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏系统的接口
/// </summary>
public abstract class IGameSystem
{
    public Facade m_Facade = null;

    public IGameSystem(Facade facade)
    {
        m_Facade = facade;
    }

    public virtual void Initialize() { }//初始化
    public virtual void Release() { }//释放
    public virtual void Update() { }//更新
}
