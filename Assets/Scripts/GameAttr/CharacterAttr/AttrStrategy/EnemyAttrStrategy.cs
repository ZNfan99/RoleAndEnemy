using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public override int GetAtkValue(ICharacterAttr characterAttr)
    {
        EnemyAttr enemyAttr = characterAttr as EnemyAttr;
        if(enemyAttr == null)
        {
            return 0;
        }
        int RandValue = Random.Range(0, 100);
        if (enemyAttr.GetCritRate() >= RandValue)
        {
            enemyAttr.CutdownCritRate();     
            return enemyAttr.GetMaxHP() * 5;     
        }
        return 0;
    }

    public override int GetDefValue(ICharacterAttr characterAttr)
    {
        return 0;
    }

    public override void InitAttr(ICharacterAttr characterAttr)
    {
        
    }
}
