using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private Dictionary<int, BaseAttr> m_PlayerAttrDB = null;
    private Dictionary<int, EnemyBaseAttr> m_EnemyAttrDB = null;
    private Dictionary<int, WeaponAttr> m_WeaponAttrDB = null;

    public AttrFactory() 
    {
        InitPlayerAttr();
        InitEnemyAttr();
        InitWeaponAttr();
    }

    private void InitWeaponAttr()
    {
        m_WeaponAttrDB = new Dictionary<int, WeaponAttr>
        {
            { 1, new WeaponAttr(2, "刀") },
            { 2, new WeaponAttr(3, "剑") },
            { 3, new WeaponAttr(5, "枪") }
        };
    }

    private void InitEnemyAttr()
    {
        m_EnemyAttrDB = new Dictionary<int, EnemyBaseAttr>
        {
            { 1, new EnemyBaseAttr(5, "普通怪物",10) },
            { 2, new EnemyBaseAttr(15, "Boss",20) }
        };
    }

    private void InitPlayerAttr()
    {
        m_PlayerAttrDB = new Dictionary<int, BaseAttr>
        {
            {1,new CharacterBaseAttr(10,"战士") },
            {2,new CharacterBaseAttr(10,"法师") },
        };
    }

    public override EnemyAttr GetEnemyAttr(int AttrID)
    {
        if(!m_EnemyAttrDB.ContainsKey(AttrID))
        {
            Debug.LogWarning("敌人不存在该ID");
            return null;
        }
        EnemyAttr newAttr = new EnemyAttr();
        newAttr.SetEnemyAttr(m_EnemyAttrDB[AttrID]);
        return newAttr;
    }

    public override PlayerAttr GetPlayerAttr(int AttrID)
    {
        if (!m_PlayerAttrDB.ContainsKey(AttrID))
        {
            Debug.LogWarning("玩家不存在该ID");
            return null;
        }
        PlayerAttr newAttr = new PlayerAttr();
        newAttr.SetPlayerAttr(m_PlayerAttrDB[AttrID]);
        return newAttr;
    }

    public override WeaponAttr GetWeaponAttr(int AttrID)
    {
        if (!m_WeaponAttrDB.ContainsKey(AttrID))
        {
            Debug.LogWarning("武器不存在该ID");
            return null;
        }
        return m_WeaponAttrDB[AttrID];
    }
}
