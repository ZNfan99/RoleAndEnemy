using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ÊÜ»÷×´Ì¬
/// </summary>
public class HurtAIState : IAIState
{
    public override void Init()
    {
        m_CharacterAI.Hurt();
    }
    public override void Update()
    {
        if(m_IsDead)
        {
            //m_CharacterAI.ChangeAIState(new BattleAIState());
        }
        if(!m_IsHurt)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
        }
    }
}
