using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �൱���ǽ�ɫ�����ߵĹ�����
/// </summary>
public class CharacterBuilderSystem : IGameSystem
{
    private int m_GameObjectID = 0;
    public CharacterBuilderSystem(Facade facade) : base(facade)
    {
    }

    public override void Initialize()
    { }

    public override void Update()
    { }

    public override void Release()
    {
        
    }
 
    //��װ
    public void Construct(ICharacterBuilder theBuilder)
    {
        theBuilder.LoadAsset(++m_GameObjectID);
        theBuilder.AddWeapon();
        theBuilder.SetCharacterAttr();
        theBuilder.AddAI();

        theBuilder.AddCharacterSystem(m_Facade);
    }
}
