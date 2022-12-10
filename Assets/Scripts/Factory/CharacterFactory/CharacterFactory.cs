using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : ICharacterFactory
{
    private CharacterBuilderSystem m_BuilderSystem = new CharacterBuilderSystem(Facade.Instance);
    public override IPlayer CreatePlayer(PlayerType playerType, WeaponType weaponType,int Lv, Vector3 SpawnPosition)
    {
        PlayerBuildParam playerParam = new PlayerBuildParam();
        switch (playerType)
        {
            case PlayerType.Master:
                playerParam.NewCharacter = new Master();
                break;
            case PlayerType.Warrior:
                playerParam.NewCharacter = new Warrior();
                break;
            default:
                Debug.LogWarning("无法建立该类型的玩家" + playerType);
                return null;
        }
        if(playerParam.NewCharacter == null)
        {
            return null;
        }
        playerParam.weaponType = weaponType;
        playerParam.Lv = Lv;
        playerParam.SpawnPosition= SpawnPosition;
        PlayerBuilder thePlayerBuilder = new PlayerBuilder();
        thePlayerBuilder.SetBuildParam(playerParam);

        m_BuilderSystem.Construct(thePlayerBuilder);
        return playerParam.NewCharacter as IPlayer;
    }

    public override IEnemy CreateEnemy(EnemyType enemyType, WeaponType weaponType, Vector3 SpawnPosition)
    {
        EnemyBuildParam EnemyParam = new EnemyBuildParam();

        switch (enemyType)
        {
            case EnemyType.NormalEnemy:
                EnemyParam.NewCharacter = new NormalEnemy();
                break;
            case EnemyType.Boss:
                EnemyParam.NewCharacter = new BossEnemy();
                break;
            default:
                Debug.LogWarning("无法建立该类型的敌人" + enemyType);
                break;
        }
        if (EnemyParam.NewCharacter == null)
            return null;

        EnemyParam.weaponType = weaponType;
        EnemyParam.SpawnPosition = SpawnPosition;

        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);

        m_BuilderSystem.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }
}


