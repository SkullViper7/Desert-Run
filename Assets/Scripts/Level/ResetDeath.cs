using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDeath : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("deathCount", PlayerPrefs.GetInt("deathCount", 0));
    }
}
