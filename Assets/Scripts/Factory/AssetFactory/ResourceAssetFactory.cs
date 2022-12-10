using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAssetFactory : IAssetFactory
{
    public const string PlayerPath = "Prefab/Player/";
    public const string EnemyPath = "Prefab/Enemy/";
    public const string WeaponPath = "Prefab/Weapons/";
    public override GameObject LoadEnemy(string AssetName)
    {
        return InstantiateGameObject(EnemyPath + AssetName);
    }

    public override GameObject LoadPlayer(string AssetName)
    {
        return InstantiateGameObject(PlayerPath + AssetName);
    }

    public override GameObject LoadWeapon(string AssetName)
    {
        return InstantiateGameObject(WeaponPath + AssetName);
    }

    private GameObject InstantiateGameObject(string AssetName)
    {
        UnityEngine.Object res = LoadGameObjectFromResourcePath(AssetName);
        if (res == null)
            return null;
        return Object.Instantiate(res) as GameObject;
    }

    public Object LoadGameObjectFromResourcePath(string AssetPath)
    {
        UnityEngine.Object res = Resources.Load(AssetPath);
        if (res == null)
        {
            Debug.LogWarning("不存在该模型");
            return null;
        }
        return res;
    }
}
