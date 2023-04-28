using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(GrillaManager)) ]
public class GrillaManagerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();

      GrillaManager grilla = (GrillaManager)target;
      
      if (GUILayout.Button("CreateGrilla"))
      {
         grilla.create();
      }
      
      if (GUILayout.Button("DeleteGrilla"))
      {
         grilla.DeleteGrilla();
      }
   }
}
[CustomEditor(typeof(Nodo)) ]
public class NodoEditor : Editor
{
   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();

      Nodo Nodo = (Nodo)target;
      
      if (GUILayout.Button("CreateObject"))
      {
         Nodo.CreateObject();
      }
      
      if (GUILayout.Button("DeleteObject"))
      {
         Nodo.DeleteObject();
      }
   }
}
