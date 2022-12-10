using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Null = 0,
    Gun = 1,
    Knife = 2,
    Sword = 3,
}

public abstract class IWeapon
{
    public WeaponType m_WeaponType = WeaponType.Null;
    public int m_AtkPlusValue = 0;
    public GameObject m_GameObject = null;
    public ICharacter m_WeaponOwner = null;
    public WeaponAttr m_WeaponAttr = null;

    public float m_EffectDisplayTime = 0;
    public GameObject EffectObj = null;

    public IWeapon()
    {
        
    }

    public WeaponType GetWeaponType()
    {
        return m_WeaponType;
    }

    public void SetWeaponAttr(WeaponAttr weaponAttr)
    {
        m_WeaponAttr = weaponAttr;
    }

    public int GetAtkValue()
    {
        return m_WeaponAttr.Atk + m_AtkPlusValue;
    }

    public void SetGameObject(GameObject obj)
    {
        m_GameObject = obj;
        SetUpEffect();
    }

    private void SetUpEffect()
    {
        if(EffectObj == null)
            EffectObj = UnityTool.FindChildGameObject(m_GameObject, "Effect");
        EffectObj.SetActive(false);
    }
    public void DisableEffect()
    {
        if(EffectObj.activeSelf)
        {
            EffectObj.SetActive(false);
        }
    }

    public GameObject GetGameObject()
    {
        return m_GameObject;
    }

    public void SetOwner(ICharacter owner)
    {
        m_WeaponOwner = owner;
    }

    public void SetAtkPlusValue(int Value)
    {
        m_AtkPlusValue = Value;
    }

    public void Fire(ICharacter theTarget)
    {
        ShowEffect();
        theTarget.UnderAttack(m_WeaponOwner);
    }

    public virtual  void ShowEffect()
    {
        EffectObj.SetActive(true);
    }

    public virtual void DoAfter()
    {
        Debug.Log("¹¥»÷Ç°");
    }

    public virtual void DoIn()
    {
        Debug.Log("¹¥»÷ÖÐ");
    }

    public virtual void DoBefore()
    {
        Debug.Log("¹¥»÷ºó");
    }
    public void Update()
    {
        
    }
    public void Release()
    {
        if (m_GameObject != null)
            GameObject.Destroy(m_GameObject);
    }
}
