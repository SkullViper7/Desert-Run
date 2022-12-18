using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    private void FixedUpdate()
    {
        Invoke("LoadMenu", 3);
    }
    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
