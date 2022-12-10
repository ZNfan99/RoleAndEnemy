using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色的基类
/// </summary>
public abstract class ICharacter {
    protected string m_Name = "";
    protected GameObject m_GameObject = null;
    protected string m_AssetName = "";
    protected int m_AttrID = 0;
    public IWeapon m_weapon = null;
    public ICharacterAttr m_attr = null;
    public ICharacterAI m_AI = null;

    //构造函数
    public ICharacter()
    {
        
    }
    //设置实体
    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
    }

    //获取实体
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }
    
    //获取预制体名字
    public string GetAssetName()
    {
        return m_AssetName;
    }

    //设置武器
    public void SetWeapon(IWeapon weapon)
    {
        if (m_weapon != null)
            m_weapon.Release();
        m_weapon = weapon;
        m_weapon.SetOwner(this);
        UnityTool.AttachToRefPos(m_GameObject, m_weapon.GetGameObject(), "weapon-point", Vector3.zero);
    }

    //设置数值
    public void SetAttr(ICharacterAttr attr)
    {
        m_attr = attr;
    }
    //获取数值的ID
    public int GetAttrID()
    {
        return m_AttrID;
    }
    //释放
    public void Release()
    {
       
        if (m_GameObject != null)
        {
            m_weapon.Release();
            m_weapon = null;
            GameObject.Destroy(m_GameObject);
        }
        
    }

    //更新
    public void Update()
    {
        m_weapon.Update();
    }
    //设置AI
    public void SetAI(ICharacterAI CharacterAI)
    {
        m_AI = CharacterAI;
    }
    //更新AI
    public void UpdateAI()
    {
        m_AI.Update();
    }
    //攻击
    public void Attack(ICharacter Target)
    {
        WeaponAttackTarget(Target);
        m_AI.SetIsAttack();
        m_GameObject.GetComponent<CharacterAICompoment>().PlayAttackAnim(this);
    }
    public abstract void UnderAttack(ICharacter Attacker);
    //武器攻击的目标
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
