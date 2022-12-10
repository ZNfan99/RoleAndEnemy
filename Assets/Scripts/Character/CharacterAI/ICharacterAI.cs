using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// AI�Ļ���
/// </summary>
public abstract class ICharacterAI
{
    public ICharacter m_Character = null;
    public IAIState m_AIState = null;
    public const float ATTACK_COOLD_DOWN = 1f; 
    public float m_CoolDown = ATTACK_COOLD_DOWN;
    public ICharacter m_AttackCharacter = null;

    public ICharacterAI(ICharacter character)
    {
        m_Character = character;
    }

    //�����Ƿ��ڹ���״̬
    public void SetIsAttack()
    {
        m_AIState.m_IsAttack = !m_AIState.m_IsAttack;
    }

    //���ù��������
    public void SetAttackCharacter(ICharacter attackCharacter)
    {
        m_AttackCharacter = attackCharacter;
    }

    //�ı�״̬
    public virtual void ChangeAIState(IAIState state)
    {
        m_AIState = state;
        m_AIState.SetCharacterAI(this);
    }

    //����
    public virtual void Attack(ICharacter target)
    {
        m_Character.Attack(target);
    }

    //�ܻ�
    public virtual void Hurt()
    {
        m_AIState.m_IsHurt = !m_AIState.m_IsHurt;
    }

    public void Init()
    {
        m_AIState.Init();
    }

    public void Update()
    {
        m_AIState.Update();
    }
}
