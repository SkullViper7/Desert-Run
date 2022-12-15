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

    public CameraTrigger ct;
    public PlayerMovement pm;
    public DeathManager dm;

    public void OnRestart(InputValue val)
    {
        if (!ct.isInSecondRoom)
        {
            gameObject.transform.position = firstSpawn.position;
            SingleTonReload.Instance.SceneResetAll();
            pm.DisableReverse();
            dm.deathCount++;


            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            gameObject.transform.position = secondSpawn.position;
            pm.DisableReverse();
            dm.deathCount++;

            SingleTonReload.Instance.SceneResetAll();

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
