using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimeManager : MonoBehaviour
{
    private static TimeManager i;
    private MyEnums.GameSpeed gameSpeed;
    private TimeButton pressedButton;
    private List<TimeButton> buttonsList;

    private void Awake()
    {
        i = this;
        buttonsList = new List<TimeButton>();
        GameSpeed = MyEnums.GameSpeed.Normal;
    }

    private void Update()
    {
        if (pause) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonClicked(MyEnums.GameSpeed.Pause);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ButtonClicked(MyEnums.GameSpeed.Normal);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ButtonClicked(MyEnums.GameSpeed.Double);
        }
    }

    public static TimeManager I => i;

    public void Subscribe(TimeButton button)
    {
        buttonsList.Add(button);
        if (button.SpeedType == MyEnums.GameSpeed.Normal)
        {
            button.PressOn();
            pressedButton = button;
        }
    }

    public void ButtonClicked(TimeButton button)
    {
        if(pressedButton == button)
        {
            if (button.SpeedType == MyEnums.GameSpeed.Pause)
            {
                PressOffButtons();
                var b = buttonsList.FirstOrDefault(x => x.SpeedType == gameSpeed);
                if (b != null)
                {
                    b.PressOn();
                    pressedButton = b;
                }
                GameSpeed = gameSpeed;
            }
            else return;
        }
        else
        {
            PressOffButtons();
            button.PressOn();
            pressedButton = button;
            GameSpeed = button.SpeedType;
        }
    }

    private void ButtonClicked(MyEnums.GameSpeed type)
    {
        var button = buttonsList.FirstOrDefault(x => x.SpeedType == type);
        if (button != null)
            ButtonClicked(button);
    }

    private void PressOffButtons()
    {
        buttonsList.ForEach(x => x.PressOff());
    }

    private MyEnums.GameSpeed GameSpeed
    {
        set
        {
            if (pause) return;

            switch(value)
            {
                case MyEnums.GameSpeed.Pause:
                    Time.timeScale = 0;
                    break;
                case MyEnums.GameSpeed.Normal:
                    Time.timeScale = 1;
                    break;
                case MyEnums.GameSpeed.Double:
                    Time.timeScale = 2;
                    break;
            }
            if (value != MyEnums.GameSpeed.Pause)
                gameSpeed = value;
        }
    }

    private bool pause;
    public bool Pause
    {
        set
        {
            pause = value;
            if (pause)
                Time.timeScale = 0;
            else
                GameSpeed = pressedButton?.SpeedType ?? MyEnums.GameSpeed.Normal;
        }
    }
}
