using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
   void Update()
    {
        this.gameObject.transform.Rotate(Vector2.up * 3); 
    }
}
