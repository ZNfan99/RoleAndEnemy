using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建造者数据的基类
/// </summary>
public abstract class ICharacterBuildParam
{
    public WeaponType weaponType = WeaponType.Null;
    public ICharacter NewCharacter = null;
    public int AttrID;
    public string AssetName;
    public Vector3 SpawnPosition;
}

/// <summary>
/// 角色建造者的基类
/// </summary>
public abstract class ICharacterBuilder
{
    public abstract void SetBuildParam(ICharacterBuildParam theParam);//设置建造者的数据类
    public abstract void LoadAsset(int GameObjectID);//加载
    public abstract void AddWeapon();//添加武器
    public abstract void AddAI();//添加AI
    public abstract void SetCharacterAttr();//设置角色的数值类
    public abstract void AddCharacterSystem(Facade facade);//将角色添加到角色管理类
}
