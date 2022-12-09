using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayLevel : MonoBehaviour
{
    public TMPro.TMP_Text levelDisplay;

    public void Update()
    {
        levelDisplay.text = "Level : " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
