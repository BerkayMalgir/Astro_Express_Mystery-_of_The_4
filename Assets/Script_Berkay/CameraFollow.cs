
using System;
using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public float FollowSpeed = 2f;
   public float yOffset = 1f;
   public Transform target;

   private void LateUpdate()
   {
       Vector3 newPosition = new Vector3(target.position.x, target.position.y + yOffset, -10);
       transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
   }
}
