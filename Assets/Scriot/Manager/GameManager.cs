using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,IUpdates
{
    public GameObject pausePanel;
    public Text EnemyCount;
    private int _totalEnemy = 100;
    

    public void GetEnemyCount(int EnemyCount)
    {
        _totalEnemy = EnemyCount;
    }


    public void UIUpdate()
    {
        EnemyCount.text = "" + _totalEnemy;
    }

    public void GameplayUpdate()
    {
        if (_totalEnemy <= 0)
        {
            win();
        }

        if (Time.timeScale == 0)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }

    void win()
    {
        SceneManager.LoadScene("Scenes/Victory");
    }

    public void Pause(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
