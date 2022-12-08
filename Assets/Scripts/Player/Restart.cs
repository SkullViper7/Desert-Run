using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Restart : MonoBehaviour
{
    public Transform firstSpawn;
    public Transform secondSpawn;
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;

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
            camera2.Priority = 10;
            camera1.Priority = 1;

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

            gameObject.transform.position = secondSpawn.position;

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
