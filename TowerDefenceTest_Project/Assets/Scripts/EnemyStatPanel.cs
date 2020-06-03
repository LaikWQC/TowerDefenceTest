using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatPanel : MonoBehaviour
{
    [SerializeField] private Text WaveText;
    [SerializeField] private Text CountText;
    [SerializeField] private Text HpText;
    [SerializeField] private Text SpeedText;
    [SerializeField] private Text DamageText;
    [SerializeField] private Text GoldText;

    public void SetPanel(int wave, int count, int hp, float speed, int damage, int gold)
    {
        WaveText.text = wave.ToString();
        CountText.text = count.ToString();
        HpText.text = hp.ToString();
        SpeedText.text = speed.ToString();
        DamageText.text = damage.ToString();
        GoldText.text = gold.ToString();
    }
}
