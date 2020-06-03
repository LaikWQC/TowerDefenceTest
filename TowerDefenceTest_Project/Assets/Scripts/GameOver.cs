using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text ScoreText;

    public void Activate(int score)
    {
        ScoreText.text = score.ToString();
        gameObject.SetActive(true);
    }
}
