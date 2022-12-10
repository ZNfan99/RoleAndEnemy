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
        Debug.Log("Ç¹Ç°");
    }
    public override void DoIn()
    {
        Debug.Log("Ç¹ÖÐ");
    }
    public override void DoAfter()
    {
        Debug.Log("Ç¹ºó");
    }
}
