using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingsUI : MonoBehaviour
{
    private TextMeshProUGUI ringsCountText;
    
    void Start()
    {
        ringsCountText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateRingCount(RingsCount ringsCount)
    {
        //rings collect UI
        ringsCountText.text = ringsCount.NumberOfRings.ToString();
    }
    
}
