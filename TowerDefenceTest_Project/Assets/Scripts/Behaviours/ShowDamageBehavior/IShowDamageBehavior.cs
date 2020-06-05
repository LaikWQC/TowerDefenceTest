using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShowDamageBehavior
{
    void ShowDamage(ITarget enemy, float damage);
}
