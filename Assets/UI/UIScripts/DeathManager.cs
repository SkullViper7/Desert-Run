using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    
    public TMPro.TMP_Text deathsCounterDisplay;
    public int deathCount;

    public void Update()
    {
        deathsCounterDisplay.text = "Death Count : " + deathCount;
    }
}
