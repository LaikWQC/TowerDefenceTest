using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Text DescriptionText;
    [SerializeField] Text PriceText;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Setup(Upgrade upgrade)
    {
        DescriptionText.text = upgrade.Description;
        PriceText.text = upgrade.Price.ToString();
        button.onClick.AddListener(upgrade.Activate);
    }
}
