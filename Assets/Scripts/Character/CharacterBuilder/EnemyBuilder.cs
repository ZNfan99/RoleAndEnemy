using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ���˵Ľ����ߵ�������
/// </summary>
public class EnemyBuildParam : ICharacterBuildParam
{
    public EnemyBuildParam()
    {
    }
}

/// <summary>
/// ���˵Ľ�����
/// </summary>
public class EnemyBuilder : ICharacterBuilder
{
    private EnemyBuildParam m_BuildParam = null;

    //���AI
    public override void AddAI()
    {
        EnemyAI theAI = new EnemyAI(m_BuildParam.NewCharacter);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }

    //�ѽ�ɫ���뵽��ɫ��������
    public override void AddCharacterSystem(Facade facade)
    {
        facade.AddEnemy(m_BuildParam.NewCharacter as IEnemy);
    }
    //�������
    public override void AddWeapon()
    {
        IWeaponFactory WeaponFactory = FacadeFactory.GetWeaponFactory();
        IWeapon Weapon = WeaponFactory.CreateWeapon(m_BuildParam.weaponType);

        m_BuildParam.NewCharacter.SetWeapon(Weapon);
    }

    //����ģ��
    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = FacadeFactory.GetAssetFactory();
        GameObject EnemyGameObject = AssetFactory.LoadEnemy(m_BuildParam.NewCharacter.GetAssetName());
        EnemyGameObject.transform.position = m_BuildParam.SpawnPosition;
        EnemyGameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        EnemyGameObject.gameObject.name = string.Format("Enemy[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(EnemyGameObject);
    }
    //���ý����ߵ�����
    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as EnemyBuildParam;
    }
    //������ҵ���ֵ
    public override void SetCharacterAttr()
    {
        IAttrFactory theAttrFactory = FacadeFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        EnemyAttr theEnemyAttr = theAttrFactory.GetEnemyAttr(AttrID);

        theEnemyAttr.SetAttrStrategy(new EnemyAttrStrategy());

        m_BuildParam.NewCharacter.SetCharacterAttr(theEnemyAttr);
    }
}
