using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private float gearRotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, gearRotationSpeed);
    }
}
