using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private static UpdateManager instance = null;

    [SerializeField]private UpdateManagerGameplay[] _updateManagerGameplay;
    private int _updateManagerGameplayIndex = 0;

    [SerializeField]private UpdateManagerUI[] _updateManagerUI;
    private int _updateManagerUIIndex = 0;

    private UpdateManager() { }

    public static UpdateManager Instance
    {
        get {
            if (instance == null) {
                instance = new UpdateManager();
            }
            return instance;
        }
    }

    private void Awake()
    {
        int updateGameplayLenght = FindObjectsOfType<UpdateManagerGameplay>().Length;
        int updateUILenght = FindObjectsOfType<UpdateManagerUI>().Length;

        _updateManagerGameplay = new UpdateManagerGameplay[updateGameplayLenght];
        _updateManagerUI = new UpdateManagerUI[updateUILenght];
        _updateManagerGameplay = FindObjectsOfType<UpdateManagerGameplay>();
        _updateManagerUI = FindObjectsOfType<UpdateManagerUI>();

    }

    /*

      public void add(UpdateManagerGameplay addUpdate)
      {
          Debug.Log("Entre");
          _updateManagerGameplay[_updateManagerGameplayIndex] = addUpdate;
          _updateManagerGameplayIndex++;
          Debug.Log(addUpdate);

      }
      public void add(UpdateManagerUI addUpdate)
      {
          _updateManagerUI[_updateManagerUIIndex] = addUpdate;
          _updateManagerUIIndex++;
      }
    */
    public void Remove(UpdateManagerGameplay addUpdate)
    {
        foreach (var Removed in _updateManagerGameplay)
        {
            if (Removed == addUpdate)
            {
                Removed.enabled = false;
            }
        }
    }
    public void Remove(UpdateManagerUI addUpdate)
    {
        foreach (var Removed in _updateManagerUI)
        {
            if (Removed == addUpdate)
            {
                Removed.enabled = false;
            }
        }
    }

    private void Update()
    {
        var gameplayLenght = _updateManagerGameplay.Length;
        var UILenght = _updateManagerUI.Length;
       
        for (int i = 0; i < gameplayLenght; i++)
        {
            if (_updateManagerGameplay[i] != null)
            {
                if (_updateManagerGameplay[i].enabled)
                {
                    _updateManagerGameplay[i].UpdateGameplay();
                }
            }
        }
        
        for (int i = 0; i < UILenght; i++)
        {
            if (_updateManagerGameplay[i] != null)
            {
                if (_updateManagerUI[i].enabled)
                {
                    _updateManagerUI[i].UpdateUI();
                }
            }
        }
        
    }
}
