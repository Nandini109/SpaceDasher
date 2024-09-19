using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("1" + other.GetComponent<PlayerController>());
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("controller has");
            MenuManager.Instance.ShowWinMenu();
        }
       
    }
}
