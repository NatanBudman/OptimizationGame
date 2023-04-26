using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContadorDisparos : MonoBehaviour
{
    public Text disparosHUD;
    public int disparos;

    public void ActualizarDisparos(int cantidadDisparos)
    {
        disparos = cantidadDisparos;
        
            disparosHUD.text = "DISPAROS: " + disparos;
        
    }


}
