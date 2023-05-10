using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour,IUpdates
{
    public Image Background;
    public Color[] _Color;
    private int index;

    public float TimerPassColor;
    private float _CurrentTimerPassColor;
    public void UIUpdate()
    {
        _CurrentTimerPassColor += Time.deltaTime;

        if (_CurrentTimerPassColor >= TimerPassColor)
        {
            if (index > _Color.Length)
            {
                index = 0;
            }
            index++;
            Background.color = _Color[index];

            _CurrentTimerPassColor = 0;
        }
    }

    public void GameplayUpdate()
    {
        
    }
}
