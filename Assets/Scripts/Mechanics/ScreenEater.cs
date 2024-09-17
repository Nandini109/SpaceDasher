using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEater : MonoBehaviour
{
    [SerializeField] private float ScreenEatSpeed = 4f;

    private void Update()
    {
        //Constant speed at which screen eater moves
        transform.Translate(Vector3.right * ScreenEatSpeed * Time.deltaTime);
    }
}
