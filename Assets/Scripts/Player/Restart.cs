using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Transform firstSpawn;
    public Transform secondSpawn;

    public CameraTrigger ct;

    public void OnRestart(InputValue val)
    {
        if (!ct.isInSecondRoom)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            gameObject.transform.position = firstSpawn.position;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            gameObject.transform.position = secondSpawn.position;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
