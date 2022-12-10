using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ�Ļ���
/// </summary>
public abstract class ICharacter {
    protected string m_Name = "";
    protected GameObject m_GameObject = null;
    protected string m_AssetName = "";
    protected int m_AttrID = 0;
    public IWeapon m_weapon = null;
    public ICharacterAttr m_attr = null;
    public ICharacterAI m_AI = null;

    //���캯��
    public ICharacter()
    {
        
    }
    //����ʵ��
    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
    }

    //��ȡʵ��
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }
    
    //��ȡԤ��������
    public string GetAssetName()
    {
        return m_AssetName;
    }

    //��������
    public void SetWeapon(IWeapon weapon)
    {
        if (m_weapon != null)
            m_weapon.Release();
        m_weapon = weapon;
        m_weapon.SetOwner(this);
        UnityTool.AttachToRefPos(m_GameObject, m_weapon.GetGameObject(), "weapon-point", Vector3.zero);
    }

    //������ֵ
    public void SetAttr(ICharacterAttr attr)
    {
        m_attr = attr;
    }
    //��ȡ��ֵ��ID
    public int GetAttrID()
    {
        return m_AttrID;
    }
    //�ͷ�
    public void Release()
    {
       
        if (m_GameObject != null)
        {
            m_weapon.Release();
            m_weapon = null;
            GameObject.Destroy(m_GameObject);
        }
        
    }

    //����
    public void Update()
    {
        m_weapon.Update();
    }
    //����AI
    public void SetAI(ICharacterAI CharacterAI)
    {
        m_AI = CharacterAI;
    }
    //����AI
    public void UpdateAI()
    {
        m_AI.Update();
    }
    //����
    public void Attack(ICharacter Target)
    {
        WeaponAttackTarget(Target);
        m_AI.SetIsAttack();
        m_GameObject.GetComponent<CharacterAICompoment>().PlayAttackAnim(this);
    }
    public abstract void UnderAttack(ICharacter Attacker);
    //����������Ŀ��
    protected void WeaponAttackTarget(ICharacter Target)
    {
        m_weapon.Fire(Target);
    }

    public virtual void SetCharacterAttr(ICharacterAttr CharacterAttr)
    {
        m_attr = CharacterAttr;
        m_attr.InitAttr();

        m_Name = m_attr.GetAttrName();
    }

    public int GetAtkValue()
    {
        return m_weapon.GetAtkValue();
    }
}
