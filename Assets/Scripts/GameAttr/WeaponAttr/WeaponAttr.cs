using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttr
{
    public int Atk { get; private set; }

    public string AttrName { get; private set; }

    public WeaponAttr(int atk, string attrName)
    {
        Atk = atk;
        AttrName = attrName;
    }
}
