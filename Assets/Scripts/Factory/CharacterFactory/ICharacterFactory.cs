using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterFactory
{
    public abstract IEnemy CreateEnemy(EnemyType type,WeaponType weaponType, Vector3 SpawnPosition);

    public abstract IPlayer CreatePlayer(PlayerType type, WeaponType weaponType,int lv, Vector3 SpawnPosition);
}

