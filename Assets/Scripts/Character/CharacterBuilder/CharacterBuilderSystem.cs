using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 相当于是角色建造者的管理者
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
 
    //组装
    public void Construct(ICharacterBuilder theBuilder)
    {
        theBuilder.LoadAsset(++m_GameObjectID);
        theBuilder.AddWeapon();
        theBuilder.SetCharacterAttr();
        theBuilder.AddAI();

        theBuilder.AddCharacterSystem(m_Facade);
    }
}
