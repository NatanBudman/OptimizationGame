using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiDetectionColliders
{
   private float Radius;
   private float Angle;
   private Collider[] _collider;
   private Transform Origin;
   private LayerMask _layerMask;
   private LayerMask _layerObstacle;

   public EntitiDetectionColliders(Transform origin,LayerMask layerDetected, LayerMask obstacles,float radius,float angle, int maxEntitiDetec)
   {
      Radius = radius;
      Angle = angle;
      Origin = origin;
      _layerMask = layerDetected;
      _layerObstacle = obstacles;
      _collider = new Collider[maxEntitiDetec];
   }
   GameObject Entiti;
   public GameObject GetEntiti( )
   {
      int countObstacle = Physics.OverlapSphereNonAlloc(Origin.position, Radius,_collider, _layerMask);
     

      for (int i = 0; i < countObstacle; i++)
      {
         Collider currObs = _collider[i];
         Vector3 closePoint = currObs.ClosestPointOnBounds(Origin.position);
         Vector3 diffPoint = closePoint - Origin.position;
         float angleToObs = Vector3.Angle(Origin.forward, diffPoint);

         if (angleToObs > Angle / 2)
         {
            Entiti = null;
         }
         else
         {
            EntitiDetected();
         }
      }

      return Entiti;
   }

   public void EntitiDetected()
   {
    
      
      foreach (Collider enti in _collider)
      {
         if (enti != null)
         {
            if (EntitiSee(enti.transform))
            {
               Entiti = enti.gameObject;

            }
         }
      }

   }

   public bool EntitiSee(Transform entiti)
   {
      bool isSeeEntiti = false;

      Vector3 diffPoint = entiti.position - Origin.transform.position;
      
      float distDetect = Vector3.Distance(entiti.transform.position, Origin.transform.position);

      float angleToPoint = Vector3.Angle(Origin.forward, diffPoint);
      
      if (angleToPoint > Angle / 2 && distDetect < Radius)
      {
         Vector3 diff = (entiti.position - Origin.transform.position);
         Vector3 dirToTarget = diff.normalized;
         float distTarget = diff.magnitude;

         RaycastHit hit;

         isSeeEntiti = !Physics.Raycast(Origin.transform.position, dirToTarget, out hit, distTarget, _layerObstacle);

      }


      return isSeeEntiti;
      
   }
}
