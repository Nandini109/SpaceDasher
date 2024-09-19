using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reducer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
}
