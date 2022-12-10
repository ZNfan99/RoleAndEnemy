using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˵�����
/// </summary>
public enum EnemyType
{
    Null = 0,
    NormalEnemy = 1,
    Boss = 2,
}

/// <summary>
/// ���˵Ļ���
/// </summary>
public abstract class IEnemy : ICharacter
{
    
    public EnemyType m_EnemyType = EnemyType.Null;
    public IEnemy()
    { }

    //��ȡ��������
    public EnemyType GetEnemyType()
    {
        return m_EnemyType;
    }

    //��д�ܻ�
    public override void UnderAttack(ICharacter Attacker)
    {
        m_AI.Hurt();
        m_attr.GetDefValue(Attacker);
        m_GameObject.GetComponent<CharacterAICompoment>().PlayHurtAnim();

        if (m_attr.GetCurrentHP() <= 0)
        {
            //TODO ��������
            Notification no = new Notification();
            no.msg = EventOrder.GAMEENDING;
            no.data = new object[] { "��Ϸʤ��" };
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.GAMEENDING, no);
        }
    }
}
