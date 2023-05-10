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

