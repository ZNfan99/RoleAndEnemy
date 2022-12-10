using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAssetFactory
{
    public abstract GameObject LoadPlayer(string AssetName);
    public abstract GameObject LoadEnemy(string AssetName);
    public abstract GameObject LoadWeapon(string AssetName);
}
