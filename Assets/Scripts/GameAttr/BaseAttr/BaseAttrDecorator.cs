using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalAttr
{
    private int m_Strength; // 力量
    private int m_Agility;  // 敏捷
    private string m_Name;  //数值的名称

    public AdditionalAttr(int Strength, int Agility, string Name)
    {
        m_Strength = Strength;
        m_Agility = Agility;
        m_Name = Name;
    }

    public int GetStrength()
    {
        return m_Strength;
    }

    public int GetAgility()
    {
        return m_Agility;
    }

    public string GetName()
    {
        return m_Name;
    }
}

public abstract class BaseAttrDecorator : BaseAttr
{
    protected BaseAttr m_Component;
    protected AdditionalAttr m_AdditionialAttr;

    public void SetComponent(BaseAttr theComponent)
    {
        m_Component = theComponent;
    }

    public void SetAdditionalAttr(AdditionalAttr theAdditionalAttr)
    {
        m_AdditionialAttr = theAdditionalAttr;
    }

    public override int GetMaxHP()
    {
        return m_Component.GetMaxHP();
    }

    public override string GetAttrName()
    {
        return m_Component.GetAttrName();
    }
}


