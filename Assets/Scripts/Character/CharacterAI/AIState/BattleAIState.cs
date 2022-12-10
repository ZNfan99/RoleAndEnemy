using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Õ½¶·µÄ×´Ì¬
/// </summary>
public class BattleAIState : IAIState
{
    public override void Init()
    {
        m_CharacterAI.Attack(m_CharacterAI.m_AttackCharacter);
    }
    public override void Update()
    {
        if (!m_IsAttack)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
        }
    }
}