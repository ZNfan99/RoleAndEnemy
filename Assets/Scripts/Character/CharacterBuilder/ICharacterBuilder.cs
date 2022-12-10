using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������ݵĻ���
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
/// ��ɫ�����ߵĻ���
/// </summary>
public abstract class ICharacterBuilder
{
    public abstract void SetBuildParam(ICharacterBuildParam theParam);//���ý����ߵ�������
    public abstract void LoadAsset(int GameObjectID);//����
    public abstract void AddWeapon();//�������
    public abstract void AddAI();//���AI
    public abstract void SetCharacterAttr();//���ý�ɫ����ֵ��
    public abstract void AddCharacterSystem(Facade facade);//����ɫ��ӵ���ɫ������
}
