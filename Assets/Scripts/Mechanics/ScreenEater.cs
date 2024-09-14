using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEater : MonoBehaviour
{
    public float ScreenEatSpeed = 4f;

    private void Update()
    {
        transform.Translate(Vector3.right * ScreenEatSpeed * Time.deltaTime);
    }
}
