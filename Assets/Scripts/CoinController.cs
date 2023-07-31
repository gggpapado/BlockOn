using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
   public float spinSpeed;

   void FixedUpdate()
   {
    transform.Rotate(Vector3.up*spinSpeed);
   }

   
}
