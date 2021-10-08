using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float rotationsPerMinute = 10f;

 void  FixedUpdate()
 {
    transform.Rotate(0, 6f * rotationsPerMinute*Time.deltaTime,0);
 }
}
