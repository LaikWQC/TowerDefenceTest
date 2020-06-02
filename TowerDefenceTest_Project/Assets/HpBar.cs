using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    Transform fill;
    void Start()
    {
        fill = transform.Find("Fill");
    }

    public void SetAmount(float amount)
    {
        fill.localScale = new Vector3(Mathf.Clamp(amount, 0, 1), 1);
    }
}
