using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ״̬�Ļ���
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

    //����AI
    public void SetCharacterAI(ICharacterAI characterAI)
    {
        m_CharacterAI = characterAI;
    }

    public virtual void Init()
    {

    }
    
    public abstract void Update();
}