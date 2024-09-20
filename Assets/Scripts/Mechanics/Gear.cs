using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private float gearRotationSpeed = 5f;

    
    void Update()
    {
        //rotating gear
        transform.Rotate(0, 0, gearRotationSpeed);
    }
}
