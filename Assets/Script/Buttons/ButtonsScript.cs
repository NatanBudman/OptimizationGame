using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsScript : MonoBehaviour
{
   public void Exit()
   {
      Application.Quit();
   }

   public void AddSoundButton(AudioSource sound)
   {
      sound.Play();
   }

   public void ChangeScene(string Scene)
   {
      SceneManager.LoadScene($"Scenes/{Scene}");
   }

   public void EnableScreen(GameObject Screen)
   {
      if (Screen.activeSelf)
      {
         Screen.SetActive(false);
      }
      else
      {
         Screen.SetActive(true);
      }
   }

}
