using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI界面的接口
/// </summary>
public abstract class IUserInterface
{
    public Facade m_Facade = null;
    public GameObject m_RootUI = null;

    public IUserInterface(Facade facade) 
    {
        m_Facade= facade;
    }

    public virtual void Initialize() { }//初始化
    public virtual void Release() { }//释放
    public virtual void Update() { }//更新
}