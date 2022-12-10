using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttr 
{
    public abstract int GetMaxHP();
    public abstract string GetAttrName();
}

public class CharacterBaseAttr : BaseAttr
{
    private int m_MaxHp;
    private string m_AttrName;

    public CharacterBaseAttr(int maxHp, string attrName)
    {
        m_MaxHp = maxHp;
        m_AttrName = attrName;
    }

    public override string GetAttrName()
    {
        return m_AttrName;
    }

    public override int GetMaxHP()
    {
        return m_MaxHp;
    }
}
