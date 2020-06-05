using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShowDamageBehaviorFactory
{
    public static IShowDamageBehavior GetBehavior()
    {
        return new ShowDamageBehavior_NoText();
    }
}
