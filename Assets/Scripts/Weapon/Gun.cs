using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : IWeapon
{
   
    public Gun()
    {
        m_WeaponType = WeaponType.Gun;
    }

    public override void DoBefore()
    {
        Debug.Log("ǹǰ");
    }
    public override void DoIn()
    {
        Debug.Log("ǹ��");
    }
    public override void DoAfter()
    {
        Debug.Log("ǹ��");
    }
}
