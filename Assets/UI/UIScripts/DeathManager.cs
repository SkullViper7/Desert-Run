using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    
    public TMPro.TMP_Text deathsCounterDisplay;

    public void Update()
    {
        deathsCounterDisplay.text = "Death Count : " + PlayerPrefs.GetInt("deathCount").ToString();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        PlayerPrefs.SetInt("deathCount", PlayerPrefs.GetInt("deathCount", 0));
    }
}
