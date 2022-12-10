using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ¾²Ö¹×´Ì¬
/// </summary>
public class IdleAIState : IAIState
{
    public override void Update()
    {
        if(m_IsAttack)
        {
            m_CharacterAI.ChangeAIState(new BattleAIState());
        }
        if(m_IsHurt)
        {
            m_CharacterAI.ChangeAIState(new HurtAIState());
        }
    }
}
