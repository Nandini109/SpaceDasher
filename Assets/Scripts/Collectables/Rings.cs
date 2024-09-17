using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RingsCount ringsCount = other.GetComponent<RingsCount>();

        if(ringsCount != null )
        {
            ringsCount.RingsCollected();
            gameObject.SetActive(false);
        }
    }
}
