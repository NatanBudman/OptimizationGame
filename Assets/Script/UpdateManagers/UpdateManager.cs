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
        _updateManagerGameplay = new List<UpdateManagerGameplay>(1000);
        _updateManagerUI = new List<UpdateManagerUI>(1000);
        
    
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
     //   GameplaynextTime = Time.time + GameplaytimePerFrame;
        UItimePerFrame = 1f / UIFps;
    }

    private void Update()
    {
        var gameplayLenght = _updateManagerGameplay.Count;
        var UILenght = _updateManagerUI.Count;

        GameplaytimePerFrame += Time.deltaTime;
        
        if (GameplaytimePerFrame > GameplaynextTime)
        { 
            for (int i = 0; i < gameplayLenght; i++)
            {
               
                if (_updateManagerGameplay[i].gameObject.activeInHierarchy)
                {
                    _updateManagerGameplay[i].UpdateGameplay();
                }
                else
                {
                    RemovedManager(_updateManagerGameplay[i]);
                }

            }

            GameplaytimePerFrame = 0;

        }

        UItimePerFrame += Time.deltaTime;
        if (UItimePerFrame > UInextTime)
        {
            for (int i = 0; i < UILenght; i++)
            {
                
                if (_updateManagerUI[i].gameObject.activeInHierarchy)
                {
                    _updateManagerUI[i].UpdateUI();
                }   else
                {
                    RemovedManager(_updateManagerUI[i]);
                }

                
                
            }

            UItimePerFrame = 0;
        }

        
    }
}
