using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttrStrategy : IAttrStrategy
{

    public override int GetAtkValue(ICharacterAttr characterAttr)
    {
        return 0;
    }

    public override int GetDefValue(ICharacterAttr characterAttr)
    {
        PlayerAttr thePlayerAttr = characterAttr as PlayerAttr;
        if (thePlayerAttr == null)
            return 0;

        return (thePlayerAttr.GetPlayerLv() - 1) * 2; 
    }

    public override void InitAttr(ICharacterAttr characterAttr)
    {
        PlayerAttr thePlayerAttr = characterAttr as PlayerAttr;
        if (thePlayerAttr == null)
            return;

        int AddMaxHP = 0;
        int Lv = thePlayerAttr.GetPlayerLv();
        if (Lv > 0)
            AddMaxHP = (Lv - 1) * 2;

        thePlayerAttr.AddMaxHP(AddMaxHP);
    }
}
