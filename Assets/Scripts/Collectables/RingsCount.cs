using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RingsCount : MonoBehaviour
{
   public int NumberOfRings {  get; private set; } //only this script can set the value

   public UnityEvent<RingsCount> OnRingsCollected;
   public void RingsCollected()
    {
        //Incrementing the number of rings collected
        NumberOfRings++;
        OnRingsCollected?.Invoke(this);
    }
}
