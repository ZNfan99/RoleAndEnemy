using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public WeaponFactory() { }
    public override IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        string assetName = "";  
        int attrID = 0; 	
        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new Gun();
                assetName = "Gun";
                attrID = 1;
                break;
            case WeaponType.Knife:
                weapon = new Knife();
                assetName = "Knife";
                attrID = 2;
                break;
            case WeaponType.Sword:
                weapon = new Sword();
                assetName = "Sword";
                attrID = 3;
                break;
            default:
                Debug.LogWarning("Œ‰∆˜¿‡–Õ¥ÌŒÛ");
                return null;
        }
        IAssetFactory assetFactory = FacadeFactory.GetAssetFactory();
        GameObject weaponGameObject = assetFactory.LoadWeapon(assetName);
        weapon.SetGameObject(weaponGameObject);

        IAttrFactory attrFactory = FacadeFactory.GetAttrFactory();
        WeaponAttr weaponAttr = attrFactory.GetWeaponAttr(attrID);

        weapon.SetWeaponAttr(weaponAttr);

        return weapon;
    }
}
