using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContadorDisparos : MonoBehaviour, IUpdates
{
    public Text disparosHUD;
    public int disparos;

    public void ActualizarDisparos(int cantidadDisparos)
    {
        disparos = cantidadDisparos;
        
            disparosHUD.text = "DISPAROS: " + disparos;
        
    }


    public void UIUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            disparos++;
            ActualizarDisparos(disparos);
        }
    }

    public void GameplayUpdate()
    {
    }
}
