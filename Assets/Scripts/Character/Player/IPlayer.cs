using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家的类型
/// </summary>
public enum PlayerType
{
    Null = 0,
    Master = 1,
    Warrior = 2,
}
/// <summary>
/// 玩家的基类
/// </summary>
public abstract class IPlayer : ICharacter
{
    public PlayerType m_PlayerType = PlayerType.Null;

    public IPlayer()
    {

    }

    //获取玩家类型
    public PlayerType GetPlayerType()
    {
        return m_PlayerType;
    }

    //获取玩家的数值
    public PlayerAttr GetPlayerAttr()
    {
        return m_attr as PlayerAttr;
    }

    //重写受击
    public override void UnderAttack(ICharacter Attacker)
    {
        m_AI.Hurt();
        m_attr.GetDefValue(Attacker);
        m_GameObject.GetComponent<CharacterAICompoment>().PlayHurtAnim();

        if (m_attr.GetCurrentHP() <= 0)
        {
            //TODO 游戏失败
            Notification no = new Notification();
            no.msg = EventOrder.GAMEENDING;
            no.data = new object[] { "游戏失败" };
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.GAMEENDING, no);
        }
    }
}
