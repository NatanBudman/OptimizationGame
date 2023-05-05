using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]private List<UpdateManagerGameplay> _updateManagerGameplay;

    [SerializeField]private List<UpdateManagerUI> _updateManagerUI;
    
    [Header("FPS")]
    public int GameplaFps = 60;
    public int UIFps = 30;

    private float GameplaytimePerFrame;
    private float UItimePerFrame;
    
    
    private float GameplaynextTime = 0;
    private float UInextTime = 0;
    


    private void Awake()
    {
        _updateManagerGameplay = new List<UpdateManagerGameplay>(100);
        _updateManagerUI = new List<UpdateManagerUI>(100);
    }

    public void AddManagers(UpdateManagerGameplay gameplay)
    {
        _updateManagerGameplay.Add(gameplay);
    }
    public void AddManagers(UpdateManagerUI UI)
    {
        _updateManagerUI.Add(UI);
    }
    public void RemovedManager(UpdateManagerGameplay gameplay)
    {
        _updateManagerGameplay.Remove(gameplay);

    }
    public void RemovedManager(UpdateManagerUI UI)
    {
        _updateManagerUI.Remove(UI);
    }

    private void Start()
    {
     
        
        GameplaytimePerFrame = 1f / GameplaFps;
        UItimePerFrame = 1f / UIFps;
    }

    private void Update()
    {
        var gameplayLenght = _updateManagerGameplay.Count;
        var UILenght = _updateManagerUI.Count;


        if (Time.time < GameplaFps)
        {
            for (int i = 0; i < gameplayLenght; i++)
            {
                if (_updateManagerGameplay[i] != null)
                {
                    if (_updateManagerGameplay[i].gameObject.activeInHierarchy)
                    {
                        _updateManagerGameplay[i].UpdateGameplay();
                    }
                }

            }
            
            GameplaynextTime += GameplaytimePerFrame;

        }


        if (Time.time < UIFps)
        {
            for (int i = 0; i < UILenght; i++)
            {
                if (_updateManagerGameplay[i] != null)
                {
                    if (_updateManagerUI[i].gameObject.activeInHierarchy)
                    {
                        _updateManagerUI[i].UpdateUI();
                    }

                }
            }
            UInextTime += UItimePerFrame;
        }

        
    }
}
