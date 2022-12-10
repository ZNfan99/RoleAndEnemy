using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAttrFactory
{
    public abstract PlayerAttr GetPlayerAttr(int AttrID);

    public abstract EnemyAttr GetEnemyAttr(int AttrID);

    public abstract WeaponAttr GetWeaponAttr(int AttrID);
}
