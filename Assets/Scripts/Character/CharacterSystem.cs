using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 角色的管理类 继承了观察者消息的接口
/// </summary>
public class CharacterSystem : IGameSystem,IObserver
{

    public IPlayer m_Player = null;
    public IEnemy m_Enemy = null;
    bool flag1 = false;
    float timer1 = 0;
    public CharacterSystem(Facade facade) : base(facade)
    {
        Initialize();
    }

    public override void Initialize()
    {
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
    }

    public override void Update()
    {
        UpdateCharacter();
        UpdateAI(); // 更新AI
    }
    //更新角色
    private void UpdateCharacter()
    {
        if(m_Enemy!=null)
        {
            m_Enemy.Update();
        }
        if(m_Player != null)
        {
            m_Player.Update();
        }
        if(flag1)
        {
            timer1 += Time.deltaTime;
            if(timer1 > 2f)
            {
                timer1 = 0;
                flag1 = false;
                m_Enemy.Attack(m_Player);
            }
        }
    }
    //更新角色AI
    private void UpdateAI()
    {
        if(m_Enemy != null)
        {
            m_Enemy.UpdateAI();
        }
        if(m_Player != null)
        {
            m_Player.UpdateAI();
        }
       

        //// 移除角色
        //RemoveCharacter();
    }

    //释放
    public override void Release()
    {
        m_Enemy.Release();
        m_Enemy = null;
        m_Player.Release();
        m_Player = null;
        MessageCenterByObserver.Instance().RemoveMessage(listNotification(), this);
    }
    //设置玩家
    public void SetPlayer(IPlayer player)
    {
        m_Player = player;
    }
    //设置敌人
    public void SetEnemy(IEnemy enemy)
    {
        m_Enemy = enemy;
    }
    //设置AI攻击目标
    internal void SetTarget()
    {
        m_Player.m_AI.SetAttackCharacter(m_Enemy);
        m_Enemy.m_AI.SetAttackCharacter(m_Player);
    }
    //这是对感兴趣的事件获取集合
    public List<string> listNotification()
    {
        List<string> list = new List<string>();
        list.Add(EventOrder.PLAYERATTACK);
        list.Add(EventOrder.ATTACKFINISHED);
        return list;
    }

    //执行通知
    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case EventOrder.PLAYERATTACK:
                m_Player.Attack(m_Enemy);

                break;
            case EventOrder.ATTACKFINISHED:
                object[] obj = notification.data;
                if(obj[0] as ICharacter == m_Enemy)
                {
                    m_Enemy.m_weapon.DisableEffect();
                    m_Enemy.m_AI.SetIsAttack();
                    MessageCenterByObserver.Instance().NotifyObserver(EventOrder.BTNACTIVE, null);
                }
                else
                {
                    m_Player.m_weapon.DisableEffect();
                    m_Player.m_AI.SetIsAttack();
                    flag1 = true;
                }
                
                break;

            default:
                break;
        }
    }
}
