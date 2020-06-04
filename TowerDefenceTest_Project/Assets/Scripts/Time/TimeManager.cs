using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimeManager : MonoBehaviour
{
    private static TimeManager i;
    private MyEnums.GameSpeed gameSpeed;
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
    }

    public static TimeManager I => i;

    public void Subscribe(TimeButton button)
    {
        buttonsList.Add(button);
        if (button.SpeedType == MyEnums.GameSpeed.Normal)
            button.PressOn();
    }

    public void ButtonClicked(TimeButton button)
    {
        PressOffButtons();
        if(gameSpeed == button.SpeedType)
        {
            GameSpeed = MyEnums.GameSpeed.Normal;
        }
        else
        {
            button.PressOn();
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
            gameSpeed = value;
            if (pause) return;
            switch(gameSpeed)
            {
                case MyEnums.GameSpeed.Pause:
                    Time.timeScale = 0;
                    break;
                case MyEnums.GameSpeed.Normal:
                    Time.timeScale = 1;
                    break;
            }
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
                GameSpeed = gameSpeed;
        }
    }
}
