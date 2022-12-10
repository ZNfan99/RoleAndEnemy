using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˵�AI
/// </summary>
public class EnemyAI : ICharacterAI
{
    public EnemyAI(ICharacter character) : base(character)
    {
        ChangeAIState(new IdleAIState());
    }

    
}
