using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家建造者的数据类
/// </summary>
public class PlayerBuildParam : ICharacterBuildParam
{
    public int Lv = 0;
    public PlayerBuildParam()
    {
    }
}
/// <summary>
/// 玩家建造者
/// </summary>
public class PlayerBuilder : ICharacterBuilder
{
    private PlayerBuildParam m_BuildParam = null;
    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as PlayerBuildParam;
    }
    public override void AddCharacterSystem(Facade facade)
    {
        facade.AddPlayer(m_BuildParam.NewCharacter as IPlayer);
    }

    public override void AddWeapon()
    {
        IWeaponFactory WeaponFactory = FacadeFactory.GetWeaponFactory();
        IWeapon Weapon = WeaponFactory.CreateWeapon(m_BuildParam.weaponType);

        m_BuildParam.NewCharacter.SetWeapon(Weapon);
    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = FacadeFactory.GetAssetFactory();
        GameObject playerGameObject = AssetFactory.LoadPlayer(m_BuildParam.NewCharacter.GetAssetName());
        playerGameObject.transform.position = m_BuildParam.SpawnPosition;
        playerGameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        playerGameObject.gameObject.name = string.Format("Player[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(playerGameObject);
    }

    public override void SetCharacterAttr()
    {
        IAttrFactory theAttrFactory = FacadeFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        PlayerAttr thePlayerAttr = theAttrFactory.GetPlayerAttr(AttrID);

        thePlayerAttr.SetAttrStrategy(new PlayerAttrStrategy());

        thePlayerAttr.SetPlayerLv(m_BuildParam.Lv);

        m_BuildParam.NewCharacter.SetCharacterAttr(thePlayerAttr);
    }

    public override void AddAI()
    {
        PlayerAI theAI = new PlayerAI(m_BuildParam.NewCharacter);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }
}
