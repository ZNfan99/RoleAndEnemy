using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FacadeFactory
{
    private static ICharacterFactory m_CharacterFactory= null;
    private static IAssetFactory m_AssetFactory = null;
    private static IWeaponFactory m_WeaponFactory = null;
    private static IAttrFactory m_AttrFactory = null;

    public static ICharacterFactory GetCharacterFactory()
    {
        if(m_CharacterFactory == null)
        {
            m_CharacterFactory = new CharacterFactory();
        }
        return m_CharacterFactory;
    }

    public static IAssetFactory GetAssetFactory()
    {
        if(m_AssetFactory == null) 
        { 
            m_AssetFactory = new ResourceAssetFactory();
        }
        return m_AssetFactory;
    }

    public static IWeaponFactory GetWeaponFactory()
    {
        if(m_WeaponFactory== null)
        {
            m_WeaponFactory = new WeaponFactory();
        }
        return m_WeaponFactory;
    }

    public static IAttrFactory GetAttrFactory()
    {
        if(m_AttrFactory== null)
        {
            m_AttrFactory = new AttrFactory();
        }
        return m_AttrFactory;
    }
}

