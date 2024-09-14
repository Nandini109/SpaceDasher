using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float MoveSpeed = 4f;

    private bool stopCamera = false;

    private void Update()
    {
        if ((!stopCamera))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        
    }

    public void StopCamera()
    {
        stopCamera = true;
    }
}
