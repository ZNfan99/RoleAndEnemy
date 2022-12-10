using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAttrStrategy
{
    public abstract void InitAttr(ICharacterAttr characterAttr);

    public abstract int GetAtkValue(ICharacterAttr characterAttr);

    public abstract int GetDefValue(ICharacterAttr characterAttr);
}
