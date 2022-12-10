using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ҵ�����
/// </summary>
public enum PlayerType
{
    Null = 0,
    Master = 1,
    Warrior = 2,
}
/// <summary>
/// ��ҵĻ���
/// </summary>
public abstract class IPlayer : ICharacter
{
    public PlayerType m_PlayerType = PlayerType.Null;

    public IPlayer()
    {

    }

    //��ȡ�������
    public PlayerType GetPlayerType()
    {
        return m_PlayerType;
    }

    //��ȡ��ҵ���ֵ
    public PlayerAttr GetPlayerAttr()
    {
        return m_attr as PlayerAttr;
    }

    //��д�ܻ�
    public override void UnderAttack(ICharacter Attacker)
    {
        m_AI.Hurt();
        m_attr.GetDefValue(Attacker);
        m_GameObject.GetComponent<CharacterAICompoment>().PlayHurtAnim();

        if (m_attr.GetCurrentHP() <= 0)
        {
            //TODO ��Ϸʧ��
            Notification no = new Notification();
            no.msg = EventOrder.GAMEENDING;
            no.data = new object[] { "��Ϸʧ��" };
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.GAMEENDING, no);
        }
    }
}
