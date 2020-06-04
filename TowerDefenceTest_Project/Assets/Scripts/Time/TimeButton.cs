using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TimeButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MyEnums.GameSpeed speedType;
    [SerializeField] Sprite OnSprite;
    [SerializeField] Sprite OffSprite;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        PressOff();
        TimeManager.I.Subscribe(this);
    }

    public void PressOn()
    {
        image.sprite = OnSprite;
    }

    public void PressOff()
    {
        image.sprite = OffSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TimeManager.I.ButtonClicked(this);
    }

    public MyEnums.GameSpeed SpeedType => speedType;
}
