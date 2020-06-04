using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TimeButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MyEnums.GameSpeed speedType;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        PressOff();
        TimeManager.I.Subscribe(this);
    }

    public void PressOn()
    {
        var color = image.color;
        color.a = 1;
        image.color = color;
    }

    public void PressOff()
    {
        var color = image.color;
        color.a = 0.5f;
        image.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TimeManager.I.ButtonClicked(this);
    }

    public MyEnums.GameSpeed SpeedType => speedType;
}
