using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态的基类
/// </summary>
public abstract class IAIState
{
    public ICharacterAI m_CharacterAI = null;

    public bool m_IsAttack = false;
    public bool m_IsDead = false;
    public bool m_IsHurt = false;
    public IAIState()
    {
    }

    //设置AI
    public void SetCharacterAI(ICharacterAI characterAI)
    {
        m_CharacterAI = characterAI;
    }

    public virtual void Init()
    {

    }
    
    public abstract void Update();
}