using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ҵ�AI
/// </summary>
public class PlayerAI : ICharacterAI
{
    public PlayerAI(ICharacter character) : base(character)
    {
        ChangeAIState(new IdleAIState());
    }
}
