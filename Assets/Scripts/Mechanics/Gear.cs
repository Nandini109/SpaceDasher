using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gear : MonoBehaviour
{
    [SerializeField] private float roationSpeed = 10f;
   
    void Update()
    {
        transform.Rotate(0, 0, roationSpeed);
    }
}
