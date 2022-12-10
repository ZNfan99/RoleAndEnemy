using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class ICharacterAttr
{
    public BaseAttr m_BaseAttr = null;
    public int m_CurrentHP = 0;
    public IAttrStrategy m_AttrStrategy = null;

    public ICharacterAttr() { }

    public void SetBaseAttr(BaseAttr baseAttr)
    {
        m_BaseAttr = baseAttr;
    }

    public BaseAttr GetBaseAttr()
    {
        return m_BaseAttr;
    }

    public void SetAttrStrategy(IAttrStrategy strategy)
    {
        m_AttrStrategy = strategy;
    }

    public IAttrStrategy GetAttrStrategy()
    {
        return m_AttrStrategy;
    }

    public int GetCurrentHP()
    {
        return m_CurrentHP;
    }

    public virtual int GetMaxHP()
    {
        return m_BaseAttr.GetMaxHP();
    }

    public virtual string GetAttrName()
    {
        return m_BaseAttr.GetAttrName();
    }

    public virtual void InitAttr()
    {
        m_AttrStrategy.InitAttr(this);
        m_CurrentHP = GetMaxHP();
    }

    public int GetAtkValue()
    {
        return m_AttrStrategy.GetAtkValue(this);
    }

    public void GetDefValue(ICharacter Attacker)
    {
        int AtkValue = Attacker.GetAtkValue();
        AtkValue -= m_AttrStrategy.GetDefValue(this);
        m_CurrentHP -= AtkValue;
    }
}
