using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʦ
/// </summary>
public class Master : IPlayer
{
    public Master()
    {
        m_PlayerType = PlayerType.Master;
        m_AssetName = "Player1";
        m_AttrID = 2;
    }

}
