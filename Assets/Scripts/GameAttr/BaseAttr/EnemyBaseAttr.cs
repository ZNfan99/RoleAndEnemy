using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAttr : CharacterBaseAttr
{
    public int m_InitCritRate;	// ±¬“ôÂÊ
    public EnemyBaseAttr(int maxHp, string attrName, int CritRate) : base(maxHp, attrName)
    {
        m_InitCritRate = CritRate;
    }

    public virtual int GetInitCritRate()
    {
        return m_InitCritRate;
    }
}
