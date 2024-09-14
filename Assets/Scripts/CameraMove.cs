using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float MoveSpeed = 4f;

    private bool StopCamera = false;

    private void Update()
    {
        if ((!StopCamera)
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        
    }
}
