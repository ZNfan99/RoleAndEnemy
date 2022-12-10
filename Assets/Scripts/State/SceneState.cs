using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 过渡条件
/// </summary>
public enum Transition
{
    NullTransition = 0,//null
    CheckComplete,//结束
    OnClickBattle,
    Exit//退出
}
/// <summary>
/// 状态ID
/// </summary>
public enum StateID
{
    NullStateID = 0,
    StartState = 1,
    MainState =2,
    BattleState
}
/// <summary>
/// 场景的基类
/// </summary>
public abstract class SceneState
{
    protected StateID m_stateID;//状态ID
    public StateID ID
    {
        get { return m_stateID; }
    }
    //管理自身状态向其他状态改变的库
    Dictionary<Transition, StateID> m_stateMaps = new Dictionary<Transition, StateID>();
    //自身所持有的场景管理类
    protected SceneController m_sceneController = null;

    //构造函数，在构造的时候进行赋值管理
    public SceneState(SceneController controller)
    {
        m_sceneController = controller;
    }
    //库的增加属性
    public void AddTransition(Transition transition,StateID stateID)
    {
        if(transition == Transition.NullTransition)
        {
            Debug.LogError("不允许NullTransition"); return;
        }
        if (stateID == StateID.NullStateID)
        {
            Debug.LogError("不允许NullStateID"); return;
        }
        if (m_stateMaps.ContainsKey(transition))
        {
            Debug.LogError("添加转换条件的时候，" + transition + "已经存在于map中"); return;
        }
        m_stateMaps.Add(transition, stateID);
    }
    //库的删除属性
    public void RemoveTransition(Transition transition)
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("不允许NullTransition"); return;
        }
        if (!m_stateMaps.ContainsKey(transition))
        {
            Debug.LogError("删除转换条件的时候，" + transition + "不存在于map中"); return;
        }
        m_stateMaps.Remove(transition);
    }
    //通过转换条件获取到要跳转场景的ID
    public StateID GetOutputState(Transition transition)
    {
        if (m_stateMaps.ContainsKey(transition))
        {
            return m_stateMaps[transition];
        }
        return StateID.NullStateID;
    }
    //初始化
    public abstract void Initialize();
    //更新
    public abstract void Update();
    //释放
    public abstract void Release();
}