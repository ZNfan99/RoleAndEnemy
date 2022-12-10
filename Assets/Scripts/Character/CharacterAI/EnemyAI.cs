using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// µÐÈËµÄAI
/// </summary>
public class EnemyAI : ICharacterAI
{
    public EnemyAI(ICharacter character) : base(character)
    {
        ChangeAIState(new IdleAIState());
    }

    
}
