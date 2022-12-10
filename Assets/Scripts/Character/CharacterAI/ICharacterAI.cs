using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// AI的基类
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

    //设置是否在攻击状态
    public void SetIsAttack()
    {
        m_AIState.m_IsAttack = !m_AIState.m_IsAttack;
    }

    //设置攻击的玩家
    public void SetAttackCharacter(ICharacter attackCharacter)
    {
        m_AttackCharacter = attackCharacter;
    }

    //改变状态
    public virtual void ChangeAIState(IAIState state)
    {
        m_AIState = state;
        m_AIState.SetCharacterAI(this);
    }

    //攻击
    public virtual void Attack(ICharacter target)
    {
        m_Character.Attack(target);
    }

    //受击
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
