using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss
/// </summary>
public class BossEnemy : IEnemy
{
   public BossEnemy()
    {
        m_EnemyType = EnemyType.Boss;
        m_AssetName = "Enemy2";
        m_AttrID = 2;
    }
}
