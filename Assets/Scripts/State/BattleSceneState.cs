using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗场景
/// </summary>
public class BattleSceneState : SceneState,IObserver
{
    bool flag = false;
    //构造，赋ID
    public BattleSceneState(SceneController controller) : base(controller)
    {
        this.m_stateID = StateID.BattleState;
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case EventOrder.GAMERETURN:
                flag = true;
                Time.timeScale = 1;
                break;
            default:
                break;
        }
    }

    public override void Initialize()
    {
        Facade.Instance.Initialize();
    }

    public List<string> listNotification()
    {
        List<string> list = new List<string>();
        list.Add(EventOrder.GAMERETURN);
        return list;
    }

    public override void Release()
    {
        Facade.Instance.Release();
    }

    public override void Update()
    {
        if(flag)
        {
            flag = false;
            m_sceneController.PerformTransition(Transition.Exit);
        }   
        Facade.Instance.Update();
    }
}
