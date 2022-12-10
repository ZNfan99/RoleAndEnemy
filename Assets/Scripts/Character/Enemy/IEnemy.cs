using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人的类型
/// </summary>
public enum EnemyType
{
    Null = 0,
    NormalEnemy = 1,
    Boss = 2,
}

/// <summary>
/// 敌人的基类
/// </summary>
public abstract class IEnemy : ICharacter
{
    
    public EnemyType m_EnemyType = EnemyType.Null;
    public IEnemy()
    { }

    //获取敌人类型
    public EnemyType GetEnemyType()
    {
        return m_EnemyType;
    }

    //重写受击
    public override void UnderAttack(ICharacter Attacker)
    {
        m_AI.Hurt();
        m_attr.GetDefValue(Attacker);
        m_GameObject.GetComponent<CharacterAICompoment>().PlayHurtAnim();

        if (m_attr.GetCurrentHP() <= 0)
        {
            //TODO 敌人死亡
            Notification no = new Notification();
            no.msg = EventOrder.GAMEENDING;
            no.data = new object[] { "游戏胜利" };
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.GAMEENDING, no);
        }
    }
}
