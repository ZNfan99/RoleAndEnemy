using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ��ɫ�Ĺ����� �̳��˹۲�����Ϣ�Ľӿ�
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
        UpdateAI(); // ����AI
    }
    //���½�ɫ
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
    //���½�ɫAI
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
       

        //// �Ƴ���ɫ
        //RemoveCharacter();
    }

    //�ͷ�
    public override void Release()
    {
        m_Enemy.Release();
        m_Enemy = null;
        m_Player.Release();
        m_Player = null;
        MessageCenterByObserver.Instance().RemoveMessage(listNotification(), this);
    }
    //�������
    public void SetPlayer(IPlayer player)
    {
        m_Player = player;
    }
    //���õ���
    public void SetEnemy(IEnemy enemy)
    {
        m_Enemy = enemy;
    }
    //����AI����Ŀ��
    internal void SetTarget()
    {
        m_Player.m_AI.SetAttackCharacter(m_Enemy);
        m_Enemy.m_AI.SetAttackCharacter(m_Player);
    }
    //���ǶԸ���Ȥ���¼���ȡ����
    public List<string> listNotification()
    {
        List<string> list = new List<string>();
        list.Add(EventOrder.PLAYERATTACK);
        list.Add(EventOrder.ATTACKFINISHED);
        return list;
    }

    //ִ��֪ͨ
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
