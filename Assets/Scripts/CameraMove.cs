using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float MoveSpeed = 4f;

    private void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
    }
}
