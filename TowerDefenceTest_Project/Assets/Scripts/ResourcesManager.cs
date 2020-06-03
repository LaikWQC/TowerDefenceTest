using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] Text GoldText;
    [SerializeField] Text LifeText;

    private static ResourcesManager i;

    private int gold;
    private int lifes;

    void Awake()
    {
        i = this;
    }

    private void Start()
    {
        CurrentGold = 0;
        CurrentLifes = 1;
    }

    public void AddGold(int amount)
    {
        CurrentGold += amount;
    }

    public bool Buy(int cost)
    {
        if (cost <= CurrentGold)
        {
            CurrentGold -= cost;
            return true;
        }
        return false;
    }

    public void TakeDamage(int amount)
    {
        if (CurrentLifes <= amount)
        {
            CurrentLifes = 0;
            GameManager.I.GameOver();
        }
        else
            CurrentLifes -= amount;
    }

    public static ResourcesManager I => i;
    public int CurrentGold
    {
        get => gold;
        private set
        {
            gold = value;
            GoldText.text = gold.ToString();
        }
    }
    public int CurrentLifes
    {
        get => lifes;
        private set
        {
            lifes = value;
            LifeText.text = lifes.ToString();
        }
    }
}
