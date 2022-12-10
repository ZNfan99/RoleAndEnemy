using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttr : ICharacterAttr
{
    protected int m_PlayerLv; 
    protected int m_AddMaxHP; 
    public PlayerAttr() { }

    public void SetPlayerAttr(BaseAttr baseAttr)
    {
        base.SetBaseAttr(baseAttr); 
        m_PlayerLv = 1;
        m_AddMaxHP = 0;
    }
    public void SetPlayerLv(int Lv)
    {
        m_PlayerLv = Lv;
    }
    public int GetPlayerLv()
    {
        return m_PlayerLv;
    }
    public override int GetMaxHP()
    {
        return base.GetMaxHP() + m_AddMaxHP;
    }
    public void AddMaxHP(int AddMaxHP)
    {
        m_AddMaxHP = AddMaxHP;
    }
}
