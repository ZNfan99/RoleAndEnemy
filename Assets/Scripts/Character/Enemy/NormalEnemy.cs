using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ͨ����
/// </summary>
public class NormalEnemy : IEnemy
{
    public NormalEnemy()
    {
        m_EnemyType = EnemyType.NormalEnemy;
        m_AssetName = "Enemy1";
        m_AttrID = 1;
    }
}
