using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : IWeapon
{

    public Sword()
    {
        m_WeaponType = WeaponType.Sword;
    }

    public override void DoBefore()
    {
        Debug.Log("½£Ç°");
    }
}
