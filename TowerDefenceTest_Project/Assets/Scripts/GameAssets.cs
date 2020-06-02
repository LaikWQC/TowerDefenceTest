using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets i;

    private void Awake()
    {
        i = this;
    }

    public static GameAssets I => i;

    public GameObject EnemyPf;
}
